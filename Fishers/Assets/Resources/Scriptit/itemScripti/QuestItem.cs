using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest")]
public class QuestItem : ScriptableObject
{
    public int id;
    public string desc;
    [HideInInspector]
    public string descInfo = "({0}) {1}/{2} {3}";//("nappaa kaloja", 0 = displaydRarity, 1 = criteriaCurrent, 2 = criteriaNeeded, 3 = questReward)
    public int criteriaNeeded;
    public int criteriaCurrent;
    public int questReward;
    public int startHour = 0;
    public int endHour = 24;
    [Tooltip("esim. <color=#FF00FF>liila</color>")]
    public string displaydRarity = "<color=#värikoodi></color>";
    [Tooltip("esim. liila")]
    public string rarity;
    public bool QuestIsActive;
    public bool anyRarity;
}
