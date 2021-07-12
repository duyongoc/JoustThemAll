using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObject : MonoBehaviour
{

    //
    //= private 



    #region UNITY
    private void Start()
    {
        CacheComponent();
    }

    // private void Update()
    // {
    // }
    #endregion

    public void TextDestroy(float timer)
    {
        Destroy(gameObject, timer);
    }

    private void CacheComponent()
    {
    }


}
