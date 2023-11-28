using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class VuorokausiRytmi : MonoBehaviour
{
    public Stats Stats;

    public TextMeshProUGUI timeDisplayText;
    public TextMeshProUGUI dayDisplayText;
    public Volume ppv;

    public float tick;
    public static float seconds;
    public static int mins = 59;
    public static int hours = 7;
    public int days = 1;

    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();//etsii yö efekti voluumin
    }
    void FixedUpdate()
    {
        CalcTime();
        DisplayTime();
    }
    public void CalcTime()//laskee sekunnit minuutit ja tunnit
    {
        seconds += Time.fixedDeltaTime * tick;

        if (seconds >= 60)
        {
            seconds = 0;
            mins += 1;
            Stats.aikaSekuntteina++;
        }
        if (mins >= 60)
        {
            mins = 0;
            hours += 1;
        }
        if (hours >= 24)
        {
            hours = 0;
            days += 1;
            Stats.päivätPelattu++;
        }
        ControlPPV();
    }
    public void ControlPPV() //säätää yö efekti voluumin arvoa Weight jotta yö efektin voimakkuus/paino on oikea
    {
        if (hours >= 21 && hours < 22)
        {
            ppv.weight = (float)mins / 60;
        }
        if (hours >= 6 && hours < 7)
        {
            ppv.weight = 1 - (float)mins / 60;
        }
    }
    public void DisplayTime()//formatoi ja näyttää kellon ja päivän pelaajalle
    {
        timeDisplayText.text = string.Format("Kello {0:00}:{1:00}", hours, mins);
        dayDisplayText.text = "Päivä: " + Stats.päivätPelattu;
    }
}