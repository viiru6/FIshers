using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class saveloadmanager : MonoBehaviour
{

    string filepath;
    private void Start()
    {
        filepath = Application.persistentDataPath + "/save.gamesave";
    }
    public void savegame()
    {
     BinaryFormatter bf = new BinaryFormatter();
     FileStream fs = new FileStream(filepath, FileMode.Create);
    }

    public void loadgame()
    {
        
    }

    [System.Serializable]
    public class Save
    {
        public Stats Stats;
        public void ResetStats()
        {
            Stats.KalojaKerättyHarmaa = 0;
            Stats.KalojaKerättyVihreä = 0;
            Stats.KalojaKerättySininen = 0;
            Stats.KalojaKerättyLiila = 0;
            Stats.KalojaKerättyKultainen = 0;
            Stats.KalojaKerättyYhteensä = 0;
            Stats.KerratKalastettu = 0;
            Stats.RahaaTienattuYhteensä = 0;
            Stats.KerratMyyty = 0;
        }
    }



}
