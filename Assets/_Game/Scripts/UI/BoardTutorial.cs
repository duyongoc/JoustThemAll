using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardTutorial : MonoBehaviour
{
    
    //
    //= inspector
    [Header("Show UI")]
    [SerializeField] private GameObject board;
    [SerializeField] private Slider sliderTimer;
    [SerializeField] private CodeKey prefabCodeKey;
    [Space(15)]
    [SerializeField] private Transform textParent;
    [SerializeField] private TextContent textContent;


    //
    //public 
    public List<CodeKey> codeKeyBoard;


    //
    //= private 
    private MainGame mainGame;
    private bool roundRunning = false;


    #region UNITY
    private void Start()
    {
        CacheComponent();
        CacheDefine();
    }

    private void Update()
    {
        if (!GameMgr.Instance.IsInGameState)
            return;

        UpdateBoardGame();
    }
    #endregion

    private void UpdateBoardGame()
    {
        CountDownTimer();
    }

    private void CountDownTimer()
    {
        if (roundRunning)
        {
            sliderTimer.value += Time.deltaTime;
        }
    }

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
        return codeKeyBoard;
    }

    public void DeleteListCodeKey()
    {
        foreach (var item in codeKeyBoard)
            Destroy(item.gameObject);
        codeKeyBoard.Clear();
    }

    public void StartSlider()
    {
        roundRunning = true;
    }

    public void FinishSlider()
    {
        roundRunning = false;
    }

    public void ResetRound(List<CodeKey> listKeyItem)
    {
        foreach (var codeKey in listKeyItem)
            codeKey.ResetDefaultKeyShape();

        SetValueSliderTimer(0);
    }

    public void SetValueSliderTimer(float value)
    {
        sliderTimer.maxValue = mainGame.roundTimer;
        sliderTimer.value = 0;
    }

    public void ShowTextContent(string content, float speed, float time)
    {
        var strText = Instantiate(textContent, textParent.position, Quaternion.identity, transform);
        strText.Init(content, speed, time);
    }

    private void CacheDefine()
    {
        sliderTimer.maxValue = mainGame.roundTimer;
        sliderTimer.value = 0;
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    }

}
