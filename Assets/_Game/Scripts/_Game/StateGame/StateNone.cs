using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNone : GameState
{

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
    }
    #endregion


    private void CacheDefine()
    {
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    } 

}
