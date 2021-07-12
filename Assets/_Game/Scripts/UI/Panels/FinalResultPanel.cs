using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalResultPanel : MonoBehaviour
{

    //
    //= private 
    [SerializeField] private GameObject textVictory;
    [SerializeField] private GameObject textDefected;


    #region UNITY
    private void Start()
    {
        textVictory.SetActive(false);
        textDefected.SetActive(false);
    }

    // private void Update()
    // { 
    // }
    #endregion


    public void ShowTextVictory()
    {
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_Victory);
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_crowd);
        textVictory.SetActive(true);
        textDefected.SetActive(false);
    }

    public void ShowTextDefeated()
    {
        textVictory.SetActive(false);
        textDefected.SetActive(true);
    }


}
