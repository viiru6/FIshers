using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [SerializeField] [Tooltip("Kalastuksen cooldown")] private float cooldownTime;
    private float _nextclicktime;
    public bool isCoolingdown => Time.time < _nextclicktime;
    public void StartCooldown() => _nextclicktime = Time.time + cooldownTime;
}
