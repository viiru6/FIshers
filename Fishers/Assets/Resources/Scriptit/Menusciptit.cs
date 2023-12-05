using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menusciptit : MonoBehaviour
{
    public GameObject mainmenu;
    public Stats Stats;
    public void Pelaa()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Asetukset()
    {
        Destroy(mainmenu);
        GameObject.Instantiate(Resources.Load("Menut/Asetukset"));
    }
    public void Poistu()
    {
        Stats.kerratPeliAvattu++;
        Application.Quit();
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void Kauppa()
    {
        SceneManager.LoadScene("kauppa");
        Stats.kerratPeliAvattu++;
    }
}
