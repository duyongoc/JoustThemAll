using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerClashPanel : MonoBehaviour
{

    //
    //= public
    [Header("Text")]
    public Slider sliderTimer;
    public TMP_Text textCharacterCount;
    public TMP_Text textEnemyCount;
    public TMP_Text textResult;


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

    public void ChangeSliderValue(float value)
    {
        sliderTimer.value = value;
    }

    public void ChangeSliderMaxValue(float value)
    {
        sliderTimer.maxValue = value;
    }

    public void ShowResult(string result, bool value)
    {
        textResult.text = result;
    }

    public void ChangeTextCharacterTap(string value)
    {
        textCharacterCount.text = value;
    }

    public void ChangeTextEnemyTap(string value)
    {
        textEnemyCount.text = value;
    }

    private void OnClickButtonResult()
    {
        mainGame.SetStateNone();
    }

    private void CacheDefine()
    {
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    }

}
