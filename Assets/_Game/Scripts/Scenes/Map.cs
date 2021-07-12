using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : StateScene
{
    //
    //= inspector
    [Header("Button")]
    [SerializeField] private TutorialHelp tutorialHelp;

    [Header("Button")]
    [SerializeField] private Button btnEasy;
    [SerializeField] private Button btnMedium;
    [SerializeField] private Button btnHard;

    [Space(10)]
    [SerializeField] private Button btnTutorial;
    [SerializeField] private Button btnHelp;
    [SerializeField] private Button btnBack;


    #region UNITY
    private void Start()
    {
        btnTutorial.onClick.AddListener(OnClickButtonTutorial);
        btnEasy.onClick.AddListener(OnClickButtonEasy);
        btnMedium.onClick.AddListener(OnClickButtonMedium);
        btnHard.onClick.AddListener(OnClickButtonHard);

        btnHelp.onClick.AddListener(OnClickButtonHelp);
        btnBack.onClick.AddListener(OnClickButtonBack);
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


    private void OnClickButtonTutorial()
    {
        GameMgr.Instance.LoadSceneTutorial();
    }

    private void OnClickButtonEasy()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        GameMgr.Instance.LoadSceneInGame(Rarity.Low);
    }

    private void OnClickButtonMedium()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        GameMgr.Instance.LoadSceneInGame(Rarity.Medium);
    }

    private void OnClickButtonHard()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        GameMgr.Instance.LoadSceneInGame(Rarity.High);
    }

    private void OnClickButtonBack()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        GameMgr.Instance.LoadSceneMenu();
    }

    private void OnClickButtonHelp()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        tutorialHelp.InitTutorial();
    }


}
