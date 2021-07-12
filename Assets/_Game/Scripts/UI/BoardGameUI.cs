using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardGameUI : MonoBehaviour
{

    //
    //= inspector
    [Header("Show UI")]
    [SerializeField] private GameObject board;
    [SerializeField] private Slider sliderTimer;
    [SerializeField] private CodeKey prefabCodeKey;
    [Space(15)]
    [SerializeField] private Transform textParent;
    [SerializeField] private TextContent textFailed;
    [SerializeField] private TextContent textSuccess;


    //
    //public 
    public List<CodeKey> codeKeyBoard;


    //
    //= private 
    private MainGame mainGame;



    #region UNITY
    private void Start()
    {
        CacheComponent();
        CacheDefine();
    }

    // private void Update()
    // {
    // }
    #endregion

    public List<CodeKey> CreateListCodeKey(Symbol symbol)
    {
        DeleteListCodeKey();

        int length = symbol.codes.Count;
        for (int i = 0; i < length; i++)
        {
            CodeKey codeKey = Instantiate(prefabCodeKey, board.transform);
            codeKey.InitCode(symbol.codes[i]);
            codeKeyBoard.Add(codeKey);
        }

        board.SetActive(true);
        board.GetComponent<RectTransform>().sizeDelta = new Vector2(45 * codeKeyBoard.Count, 40);
        return codeKeyBoard;
    }

    public void DeleteListCodeKey()
    {
        foreach (var item in codeKeyBoard)
            Destroy(item.gameObject);
        codeKeyBoard.Clear();
    }

    public void ResetRound(List<CodeKey> listKeyItem)
    {
        foreach (var codeKey in listKeyItem)
            codeKey.ResetDefaultKeyShape();

        SetValueSliderTimer(0);
    }

    public void CountDownSliderTime(float value)
    {
        sliderTimer.value += value;
    }

    public void SetValueSliderTimer(float value)
    {
        sliderTimer.maxValue = mainGame.roundTimer;
        sliderTimer.value = 0;
    }

    // public void ShowTextFailed( float speed, float time)
    // {
    //     var strText = Instantiate(textFailed, textParent.position, Quaternion.identity, transform);
    //     strText.Init("", speed, time);
    // }

    // public void ShowTextSuccess( float speed, float time)
    // {
    //     var strText = Instantiate(textSuccess, textParent.position, Quaternion.identity, transform);
    //     strText.Init("", speed, time);
    // }

    private void CacheDefine()
    {
        board.SetActive(false);
        sliderTimer.maxValue = mainGame.roundTimer;
        sliderTimer.value = 0;
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    }


}
