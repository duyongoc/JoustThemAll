using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeKey : MonoBehaviour
{

    //
    //= enum
    public enum Arrow
    {
        Up,
        Left,
        Down,
        Right
    }

    public enum KeyShape
    {
        Normal,
        Reverse,
        Hidden,
        Correct,
        None
    }


    //
    //= public
    public Arrow arrow;
    [SerializeField] private Image iconKey;

    [Header("Arrows")]
    [SerializeField] private Sprite[] normalArrow;
    [SerializeField] private Sprite[] reverseArrow;
    [SerializeField] private Sprite[] hiddenArrow;
    [SerializeField] private Sprite[] correctArrow;


    //
    //= inspector 
    private Code mCode;
    private Animator animator;
    private KeyShape defaultKeyShape;

    public Code GetCode { get => mCode; }


    #region UNITY
    private void Start()
    {
        CacheComponent();
    }

    // private void Update()
    // {
    // }
    #endregion


    public void InitCode(Code newCode)
    {
        mCode = newCode;
        ChangeBackground();
    }

    private void SetArrow(string key)
    {
        switch (key)
        {
            case "W": arrow = Arrow.Up; break;
            case "A": arrow = Arrow.Left; break;
            case "S": arrow = Arrow.Down; break;
            case "D": arrow = Arrow.Right; break;
        }
    }

    private void ChangeBackground()
    {
        if (mCode.isKeyHidden)
        {
            SetArrow(mCode.keyHidden.GetCurrentKey());
            ChangeKeyShape(KeyShape.Hidden);
            defaultKeyShape = KeyShape.Hidden;
        }
        else if (mCode.isKeyReverse)
        {
            SetArrow(mCode.key);
            ChangeKeyShape(KeyShape.Reverse);
            defaultKeyShape = KeyShape.Reverse;
        }
        else
        {
            SetArrow(mCode.key);
            ChangeKeyShape(KeyShape.Normal);
            defaultKeyShape = KeyShape.Normal;
        }
    }

    public void ChangeKeyShape(KeyShape keyShape)
    {
        switch (keyShape)
        {
            case KeyShape.Normal:
                iconKey.sprite = normalArrow[((int)arrow)];
                break;
            case KeyShape.Reverse:
                SetArrow(mCode.key);
                iconKey.sprite = reverseArrow[((int)arrow)];
                break;
            case KeyShape.Hidden:
                iconKey.sprite = hiddenArrow[((int)arrow)];
                break;
            case KeyShape.Correct:
                iconKey.sprite = correctArrow[((int)arrow)];
                break;
            case KeyShape.None:
                break;
        }
    }

    public void ChangeCorrectKeyShape()
    {
        ChangeKeyShape(KeyShape.Correct);
    }

    public void ChangeCorrectKeyRevert()
    {
        SetArrow(mCode.keyReserve);
        ChangeKeyShape(KeyShape.Correct);
    }

    public void CheckCorrectHiddenKey()
    {
        animator.SetTrigger("HiddenCorrect");
        SetArrow(mCode.keyHidden.GetCurrentKey());
        ChangeKeyShape(KeyShape.Hidden);
    }

    public void ChangeWrongKeyShape()
    {
        animator.SetTrigger("Wrong");
    }

    public void ResetDefaultKeyShape()
    {
        ChangeKeyShape(defaultKeyShape);
    }


    private void CacheComponent()
    {
        animator = GetComponent<Animator>();
    }

}
