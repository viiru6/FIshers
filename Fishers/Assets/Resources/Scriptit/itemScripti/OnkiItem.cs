using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new OnkiItem")]
public class OnkiItem : ScriptableObject
{
    public string itemName;
    public string id;
    [Tooltip("Matalempi = parempi")]
    public float power;
    public float cooldown;
}
