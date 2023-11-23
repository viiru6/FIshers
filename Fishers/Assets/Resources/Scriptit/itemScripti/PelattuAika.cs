using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelattuAika : MonoBehaviour
{
    public Stats Stats;
    private void Start()
    {
        StartCoroutine("PlayTimer");
    }
    private IEnumerator PlayTimer()//laskee pelatun ajan tunneissa
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Stats.AikaPelattuSekunnit += 1;
            Stats.AikaPelattuTunnit = (Stats.AikaPelattuSekunnit / 3600);
        }
    }
}

