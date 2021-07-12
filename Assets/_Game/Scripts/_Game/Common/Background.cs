using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    //
    //= public 
    public GameObject quadGameObject;
    public float scrollSpeed = 5f;
    public bool isScroll = true;

    private Material _material;


    #region
    private void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if(!isScroll)
            return;

        Vector2 textureOffset = new Vector2(Time.time * scrollSpeed, 0);
        _material.mainTextureOffset = textureOffset;
    }
    #endregion

}
