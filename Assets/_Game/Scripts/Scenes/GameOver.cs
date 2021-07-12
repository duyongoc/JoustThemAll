using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : StateScene
{

    //
    //= inspector
    [SerializeField] private Button btnReplay;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnQuit;


    #region UNITY
    private void Start()
    {
        btnReplay.onClick.AddListener(OnClickButtonReplay);
        btnMenu.onClick.AddListener(OnClickButtonMenu);
        btnQuit.onClick.AddListener(OnClickButtonQuit);
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


    private void OnClickButtonReplay()
    {
        GameMgr.Instance.LoadReplayGame();
    }

    private void OnClickButtonMenu()
    {
        GameMgr.Instance.LoadSceneMenu();
    }

    private void OnClickButtonQuit()
    {
        Application.Quit();
    }
}
