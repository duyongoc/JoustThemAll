using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BodyPanel : MonoBehaviour
{

    //
    //= inspector 
    [SerializeField] private TMP_Text textChacterSequenceStatus;
    [SerializeField] private TMP_Text textEnemySequenceStatus;


    #region UNITY
    private void Start()
    {
    }

    private void Update()
    {
    }
    #endregion


    public void SetChacterSequenceStatus(string status)
    {
        textChacterSequenceStatus.text = status.ToString();
    }

    public void SetEnemySequenceStatus(string status)
    { 
        textEnemySequenceStatus.text = status.ToString();
    }


}
