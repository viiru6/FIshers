using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menusciptit : MonoBehaviour
{
    public void Pelaa()
    {        
        //   GameObject.Instantiate(Resources.Load("")); 
    }
    public void Asetukset()
    {
        try//try catch sit‰ varten kun asetukset avaa pause menusta
        {
            GameObject mainmenu = GameObject.Find("Mainmenu(Clone)");
            mainmenu.SetActive(false);  //piilottaa main menun ja asetukset tulee esille
        }
        catch
        {
            print("mainmenu ei ole p‰‰ll‰");
        }
        GameObject.Instantiate(Resources.Load("Menut/Asetukset"));
    }
    public void Poistu()
    {
        Application.Quit();
    }

    public void Takaisin_asetukset_peli()
    {
        print("takaisin peliin");
    }
    public void Takaisin_asetukset_mainmenuun()
    {
        print("takaisin mainmenuun");
    }
    public void Jatka()//tuhoaa pausemenuun liittyv‰t asiat
    {
        GameObject pausemenu = GameObject.Find("Pausemenu(Clone)");
        Destroy(pausemenu);
        GameObject blur = GameObject.Find("Blur(Clone)");
        Destroy(blur);
    }
   
}
