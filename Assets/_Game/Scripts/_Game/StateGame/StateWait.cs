using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWait : GameState
{

    //
    //= inspector
    [SerializeField] private float timeDelay = 1f;


    //
    //= private 
    private MainGame mainGame;


    #region UNITY
    private void Start()
    {
        CacheComponent();
        CacheDefine();
    }

    // private void Update()
    // {
    // }
    #endregion


    #region STATE
    public override void StartState()
    {
        base.EndState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void EndState()
    {
        base.EndState();
        // BackgroundMgr.Instance.ResetWaitScreen();
    }
    #endregion


    public void WaitingWithResult(Result result)
    {
        BackgroundMgr.Instance.TriggerWaitScreen();
        GameMgr.Instance.DelayEvent(() =>
        {
            OnResult(result);
        }, timeDelay);
    }

    private void OnResult(Result result)
    {
        switch (result)
        {
            case Result.SequenceCorrect:
                print("CheckCharacterSequenceCorrect");
                mainGame.CheckCharacterSequenceCorrect();
                break;
            case Result.SequenceWrong:
                print("CheckCharacterSequenceWrong");
                mainGame.CheckCharacterSequenceWrong();
                break;
        }
    }


    private void CacheDefine()
    {
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    }

}
