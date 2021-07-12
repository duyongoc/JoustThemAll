using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Character : Singleton<Character>
{

    //
    //= enum
    public enum ECharacter
    {
        Idle,
        Run,
        RunSpeed,
        HitMiss,
        Lose,
        None
    }


    //
    //= public 
    [Header("STATE")]
    public ECharacter currentState = ECharacter.None;
    public GameObject bodyCharacter;
    [SerializeField] private float timeMove;
    public int characterTAP = 0;


    //
    //= inspector
    [Space(15)]
    [SerializeField] private BodyPanel bodyPanel;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 target;



    //
    //= private 
    private int roundWin = 0;
    private const string CHARACTER_IDLE = "Idle";
    private const string CHARACTER_RUN = "Run";
    private const string CHARACTER_RUNSPEED = "RunSpeed";
    private const string CHARACTER_LOSE = "Lose";
    private string curAnimation = "";

    private SpriteRenderer spriteRenderer;
    private Vector3 originPos;
    private Enemy enemy;
    private bool isDead = false;



    //
    //= properties
    public int RoundWin { get => roundWin; set => roundWin = value; }


    #region UNITY
    private void Start()
    {
        CacheComponent();
        CacheDefine();
    }

    private void Update()
    {
        if (!GameMgr.Instance.IsInGameState)
            return;

        UpdateCharacter();
    }
    #endregion


    private void UpdateCharacter()
    {
        switch (currentState)
        {
            case ECharacter.Idle: OnStateIdle(); break;
            case ECharacter.Run: OnStateRun(); break;
            case ECharacter.RunSpeed: OnStateRunSpeed(); break;
            case ECharacter.HitMiss: OnStateHitMiss(); break;
            case ECharacter.Lose: OnStateLose(); break;
            case ECharacter.None: break;
        }
    }

    public void InitCharacter()
    {
        if (isDead) spriteRenderer.material.DOFade(0, 0);
        SetState(ECharacter.Idle);
        transform.position = originPos;
        spriteRenderer.material.DOFade(1, 1);
    }


    private void OnStateIdle()
    {
        SetAnimation(CHARACTER_IDLE);
    }

    private void OnStateRun()
    {
        SetAnimation(CHARACTER_RUN);
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_running);
        SetState(ECharacter.None);
    }

    private void OnStateRunSpeed()
    {
        SetAnimation(CHARACTER_RUNSPEED);
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_joust);
        transform.DOMove(target, timeMove * 6).OnComplete(() => { });
        SetState(ECharacter.None);
    }

    private void OnStateHitMiss()
    {
        SetAnimation(CHARACTER_RUNSPEED);
        transform.DOMove(new Vector2(25, transform.position.y), timeMove * 4);
        SetState(ECharacter.None);
    }

    private void OnStateLose()
    {
        transform.localPosition = new Vector2(10, transform.position.y);
        GameMgr.Instance.DelayEvent(() => { SetAnimation(CHARACTER_LOSE); }, 0.25f);
        isDead = true;
    }

    private void OnStateNone()
    {
    }

    public void SetState(ECharacter newState)
    {
        currentState = newState;
    }

    public void SetAnimation(string animation)
    {
        if (curAnimation == animation)
            return;

        curAnimation = animation;
        animator.Play(curAnimation);
    }

    public void ChangeAnimationIdle()
    {
        SetAnimation(CHARACTER_IDLE);
    }

    public void ChangeAnimationRun()
    {
        SetAnimation(CHARACTER_RUN);
    }

    public void ChangeAnimationRunSpeed()
    {
        SetAnimation(CHARACTER_RUNSPEED);
    }

    public void ChangeAnimationLose()
    {
        SetAnimation(CHARACTER_LOSE);
    }

    public void UpdateCharacterSequenceStatus(string status)
    {
        bodyPanel.SetChacterSequenceStatus("Sequence: " + status);
    }

    public void CharacterHitMissing()
    {
        isDead = true;
        SetState(ECharacter.HitMiss);
    }

    public void CharacterWin()
    {
        SetState(ECharacter.RunSpeed);
        enemy.SetState(Enemy.EEnemy.Lose);
        isDead = false;
    }


    private void CacheDefine()
    {
        spriteRenderer.material.DOFade(0, 0);
    }

    private void CacheComponent()
    {
        enemy = Enemy.Instance;
        originPos = this.transform.position;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

}
