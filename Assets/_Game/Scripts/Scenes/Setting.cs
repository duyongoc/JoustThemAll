using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : StateScene
{
    
    //
    //= inspector
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnQuit;


    #region UNITY
    private void Start()
    {
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


    private void OnClickButtonMenu()
    {
        GameMgr.Instance.LoadSceneMenu();
    }

    private void OnClickButtonQuit()
    {
        Application.Quit();
    }

}
