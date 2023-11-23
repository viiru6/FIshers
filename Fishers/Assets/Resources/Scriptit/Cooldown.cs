using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [SerializeField] [Tooltip("Kalastuksen cooldown")] private float CooldownTime;
    private float _nextclicktime;
    public bool isCoolingdown => Time.time < _nextclicktime;//kun on kulunut yli cooldownin keston: isCoolingdown = true
    public void StartCooldown() => _nextclicktime = Time.time + CooldownTime; //seuraava klikkaus = aika siitö lähtien kun cooldown aloitettiin + cooldownin kesto
}
