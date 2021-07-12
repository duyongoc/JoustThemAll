using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInit : GameState
{

    //
    //= inspector
    [SerializeField] private InitPanel initPanel;
    [SerializeField] private float delayTime;


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
        LoadInit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void EndState()
    {
        base.EndState();
        Common.CreateText("TextGo", 1f);

        mainGame.FirstPlayGame();
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_clash);
    }
    #endregion


    private void LoadInit()
    {
        Common.CreateText("TextReady", delayTime);
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_game_start);
        GameMgr.Instance.DelayEvent(() => { mainGame.SetStateTyping(); }, delayTime);

        mainGame.GetEnemy.InitEnemy();
        mainGame.GetCharacter.InitCharacter();
        BackgroundMgr.Instance.StopScrolling();
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    }


}
