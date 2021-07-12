using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Setting/Level")]
public class LevelSettingSO : ScriptableObject
{
    [Header("List keypad")]
    public string[] keypadList;

}
