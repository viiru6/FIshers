using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rahanpv : MonoBehaviour
{
    public int raha;
    public TextMeshProUGUI rahaTeksti;

    void Start()
    {
        raha = 100;
        P‰ivit‰RahaTeksti();
    }

    public void Lis‰‰Rahaa(int m‰‰r‰)
    {
        raha += m‰‰r‰;
        P‰ivit‰RahaTeksti();
    }

    public void V‰henn‰Rahaa(int m‰‰r‰)
    {
        if (raha - m‰‰r‰ >= 0)
        {
            raha -= m‰‰r‰;
            P‰ivit‰RahaTeksti();
        }
        else
        {
            Debug.Log("Ei ole tarpeeksi rahaa!");
        }
    }

    void P‰ivit‰RahaTeksti()
    {
        if (rahaTeksti != null)
        {
            rahaTeksti.text = "" + raha;
        }
    }
    public void takaisinPeliin()
    {
        SceneManager.LoadScene("MainScene");
    }
}