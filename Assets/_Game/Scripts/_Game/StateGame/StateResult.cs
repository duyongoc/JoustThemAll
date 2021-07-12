using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateResult : GameState
{

    //
    //= inspector
    [SerializeField] private FinalResultPanel finalResultPanel;
    [SerializeField] private float delayTimeClash = 1f;


    //
    //= private 
    private MainGame mainGame;


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
        CheckRoundResult();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void EndState()
    {
        base.EndState();

    }
    #endregion


    private void CheckRoundResult()
    {
        switch (mainGame.GetResultRound)
        {
            case Result.Finish:
                mainGame.ShowFinalRound(); break;

            case Result.YouWin:
                mainGame.OnCharacterAttack();
                break;

            case Result.YouLose:    //enemy win
                mainGame.OnEnemyAttack();
                break;

            case Result.Clash:      //game clash
                LoadPowerClash(); break;
        }
    }

    private void LoadPowerClash()
    {
        GameMgr.Instance.DelayEvent(() => { mainGame.SetStateClash(); }, delayTimeClash);
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    }

}
