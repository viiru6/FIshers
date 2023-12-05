using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsController : MonoBehaviour
{
    public Stats Stats;
    public GameObject statsPanel;
    bool statsPanelActive;
    void Update()
    {
        if (statsPanel.active) { DisplayStats(); }//jos stats paneeli on auki sen tiedot p‰ivitet‰‰n

        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            if (statsPanelActive)
            {
                statsPanel.SetActive(false);
                statsPanelActive = false;
            }
            else
            {
                statsPanel.SetActive(true);
                statsPanelActive = true;
            }
        }
    }
    public void DisplayStats()//p‰ivitt‰‰ statsPaneelin tiedot
    {
        GameObject KalojaKer‰ttyHarmaa = GameObject.Find("KalojaKer‰ttyHarmaa");
        KalojaKer‰ttyHarmaa.GetComponent<TextMeshProUGUI>().text = "<color=#D9D9D9>Harmaita</color> kaloja kalastettu: " + Stats.KalojaKer‰ttyHarmaa.ToString();
        GameObject KalojaKer‰ttyVihre‰ = GameObject.Find("KalojaKer‰ttyVihre‰");
        KalojaKer‰ttyVihre‰.GetComponent<TextMeshProUGUI>().text = "<color=#00FF00>Vihreit‰</color> kaloja kalastettu: " + Stats.KalojaKer‰ttyVihre‰.ToString();
        GameObject KalojaKer‰ttySininen = GameObject.Find("KalojaKer‰ttySininen");
        KalojaKer‰ttySininen.GetComponent<TextMeshProUGUI>().text = "<color=#0000FF>Sinisi‰</color>  kaloja kalastettu: " + Stats.KalojaKer‰ttySininen.ToString();
        GameObject KalojaKer‰ttyLiila = GameObject.Find("KalojaKer‰ttyLiila");
        KalojaKer‰ttyLiila.GetComponent<TextMeshProUGUI>().text = "<color=#FF00FF>Liiloja</color>  kaloja kalastettu: " + Stats.KalojaKer‰ttyLiila.ToString();
        GameObject KalojaKer‰ttyPunainen = GameObject.Find("KalojaKer‰ttyPunainen");
        KalojaKer‰ttyPunainen.GetComponent<TextMeshProUGUI>().text = "<color=#FF0000>Punaisia</color>  kaloja kalastettu: " + Stats.KalojaKer‰ttyPunainen.ToString();

        GameObject KalojaKer‰ttyYhteens‰ = GameObject.Find("KalojaKer‰ttyYhteens‰");
        KalojaKer‰ttyYhteens‰.GetComponent<TextMeshProUGUI>().text = "<color=#9C9CF5>Kaloja</color> Ker‰tty Yhteens‰: " + Stats.KalojaKer‰ttyYhteens‰.ToString();

        GameObject KerratKalastettu = GameObject.Find("KerratKalastettu");
        KerratKalastettu.GetComponent<TextMeshProUGUI>().text = "Kerrat Kalastettu: " + Stats.KerratKalastettu.ToString();

        GameObject RahaaTienattuYhteens‰ = GameObject.Find("RahaaTienattuYhteens‰");
        RahaaTienattuYhteens‰.GetComponent<TextMeshProUGUI>().text = "Rahaa Tienattu Yhteens‰: " + "<color=#FFEB04>" + Stats.RahaaTienattuYhteens‰.ToString() + " kultaa</color>";

        GameObject KerratMyyty = GameObject.Find("KerratMyyty");
        KerratMyyty.GetComponent<TextMeshProUGUI>().text = "Kerrat Myyty: " + Stats.KerratMyyty.ToString();

        GameObject AikaPelattuTunnit = GameObject.Find("AikaPelattuTunnit");
        AikaPelattuTunnit.GetComponent<TextMeshProUGUI>().text = "Pelattu: " + Stats.AikaPelattuTunnit.ToString().Substring(0, 4) + " tuntia";

        GameObject peliLadattuKerrat = GameObject.Find("peliLadattuKerrat");
        peliLadattuKerrat.GetComponent<TextMeshProUGUI>().text = "Peli Avattu: " + Stats.kerratPeliAvattu.ToString() + " kertaa";

        GameObject KerratKauppaAvattu = GameObject.Find("KerratKauppaAvattu");
        KerratKauppaAvattu.GetComponent<TextMeshProUGUI>().text = "Kaupassa Vierailtu: " + Stats.KerratKauppaAvattu.ToString() + " kertaa";

        // harmaa = D9D9D9
        // vihre‰ = 00FF00
        // sininen = 0000FF
        // liila = FF00FF
        // punainen = FF0000
        // kaikki = 63F7FF

        // kulta = FFEB04  
    }
}
