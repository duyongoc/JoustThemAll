using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHelp : MonoBehaviour
{
    //
    //= inspector
    [SerializeField] private GameObject tutorialOne;
    [SerializeField] private GameObject tutorialTwo;


    #region UNITY
    private void Start()
    {
        ActiveTutorial("None");
    }

    // private void Update()
    // { 
    // }
    #endregion


    private void ActiveTutorial(string name)
    {
        tutorialOne.SetActive(tutorialOne.name.Contains(name));
        tutorialTwo.SetActive(tutorialTwo.name.Contains(name));
    }

    public void InitTutorial()
    {
        ActiveTutorial("One");
    }


    public void OnClickButtonSkipOne()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        ActiveTutorial("Two");
    }

    public void OnClickButtonSkipTwo()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_button_click);
        ActiveTutorial("None");
    }

}
