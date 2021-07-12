using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMgr : Singleton<BackgroundMgr>
{


    //
    //= inspector
    [Header("Background")]
    [SerializeField] private Background leftBackground;
    [SerializeField] private Background rightBackground;

    [Header("Wait screen")]
    [SerializeField] private GameObject originBackground;
    [SerializeField] private SpriteRenderer fakeCharacter;
    [SerializeField] private SpriteRenderer fakeEnemy;
    [SerializeField] private GameObject splitScreen;
    [SerializeField] private Image fakeTransfer;


    #region UNITY
    private void Start()
    {
        originBackground.SetActive(false);
    }

    // private void Update()
    // {
    // }
    #endregion


    public void StartScrolling()
    {
        splitScreen.SetActive(true);
        leftBackground.isScroll = true;
        rightBackground.isScroll = true;
    }

    public void StopScrolling()
    {
        leftBackground.isScroll = false;
        rightBackground.isScroll = false;
    }

    public void TriggerWaitScreen()
    {
        fakeTransfer.gameObject.SetActive(true);
        fakeTransfer.DOFade(1, 0);
        fakeTransfer.DOFade(0, 1.5f);
        FakeSprite();

        originBackground.SetActive(true);
        splitScreen.SetActive(false);
    }

    public void ResetWaitScreen()
    {
        StopScrolling();
        originBackground.SetActive(false);
        splitScreen.SetActive(true);
    }

    public void FakeSprite()
    {
        fakeCharacter.sprite = Character.Instance.bodyCharacter.GetComponent<SpriteRenderer>().sprite;
        fakeEnemy.sprite = Enemy.Instance.bodyEnemy.GetComponent<SpriteRenderer>().sprite;

        fakeCharacter.DOFade(0, 1.5f);
        fakeEnemy.DOFade(0, 1.5f);

        fakeCharacter.transform.DOScale(new Vector2(-2, 2), 1.5f).OnComplete(() =>
        {
            fakeCharacter.transform.localScale = new Vector3(-1, 1, 1);
        });
        fakeEnemy.transform.DOScale(new Vector2(2, 2), 1.5f).OnComplete(() =>
        {
            fakeEnemy.transform.localScale = new Vector3(1, 1, 1);
        });

    }


}
