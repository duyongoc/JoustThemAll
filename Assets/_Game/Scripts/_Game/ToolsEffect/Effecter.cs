using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effecter : MonoBehaviour
{

    //
    //= public 
    public bool hasTrigger = false;
    public float effectDuration = 0.2f;

    public float _effectStartTime = 0f;


    #region UNITY
    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        if (hasTrigger)
        {
            UpdateEffect();
        }

        if (hasTrigger && Time.time - _effectStartTime > effectDuration)
        {
            EffectComplete();
            hasTrigger = false;
        }
    }
    #endregion


    protected virtual void StartEffect()
    {
        hasTrigger = true;
        _effectStartTime = Time.time;
    }

    public virtual void UpdateEffect()
    {

    }

    public virtual void EffectComplete()
    {

    }


}
