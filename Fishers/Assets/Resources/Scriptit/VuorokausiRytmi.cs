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
    public float seconds;
    public int mins;
    public int hours = 6;
    public int days = 1;

    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }
    void FixedUpdate()
    {
        CalcTime();
        DisplayTime();
    }
    public void CalcTime()
    {
        seconds += Time.fixedDeltaTime * tick;

        if (seconds >= 60)
        {
            seconds = 0;
            mins += 1;
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
    public void ControlPPV() //säätää yö efekti voluumin arvoa Weight jotta yö efektin voimakkuus on oikea
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

    public void DisplayTime()
    {
        timeDisplayText.text = string.Format("Kello {0:00}:{1:00}", hours, mins);
        dayDisplayText.text = "Päivä: " + days;
    }
}