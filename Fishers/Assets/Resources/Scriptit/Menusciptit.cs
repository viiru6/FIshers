using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menusciptit : MonoBehaviour
{
    public GameObject mainmenu;
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
        Application.Quit();
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
