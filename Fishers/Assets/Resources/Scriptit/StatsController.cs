using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public Stats Stats;
    public void ResetStats()
    {
        Stats.KalojaKer�ttyHarmaa = 0;
        Stats.KalojaKer�ttyVihre� = 0;
        Stats.KalojaKer�ttySininen = 0;
        Stats.KalojaKer�ttyLiila = 0;
        Stats.KalojaKer�ttyKultainen = 0;
        Stats.KalojaKer�ttyYhteens� = 0;
        Stats.KerratKalastettu = 0;
        Stats.RahaaTienattuYhteens� = 0;
        Stats.KerratMyyty = 0;
    }
}
