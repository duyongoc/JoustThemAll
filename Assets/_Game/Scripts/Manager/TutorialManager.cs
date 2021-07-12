using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : Singleton<TutorialManager>
{

    public enum STATE
    {
        Start,
        Normal,
        Reverse,
        Hidden,
        Finish,
        None
    }


    //
    //= public
    [Header("STATE")]
    public STATE state = STATE.None;
    [SerializeField] private Tutorial tutorial;
    [SerializeField] private BoardTutorial boardTutorial;
    public Symbol currentSymbol;
    public List<CodeKey> currentCodeKey;

    [Header("Data")]
    public Symbol easySymbol;
    public Symbol mediumSymbol;
    public Symbol hardSymol;


    //
    //= private 
    private Result result;



    #region 
    // private void Start()
    // {
    // }

    private void Update()
    {
        if (!GameMgr.Instance.IsTutorialState)
            return;


    }
    #endregion

    public void Init()
    {
        SetState(STATE.Start);
    }

    public void UpdateTutorial()
    {
        switch (state)
        {
            case STATE.Start:
                OnStateStart();
                break;
            case STATE.Normal:
                OnStateNormal();
                break;
            case STATE.Reverse:
                OnStateReverse();
                break;
            case STATE.Hidden:
                OnStateHidden();
                break;
            case STATE.None:
                break;
        }
    }

    private void OnStateStart()
    {

    }

    private void OnStateNormal()
    {

    }

    private void OnStateReverse()
    {

    }

    private void OnStateHidden()
    {

    }


    public void CheckUserInput()
    {
        if (Input.anyKeyDown)
        {
            if (CheckSpecialButtonPress()) //CompareKeyHidden
                return;

            CheckTheSymbol();
        }
    }

    public void CheckTheSymbol()
    {
        string keycode = "0";
        if (GetKeyDown(KeyCode.W) || GetKeyDown(KeyCode.UpArrow)) keycode = "W";
        else if (GetKeyDown(KeyCode.A) || GetKeyDown(KeyCode.LeftArrow)) keycode = "A";
        else if (GetKeyDown(KeyCode.S) || GetKeyDown(KeyCode.DownArrow)) keycode = "S";
        else if (GetKeyDown(KeyCode.D) || GetKeyDown(KeyCode.RightArrow)) keycode = "D";

        result = currentSymbol.CompareCode(keycode, currentCodeKey);
        switch (result)
        {
            case Result.CodeCorrect: break;
            case Result.CodeWrong: CheckSymbolWrong(); break;
            case Result.SequenceCorrect: CheckSymbolCorrect(); break;
        }
    }

    private void CheckSymbolWrong()
    {
        result = Result.SequenceWrong;
        StartCoroutine(Utils.DelayEvent(() => { currentSymbol.ResetCompare(currentCodeKey); }, 1f));
    }

    private void CheckSymbolCorrect()
    {
        switch (state)
        {
            case STATE.Normal:
                StartCoroutine(Utils.DelayEvent(() => { SetState(STATE.Reverse); }, 1f));
                break;
            case STATE.Reverse:
                StartCoroutine(Utils.DelayEvent(() => { SetState(STATE.Hidden); }, 1f));
                break;
            case STATE.Hidden:
                StartCoroutine(Utils.DelayEvent(() => { SetState(STATE.Finish); }, 1f));
                break;
        }
    }

    public void SetState(STATE newState)
    {
        state = newState;
        switch (state)
        {
            case STATE.Start:
                tutorial.ActivePanelTutorial("Start");
                break;
            case STATE.Normal:
                currentSymbol = easySymbol;
                tutorial.ActivePanelTutorial("Normal");
                break;
            case STATE.Reverse:
                currentSymbol = mediumSymbol;
                tutorial.ActivePanelTutorial("Reverse");
                break;
            case STATE.Hidden:
                currentSymbol = hardSymol;
                tutorial.ActivePanelTutorial("Hidden");
                break;
            case STATE.Finish:
                GameMgr.Instance.LoadSceneMap();
                break;
        }

        currentCodeKey = boardTutorial.CreateListCodeKey(currentSymbol);
    }


    private bool GetKeyDown(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }

    public bool CheckSpecialButtonPress()
    {
        return Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2);
    }



}
