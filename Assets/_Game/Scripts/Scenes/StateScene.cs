using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScene : MonoBehaviour
{

    [HideInInspector] public GameMgr ower;

    public virtual void StartState() { }
    public virtual void UpdateState() { }
    public virtual void EndState() { }

}
