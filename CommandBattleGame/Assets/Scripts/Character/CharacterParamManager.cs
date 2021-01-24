using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParamManager : MonoBehaviour
{
    public CharacterParam CharacterParam = new CharacterParam();
    public int CharacterAttack;
    public bool IsEnemy;

    public CharacterParam GetCharacterParam
    {
        get { return CharacterParam; }
    }


    public int CharacterHP = 0;
    public int CharacterMp = 0;
    public float CharacterSpeed = 0;
    public CharacterParam.GameCharacterType CharacterType = CharacterParam.GameCharacterType.Invalide;

    public CharacterAnimationController CharacterAnimationController = null;
    // Start is called before the first frame update
    private void Init()
    {
        CharacterParam.HitPoint = CharacterHP;

        CharacterParam.MagicPoint = CharacterMp;

        CharacterParam.Speed = CharacterSpeed;

        CharacterParam.CharacterType = CharacterType;

        CharacterParam.Attack = CharacterAttack;

        CharacterParam.IsEnemy = IsEnemy;
    }
    private void Start()
    {
        bool a = IsEnemy;
        if (a == false)
        {
            CharacterParam.FirstButtonAction = FirstButtonAction;
            CharacterParam.SecondButtonAction = SecondButtonAction;
            CharacterParam.ThirdButtonAction = ThirdButtonAction;
            CharacterParam.FourthButtonAction = FourthButtonAction;

            //キャラクターの一番目のボタンの行動でパラメーターがきまる・・？？

            CharacterAnimationController = GetComponent<CharacterAnimationController>();
        }
    }

    // Update is called once per frame
    private void Awake()
    {
        Init();
    }



    //一番目のボタンを押して行動出来たらaaと表示（確認の時に使う）
    private void FirstButtonAction()
    {

        StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

    }
    private void SecondButtonAction()
    {
        Debug.Log("bb");
    }
    private void ThirdButtonAction()
    {
        Debug.Log("cc");
    }

    private void FourthButtonAction()
    {
        Debug.Log("dd");
    }


    public void Damage(int damage)
    {
        CharacterParam.HitPoint -= damage;

        CharacterHP = CharacterParam.HitPoint;
    }
}
