using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTyping : GameState
{

    //
    //= inspector
    [SerializeField] private float delayTime;


    //
    //= private 
    private MainGame mainGame;
    private Character character;
    private Enemy enemy;
    private Result result;

    private bool isRunning = false;
    private bool finishSequence = false;
    private float roundTimer;


    #region UNITY
    private void Start()
    {
        CacheComponent();
    }

    // private void Update()
    // {
    // }
    #endregion


    #region STATE
    public override void StartState()
    {
        base.EndState();

        isRunning = false;
        finishSequence = false;
        result = Result.SequenceWrong;
        roundTimer = mainGame.roundTimer;
        
        mainGame.GetBoardGameUI.SetValueSliderTimer(0);
        mainGame.GetEnemy.InitEnemy();
        mainGame.GetCharacter.InitCharacter();
        mainGame.GetInGameScene.ChangeRoundGame(mainGame.CurrentRound, delayTime);

        StartCoroutine(Utils.DelayEvent(() =>
        {
            isRunning = true;
            mainGame.StartGame();
        }, delayTime));
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (!isRunning)
            return;

        UpdateUserInput();
        UpdateRoundTimer();
    }

    public override void EndState()
    {
        base.EndState();
    }
    #endregion


    private void UpdateUserInput()
    {
        if (Input.anyKeyDown)
        {
            if (finishSequence || CheckSpecialButtonPress()) //CompareKeyHidden
                return;

            CheckTheSymbol();
        }
    }

    private void UpdateRoundTimer()
    {
        roundTimer -= Time.deltaTime;
        mainGame.GetBoardGameUI.CountDownSliderTime(Time.deltaTime);

        if (roundTimer <= 0)
        {
            result = (result == Result.SequenceCorrect) ? result : Result.SequenceWrong;
            mainGame.RoundTimeUp(result);
            isRunning = false;
        }
    }

    public bool CheckSpecialButtonPress()
    {
        return Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2);
    }

    private void CheckTheSymbol()
    {
        string keycode = "0";
        if (GetKeyDown(KeyCode.W) || GetKeyDown(KeyCode.UpArrow)) keycode = "W";
        else if (GetKeyDown(KeyCode.A) || GetKeyDown(KeyCode.LeftArrow)) keycode = "A";
        else if (GetKeyDown(KeyCode.S) || GetKeyDown(KeyCode.DownArrow)) keycode = "S";
        else if (GetKeyDown(KeyCode.D) || GetKeyDown(KeyCode.RightArrow)) keycode = "D";

        result = mainGame.currentSymbol.CompareCode(keycode, mainGame.currentCodeKey);
        switch (result)
        {
            case Result.CodeCorrect:
                SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_correct);
                break;
            case Result.CodeWrong:
                CheckSymbolWrong();
                SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_wrong);
                break;
            case Result.SequenceCorrect:
                SequenseSymbolCorrect();
                SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_sequence_complete);
                break;
        }
    }

    private void CheckSymbolWrong()
    {
        isRunning = false;
        result = Result.SequenceWrong;
        character.UpdateCharacterSequenceStatus("Wrong");

        StartCoroutine(Utils.DelayEvent(() =>
        {
            isRunning = true;
            mainGame.ResetCompareSymbol();
        }, 0f));
    }

    private void SequenseSymbolCorrect()
    {
        finishSequence = true;
        character.UpdateCharacterSequenceStatus("Correct");
    }

    private bool GetKeyDown(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }


    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
        character = Character.Instance;
        enemy = Enemy.Instance;
    }

}
