using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainGame : Singleton<MainGame>
{

    //
    //= inspector
    [Header("CONFIG")]
    public Gereral_config gereral_Config;
    public LevelRarity levelRarity;
    public DataSymbol dataSymbol;
    public Rarity rarity = Rarity.High;

    [Header("TRIGEEER")]
    public Symbol currentSymbol;
    public List<Symbol> _matchSymbol;
    public List<CodeKey> currentCodeKey;

    [Space(10)]
    [SerializeField] private BoardGameUI boardGameUI;
    [SerializeField] private InGame inGame;
    [SerializeField] private TutorialPanel tutorialPanel;


    //
    //= public 
    [Header("Game Round")]
    public int roundTimer;
    public int gameRound;
    public int currentRound;
    public float clashTimer = 5f;


    //
    //= private
    private StateInit stateInit = default;
    private StateTyping stateTyping = default;
    private StateResult stateResult = default;
    private StateClash stateClash = default;
    private StateWait stateWait = default;
    private StateNone stateNone = default;
    private GameState mGameState;

    private Character character;
    private Enemy enemy;
    private string[] keypadList;
    private Result resultRound;
    private bool firstPlaying = true;
    private bool showTutorial = false;


    //
    //= properties
    public void SetStateTyping() { SetGameState(stateTyping); }
    public void SetStateResult() { SetGameState(stateResult); }
    public void SetStateWait() { SetGameState(stateWait); }
    public void SetStateClash() { SetGameState(stateClash); }
    public void SetStateNone() { SetGameState(stateNone); }

    public GameState GetGameState { get => mGameState; }
    public BoardGameUI GetBoardGameUI { get => boardGameUI; }
    public InGame GetInGameScene { get => inGame; }
    public Character GetCharacter { get => character; }
    public Enemy GetEnemy { get => enemy; }
    public Result GetResultRound { get => resultRound; set => resultRound = value; }
    public int CurrentRound { get => currentRound; }



    #region UNITY
    private void Start()
    {
        CacheComponent();
        CacheDefine();
    }

    private void Update()
    {
        if (!GameMgr.Instance.IsInGameState || mGameState == null)
            return;

        mGameState.UpdateState();
    }
    #endregion


    public void Init(Rarity newRarity)
    {
        rarity = newRarity;
        if (!showTutorial)
        {
            enemy.InitEnemy();
            character.InitCharacter();
            tutorialPanel.InitTutorial();
            showTutorial = true;
        }
        else
        {
            CreateTheMatch();
        }
    }

    public void SetGameState(GameState newState)
    {
        if (mGameState != null)
            mGameState.EndState();

        mGameState = newState;
        mGameState.StartState();
    }

    public void CreateTheMatch()
    {

        firstPlaying = true;
        inGame.ResetReward();
        InitRandomRarityGame();
        GetSequenceSymbol();
        SetGameState(stateInit);
    }

    public void InitRandomRarityGame()
    {
        switch (rarity)
        {
            case Rarity.Low:
                roundTimer = levelRarity.low_phase.roundTime;
                _matchSymbol = levelRarity.GetRandom_Low_Rarity();
                break;
            case Rarity.Medium:
                roundTimer = levelRarity.medium_phase.roundTime;
                _matchSymbol = levelRarity.GetRandom_Medium_Rarity(); break;
            case Rarity.High:
                roundTimer = levelRarity.high_phase.roundTime;
                _matchSymbol = levelRarity.GetRandom_High_Rarity(); break;
        }
    }

    public void GetSequenceSymbol()
    {
        currentSymbol = _matchSymbol[currentRound++];
        if (!firstPlaying) currentCodeKey = boardGameUI.CreateListCodeKey(currentSymbol);
    }

    public void ResetCompareSymbol()
    {
        currentSymbol.ResetCompare(currentCodeKey);
    }

    public void RoundTimeUp(Result result)
    {
        SetStateWait();
        stateWait.WaitingWithResult(result);
    }

    public void CheckCharacterSequenceCorrect()
    {
        switch (enemy.GetSussessSequence())
        {
            case true: // power clash
                GameMgr.Instance.DelayEvent(() => { SetStateClash(); }, 0f);
                break;
            case false: // character win
                OnBothRunSpeed();
                LoadResultRound(Result.YouWin);
                break;
        }
    }

    public void CheckCharacterSequenceWrong()
    {
        switch (enemy.GetSussessSequence())
        {
            case true: // enemy win
                OnBothRunSpeed();
                LoadResultRound(Result.YouLose);
                break;
            case false: // nothing to happen 
                OnBothMissingHit();
                break;
        }
    }

    public void OnCharacterAttack()
    {
        character.CharacterWin();
        Common.CreateText("TextWin", 2f);
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_character_won);
        StartCoroutine(Utils.DelayEvent(() => { CharacterWonRound(); }, 3f));
    }

    public void OnEnemyAttack()
    {
        enemy.EnemyWin();
        Common.CreateText("TextLose", 2f);
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_character_lost);
        StartCoroutine(Utils.DelayEvent(() => { EnemyWonRound(); }, 3f));
    }

    public void OnBothMissingHit()
    {
        enemy.EnemyHitMissing();
        character.CharacterHitMissing();
        StartCoroutine(Utils.DelayEvent(() => { ResetRound(); }, 3f));
    }

    public void OnBothRunSpeed()
    {
        enemy.SetState(Enemy.EEnemy.RunSpeed);
        character.SetState(Character.ECharacter.RunSpeed);

    }

    public void LoadResultRound(Result result)
    {
        resultRound = result;
        SetGameState(stateResult);
    }

    public void ShowFinalRound()
    {
        switch (character.RoundWin > enemy.RoundWin)
        {
            case true: inGame.ShowResultPanel(true, 1); break;
            case false: inGame.ShowResultPanel(true, -1); break;
        }

        currentRound = 0;
        inGame.ChangeRoundText(currentRound);
    }

    public void CharacterWonRound()
    {
        character.RoundWin++;
        inGame.UpdateRewardCharacter();
        ResetRound();
    }

    public void EnemyWonRound()
    {
        enemy.RoundWin++;
        inGame.UpdateRewardEnemy();
        ResetRound();
    }

    public void NewRound()
    {
        ResetRound();
    }

    public void ResetRound()
    {
        boardGameUI.ResetRound(currentCodeKey);
        BackgroundMgr.Instance.ResetWaitScreen();
        ResetCompareSymbol();
        GetSequenceSymbol();

        if (currentRound == gameRound)
            LoadResultRound(Result.Finish);
        else
            SetGameState(stateTyping);
    }


    public void StartGame()
    {
        enemy.SetState(Enemy.EEnemy.Run);
        character.SetState(Character.ECharacter.Run);
        BackgroundMgr.Instance.StartScrolling();
        inGame.ShowResultPanel(false, 0);

        character.UpdateCharacterSequenceStatus("-");
        enemy.UpdateEnemySequenceStatus("-");
        enemy.UpdateSequences();
    }

    public void FirstPlayGame()
    {
        currentCodeKey = boardGameUI.CreateListCodeKey(currentSymbol);
        firstPlaying = false;
    }

    private void CacheDefine()
    {
        LoadData();
        currentRound = 0;
    }

    private void CacheComponent()
    {
        character = Character.Instance;
        enemy = Enemy.Instance;

        stateInit = GetComponent<StateInit>();
        stateTyping = GetComponent<StateTyping>();
        stateResult = GetComponent<StateResult>();
        stateWait = GetComponent<StateWait>();
        stateClash = GetComponent<StateClash>();
        stateNone = GetComponent<StateNone>();
    }

    [ContextMenu("Load Data")]
    private void LoadData()
    {
        // roundTimer = int.Parse(gereral_Config.dataArray[0].Value);
        gameRound = int.Parse(gereral_Config.dataArray[1].Value);
        levelRarity.LoadData(gameRound);
        dataSymbol.LoadData();
    }

}
