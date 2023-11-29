using TMPro;
using UnityEngine;

public class Rahanpv : MonoBehaviour
{
    private int raha;
    public TextMeshProUGUI rahaTeksti;

    void Start()
    {
        raha = 100; // rahaa 100
        P‰ivit‰RahaTeksti();
    }
    // jos haluaa lis‰‰ rahaa niin rahan hallinto
    public void Lis‰‰Rahaa(int m‰‰r‰)
    {
        raha += m‰‰r‰;
        P‰ivit‰RahaTeksti();
    }
    // sama t‰ss‰ mutta jos k‰ytt‰ pelin sis‰ist‰ rahaa
    public bool V‰henn‰Rahaa(int m‰‰r‰)
    {
        if (raha - m‰‰r‰ >= 0)
        {
            raha -= m‰‰r‰;
            P‰ivit‰RahaTeksti();
            return true;
        }
        //varmistaa ett‰ raha ei mene velaksi ;)
        else
        {
            Debug.Log("Ei ole tarpeeksi rahaa!");
            return false;
        }
    }
    // p‰ivitt‰‰ rahan ja n‰ytt‰‰ tarvittavan tekstin ?
    void P‰ivit‰RahaTeksti()
    {
        if (rahaTeksti != null)
        {
            rahaTeksti.text = "" + raha;
        }
    }
}