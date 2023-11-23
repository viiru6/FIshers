using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new SyöttiItem")]
public class SyöttiItem : ScriptableObject
{
    public int id;
    public string itemName;
    [Tooltip("Syötinteho prosenteissa.\n(eli 50% meinaa että 50% todennäköisyys saada kaksi kalaa)")] 
    public float syötinTeho = 1;
}
