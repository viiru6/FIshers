using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new KalaItem")]
public class KalaItem : ScriptableObject
{
    public int id;
    public string itemName;
    public Color color;
    [Tooltip("Kaikki pienellä")] public string rarity;
    public int value;
    public int currentStack = 1;
    public int startTime = 0;
    public int endTime = 24;

    public float weight = 0;
    public float minWeight = 0.001f;
    public float maxWeight = 100f;
}
