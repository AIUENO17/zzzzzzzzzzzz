﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator CharacterAnimator = null;

    private const string AttackAnimationName = "Attack";

    private const string IdleAnimationName = "Idle";

    private const string GotoMoveAnimationName = "GotoMove";

    private const string ReturnMoveAnimationName = "ReturnMove";

    public Transform CharacterRoot = null;

    public Transform AttackRoot = null;

    public CharacterParamManager m_CharacterParamManager = null;
    public CharacterParamManager t_CharacterParammanager = null;

    public enum CharacterType
    {
        Invalide,
        Attacker,
        SpellCaster,
        Healer,
    }
    public CharacterType characterType = CharacterAnimationController.CharacterType.Invalide;
    private void Awake()
    {
        CharacterAnimator = GetComponent<Animator>();
        m_CharacterParamManager = GetComponent<CharacterParamManager>();
    }
    // Start is called before the first frame update
    public void SetAttackAnimation(int attackNo)
    {
        if (CharacterAnimator == null)
        {
            return;
        }
        CharacterAnimator.SetInteger(AttackAnimationName, attackNo);
    }
    public void Hit()
    {
        Debug.Log("攻撃した");

        t_CharacterParammanager = GetComponent<CharacterParamManager>();


    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(StartAttackAnimation(2));

        }
    }

   public IEnumerator StartAttackAnimation(int attackId)
    {
        if (characterType == CharacterType.Attacker)
        {


            yield return StartCoroutine(StartMove());
            yield return StartCoroutine(StartAnimation(attackId));
            yield return StartCoroutine(ReturnMove());
        }
        else
        {

            yield return StartCoroutine(StartAnimation(attackId));
        }
    }

    IEnumerator StartMove()
    {
        var distance_two = Vector3.Distance(transform.position, AttackRoot.position);
        var elapsedTime = 0f;
        float waitTime = 1f;
        while (elapsedTime < waitTime)
        {
            this.transform.position = Vector3.Lerp(transform.position, AttackRoot.position, (elapsedTime / waitTime) / distance_two);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator StartAnimation(int attackNo)
    {
        SetAttackAnimation(attackNo);
        //Idleの間待つ

        if (characterType == CharacterType.Attacker)
        {
            yield return new WaitWhile(() => CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName(GotoMoveAnimationName));
        }
        yield return new WaitWhile(() => CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName(GotoMoveAnimationName));
        //Attack待つ
        yield return new WaitWhile(() => CharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f && CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName(AttackAnimationName));

        CharacterAnimator.SetInteger(AttackAnimationName, 0);
        var animatorState = CharacterAnimator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitWhile(() => animatorState.normalizedTime < 1f && animatorState.IsName(AttackAnimationName));
        //Attackの値を０に戻す
        CharacterAnimator.SetInteger(AttackAnimationName, 0);
    }

    IEnumerator ReturnMove()
    {
        var distance_two = Vector3.Distance(transform.position, CharacterRoot.position);
        var elapsedTime = 0f;
        float waitTime = 1f;
        while (this.transform != CharacterRoot && elapsedTime < waitTime)
        {
            this.transform.position = Vector3.Lerp(transform.position, CharacterRoot.position, (elapsedTime / waitTime) / distance_two);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}

