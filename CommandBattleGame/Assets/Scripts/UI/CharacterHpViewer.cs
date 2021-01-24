using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterHpViewer : MonoBehaviour
{
    public int[] CharacterHps = new int[3];
    public int[] CharacterMaxHps = new int[3];
    public TextMeshProUGUI[] CharacterHPTexts = new TextMeshProUGUI[3];


    public void SetHp(int characterPos, int hp)
    {
        CharacterHps[characterPos] = hp;
    }

    public void SetMaxHp(int characterPos, int maxHp)
    {
        CharacterMaxHps[characterPos] = maxHp;
    }
    public void HpTextUpDate()
    {
        for (int i = 0; i < 3; i++)
        {
            CharacterHPTexts[i].text = $"{CharacterHps[i]}/{CharacterMaxHps[i]}";
        }
    }


    private void LateUpdate()
    {
        HpTextUpDate();
    }
}
    