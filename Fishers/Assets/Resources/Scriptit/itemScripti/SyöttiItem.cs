using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new SyöttiItem")]
public class SyöttiItem : ScriptableObject
{
    public int id;
    public string itemName;
    [Tooltip("Syötinteho prosenteissa")] public float syötinTeho = 1;
}
