using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public Stats Stats;
    public void ResetStats()
    {
        Stats.KalojaKerättyHarmaa = 0;
        Stats.KalojaKerättyVihreä = 0;
        Stats.KalojaKerättySininen = 0;
        Stats.KalojaKerättyLiila = 0;
        Stats.KalojaKerättyKultainen = 0;
        Stats.KalojaKerättyYhteensä = 0;
        Stats.KerratKalastettu = 0;
        Stats.RahaaTienattuYhteensä = 0;
        Stats.KerratMyyty = 0;
    }
}
