using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitPanel : MonoBehaviour
{
    
    //
    //= public
    [Header("Text")]
    public Text textGo;


    //
    //= private 
    private MainGame mainGame;


    #region UNTIY
    private void Start()
    {
        CacheComponent();
        CacheDefine();
    }

    // private void Update()
    // {
    // }
    #endregion

    
    public void ShowTextGo(bool value)
    {
        textGo.gameObject.SetActive(value);
    }


    private void CacheDefine()
    {
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    }

}
