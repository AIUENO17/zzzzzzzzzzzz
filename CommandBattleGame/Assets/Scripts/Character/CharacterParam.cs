using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParam 
{
    public int Attack;
    public bool IsEnemy;
    public enum GameCharacterType
    {
        Invalide,
        Attacker,
        SpellCaster,
        Healer,
    }

    
    public int HitPoint;

    public int MagicPoint;
    public float Speed;

    public GameCharacterType CharacterType;
    //一番目のボタンを押すと行動する
    public Action FirstButtonAction;
    //二番目のボタンを押すと行動する
    public Action SecondButtonAction;
    //省略
    public Action ThirdButtonAction;
    public Action FourthButtonAction;
}
