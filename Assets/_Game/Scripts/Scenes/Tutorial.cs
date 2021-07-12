using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : StateScene
{

    //
    //= inspector
    [Header("Tutorial")]
    [SerializeField] private GameObject tutoStart;
    [SerializeField] private GameObject tutoNormal;
    [SerializeField] private GameObject tutoReverse;
    [SerializeField] private GameObject tutoHidden;

    //
    //= private
    private TutorialManager tutorialManager;


    #region UNITY
    private void Start()
    {
        tutorialManager = TutorialManager.Instance;
    }

    // private void Update()
    // {
    // }
    #endregion


    #region STATE
    public override void StartState()
    {
        base.EndState();
        TutorialManager.Instance.Init();
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


    public void ActivePanelTutorial(string name)
    {
        tutoStart.gameObject.SetActive(tutoStart.name.Contains(name));
        tutoNormal.gameObject.SetActive(tutoNormal.name.Contains(name));
        tutoReverse.gameObject.SetActive(tutoReverse.name.Contains(name));
        tutoHidden.gameObject.SetActive(tutoHidden.name.Contains(name));
    }

    public void OnClickButtonSkipStart()
    {
        tutorialManager.SetState(TutorialManager.STATE.Normal);
    }

    public void OnClickButtonSkipNormal()
    {
        // tutorialManager.SetState(TutorialManager.STATE.Reverse);
    }

    public void OnClickButtonSkipReverse()
    {
        // tutorialManager.SetState(TutorialManager.STATE.Hidden);
    }

    public void OnClickButtonSkipHidden()
    {
        // tutorialManager.SetState(TutorialManager.STATE.Finish);
    }



}
