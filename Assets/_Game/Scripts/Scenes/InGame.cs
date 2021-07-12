using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGame : StateScene
{

    //
    //= inspector
    [Header("Panel")]
    [SerializeField] private PowerClashPanel powerClashPanel;
    [SerializeField] private FinalResultPanel resultPanel;

    [Header("Text Pro")]
    [SerializeField] private TMP_Text txtGameRound;
    [SerializeField] private GameObject iconReward;
    [SerializeField] private Transform characterReward;
    [SerializeField] private Transform enemyReward;

    [Space(10)]
    [SerializeField] private Text textResult;


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


    public void ChangeRoundGame(int round, float timer)
    {
        if (round == mainGame.gameRound - 1)
        {
            ChangeRoundText(round);
            Common.CreateTextRound("TextRoundFinal", timer);
            return;
        }

        Common.CreateTextRound("TextRound" + round.ToString(), timer);
        ChangeRoundText(round);
    }

    public void ChangeRoundText(int round)
    {
        txtGameRound.text = round + "/" + (mainGame.gameRound - 1).ToString();
    }

    public void UpdateRewardCharacter()
    {
        var icon = Instantiate(iconReward, characterReward);
    }

    public void UpdateRewardEnemy()
    {
        var icon = Instantiate(iconReward, enemyReward);
    }

    public void ResetReward()
    {
        foreach (Transform child in characterReward.transform)
            Destroy(child.gameObject);
        foreach (Transform child in enemyReward.transform)
            Destroy(child.gameObject);
    }

    public void ShowPowerClashPanel(bool value)
    {
        powerClashPanel.gameObject.SetActive(value);
    }

    public void ShowResultPanel(bool value, int resultRound)
    {
        resultPanel.gameObject.SetActive(value);
        if (resultRound == 1)
        {
            resultPanel.gameObject.SetActive(true);
            resultPanel.ShowTextVictory();
            SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_Victory);
            GameMgr.Instance.DelayEvent(() =>
            {
                Enemy.Instance.ResetSkinEnemy();
                resultPanel.gameObject.SetActive(false);
                GameMgr.Instance.LoadSceneMap();
            }, 2);
        }
        else if (resultRound == -1)
        {
            resultPanel.gameObject.SetActive(true);
            resultPanel.ShowTextDefeated();
            GameMgr.Instance.DelayEvent(() =>
            {
                Enemy.Instance.ResetSkinEnemy();
                resultPanel.gameObject.SetActive(false);
                GameMgr.Instance.LoadSceneMap();
            }, 2);
        }
    }

    private void CacheDefine()
    {
        powerClashPanel.gameObject.SetActive(false);
        resultPanel.gameObject.SetActive(false);
    }

    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
    }

}
