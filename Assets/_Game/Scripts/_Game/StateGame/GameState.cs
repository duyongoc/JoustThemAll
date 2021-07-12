using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    
    // [HideInInspector] public GameController gameController;

    public virtual void StartState() { }
    public virtual void UpdateState() { }
    public virtual void EndState() { }

}
