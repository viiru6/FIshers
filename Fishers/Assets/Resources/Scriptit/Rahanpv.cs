using TMPro;
using UnityEngine;

public class Rahanpv : MonoBehaviour
{
    private int raha;
    public TextMeshProUGUI rahaTeksti;

    void Start()
    {
        raha = 110; // Alustetaan rahaesimerkki100:lla.
        P‰ivit‰RahaTeksti();
    }

    public void Lis‰‰Rahaa(int m‰‰r‰)
    {
        raha += m‰‰r‰;
        P‰ivit‰RahaTeksti();
    }

    public bool V‰henn‰Rahaa(int m‰‰r‰)
    {
        if (raha - m‰‰r‰ >= 0)
        {
            raha -= m‰‰r‰;
            P‰ivit‰RahaTeksti();
            return true;
        }
        else
        {
            Debug.Log("Ei ole tarpeeksi rahaa!");
            return false;
        }
    }

    void P‰ivit‰RahaTeksti()
    {
        if (rahaTeksti != null)
        {
            rahaTeksti.text = "" + raha;
        }
    }
}