using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest")]
public class QuestItem : ScriptableObject
{
    public int id;
    public string desc;
    public int criteriaNeeded;
    public int criteriaCurrent;
    //[HideInInspector]
    public int questReward;
    public int startHour = 0;
    public int endHour = 24;
    [Tooltip("esim. <color=#FF00FF>liila</color>")]
    public string displaydRarity = "<color=#FF00FF>liila</color>";
    [Tooltip("esim. liila")]
    public string rarity = "liila";
    public bool QuestIsActive;
    public bool anyRarity;
}
