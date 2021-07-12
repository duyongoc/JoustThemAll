using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : Singleton<Enemy>
{


    //
    //= enum
    public enum EEnemy
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
    [Range(0, 1)] public float precenSequenceSuccess;
    public EEnemy currentState = EEnemy.None;
    public GameObject bodyEnemy;
    [SerializeField] private float timeMove;
    public int enemyTAP = 5;


    //
    //= inspector
    [Space(15)]
    [SerializeField] private Transform skinTransform;
    [SerializeField] private GameObject[] skinEnemies;
    [SerializeField] private BodyPanel bodyPanel;
    [SerializeField] private Vector3 target;


    //
    //= private 
    private const string ENEMY_IDLE = "Idle";
    private const string ENEMY_RUN = "Run";
    private const string ENEMY_RUNSPEED = "RunSpeed";
    private const string ENEMY_LOSE = "Lose";
    private string curAnimation = "";

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private MainGame mainGame;
    private Character character;
    private Vector3 originPos;
    private bool successSequence;
    private bool isDead = false;
    private int roundWin = 0;

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

        UpdateEnemy();
    }
    #endregion


    private void UpdateEnemy()
    {
        switch (currentState)
        {
            case EEnemy.Idle: OnStateIdle(); break;
            case EEnemy.Run: OnStateRun(); break;
            case EEnemy.RunSpeed: OnStateRunSpeed(); break;
            case EEnemy.HitMiss: OnStateHitMiss(); break;
            case EEnemy.Lose: OnStateLose(); break;
            case EEnemy.None: OnStateNone(); break;
        }
    }

    public void InitEnemy()
    {
        if (isDead) spriteRenderer.material.DOFade(0, 0);
        SetState(EEnemy.Idle);
        transform.position = originPos;
        spriteRenderer.material.DOFade(1, 1);
    }

    private void OnStateIdle()
    {
        SetAnimation(ENEMY_IDLE);
    }

    private void OnStateRun()
    {
        SetAnimation(ENEMY_RUN);
        SetState(EEnemy.None);
    }

    private void OnStateRunSpeed()
    {
        SetAnimation(ENEMY_RUNSPEED);
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_joust);
        transform.DOMove(target, timeMove * 6).OnComplete(() => { });
        SetState(EEnemy.None);
    }

    private void OnStateReturn()
    {
        // SetAnimation(ENEMY_RUN);
        // SetState(EEnemy.None);
        // transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        // transform.DOMove(originPos, timeMove / 2).OnComplete(() =>
        // {
        //     transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        // });
    }

    private void OnStateHitMiss()
    {
        SetAnimation(ENEMY_RUNSPEED);
        transform.DOMove(new Vector2(-25, transform.position.y), timeMove * 4);
        SetState(EEnemy.None);
    }

    private void OnStateLose()
    {
        transform.localPosition = new Vector2(-10, transform.position.y);
        GameMgr.Instance.DelayEvent(() => { SetAnimation(ENEMY_LOSE); }, 0.25f);
        isDead = true;
    }

    private void OnStateNone()
    {
    }


    public void SetState(EEnemy newState)
    {
        currentState = newState;
    }

    public void SetAnimation(string animtion)
    {
        if (curAnimation == animtion)
            return;

        curAnimation = animtion;
        animator.Play(curAnimation);
    }

    public void ChangeAnimationIdle()
    {
        SetAnimation(ENEMY_IDLE);
    }

    public void ChangeAnimationRun()
    {
        SetAnimation(ENEMY_RUN);
    }

    public void ChangeAnimationRunSpeed()
    {
        SetAnimation(ENEMY_RUNSPEED);
    }

    public void ChangeAnimationLose()
    {
        SetAnimation(ENEMY_LOSE);
    }

    public bool GetSussessSequence()
    {
        return successSequence;
    }

    public int GetEnemyTAP()
    {
        enemyTAP = UnityEngine.Random.Range(16, 25);
        return enemyTAP;
    }

    public void UpdateEnemySequenceStatus(string status)
    {
        bodyPanel.SetEnemySequenceStatus("Sequence: " + status);
    }

    public void UpdateSequences()
    {
        // random 
        var rand = UnityEngine.Random.Range(0f, 1f);
        successSequence = precenSequenceSuccess > rand;

        //random time
        float timeSequence = UnityEngine.Random.Range(mainGame.roundTimer - 2.5f, mainGame.roundTimer - 1f);
        StartCoroutine(Utils.DelayEvent(() =>
        {
            switch (successSequence)
            {
                case true:
                    UpdateEnemySequenceStatus("Correct"); break;
                case false:
                    UpdateEnemySequenceStatus("Wrong"); break;
            }
        }, timeSequence));
    }

    public void EnemyHitMissing()
    {
        isDead = true;
        SetState(EEnemy.HitMiss);
    }

    public void EnemyWin()
    {
        SetState(EEnemy.RunSpeed);
        character.SetState(Character.ECharacter.Lose);
        isDead = false;
    }

    public void ChangeSkinEnemy(int index)
    {
        var ene = Instantiate(skinEnemies[index], skinTransform);
        spriteRenderer = ene.GetComponent<SpriteRenderer>();
        animator = ene.GetComponent<Animator>();
        spriteRenderer.material.DOFade(0, 0);

        bodyEnemy = ene;
    }

    public void ResetSkinEnemy()
    {
        foreach (Transform child in transform.GetChild(0))
        {
            Destroy(child.gameObject);
        }
    }

    private void CacheDefine()
    {
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
        character = Character.Instance;
        originPos = this.transform.position;
    }

}
