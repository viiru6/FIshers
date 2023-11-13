using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Stats")]
public class Stats : ScriptableObject
{
    public int KalojaKer�ttyHarmaa;
    public int KalojaKer�ttyVihre�;
    public int KalojaKer�ttySininen;
    public int KalojaKer�ttyLiila;
    public int KalojaKer�ttyKultainen;
    public int KalojaKer�ttyYhteens�;
    public int KerratKalastettu;
    public int RahaaTienattuYhteens�;
    public int KerratMyyty;

    public double AikaPelattuSekunnit;
    public double AikaPelattuTunnit;

    [Tooltip("pelin sis�iset p�iv�t kuleneet")]
    public int p�iv�tPelattu;
}
