
using System.Collections;
using UnityEngine;

public class Common : MonoBehaviour
{

    public static void CreateText(string name, float timeDestroy)
    {
        var txtReady = (GameObject)Instantiate(Resources.Load("Text" + "/" + name), TextPos.Instance.transform);
        txtReady.GetComponent<TextObject>().TextDestroy(timeDestroy);
    }

    public static void CreateTextRound(string name, float timeDestroy)
    {
        var txtReady = (GameObject)Instantiate(Resources.Load("Text" + "/" + name), TextRound.Instance.transform);
        txtReady.GetComponent<TextObject>().TextDestroy(timeDestroy);
    }

}
