using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : StateScene
{

    //
    //= inspector
    [Header("Button")]
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnQuit;


    #region UNITY
    private void Start()
    {
        btnPlay.onClick.AddListener(OnClickButtonPlay);
        btnQuit.onClick.AddListener(OnClickButtonExit);
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


    private void OnClickButtonPlay()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        GameMgr.Instance.LoadSceneMap();
    }

    private void OnClickButtonExit()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        Application.Quit();
    }


}
