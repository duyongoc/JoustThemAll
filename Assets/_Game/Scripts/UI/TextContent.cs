using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextContent : MonoBehaviour
{
    
    //
    //= inspector
    [SerializeField] private Image image;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeDestroy = 2f;


    //
    //= private 
    private bool isMove = false;


    #region UNITY
    private void Start()
    {
        CacheDefine();
    }

    private void Update()
    {
        if (isMove)
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }
    #endregion


    public void Init(string content, float speed, float time)
    {
        moveSpeed = speed;
        timeDestroy = time;
        isMove = true;
    }


    public void ShowText(float damage)
    {
    }


    private void CacheDefine()
    {
        image.DOFade(0, timeDestroy).OnComplete(() => Destroy(gameObject));
    }

    // private void CacheComponent()
    // {
    //     textContent.GetComponentInChildren<TMP_Text>();
    // }

}
