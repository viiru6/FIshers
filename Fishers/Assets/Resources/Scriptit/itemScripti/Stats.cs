using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Stats")]
public class Stats : ScriptableObject
{
    public int KalojaKerättyHarmaa;
    public int KalojaKerättyVihreä;
    public int KalojaKerättySininen;
    public int KalojaKerättyLiila;
    public int KalojaKerättyKultainen;
    public int KalojaKerättyYhteensä;
    public int KerratKalastettu;
    public int RahaaTienattuYhteensä;
    public int KerratMyyty;

    public double AikaPelattuSekunnit;
    public double AikaPelattuTunnit;

    [Tooltip("pelin sisäiset päivät kuleneet")]
    public int päivätPelattu;
}
