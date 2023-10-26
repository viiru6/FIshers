using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    private void Start()
    {
        GameObject.Instantiate(Resources.Load("Menut/Asetukset"));//lataa asetukset menun ja tuhoaa sen heti jotta peli aukeaa oikeassa resoluutiossa
        GameObject Asetukset = GameObject.Find("Asetukset(Clone)");
        Destroy(Asetukset);
        
        GameObject.Instantiate(Resources.Load("Menut/Mainmenu"));       
    }
}
