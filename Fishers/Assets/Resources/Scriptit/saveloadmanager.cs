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
            Stats.KalojaKer�ttyHarmaa = 0;
            Stats.KalojaKer�ttyVihre� = 0;
            Stats.KalojaKer�ttySininen = 0;
            Stats.KalojaKer�ttyLiila = 0;
            Stats.KalojaKer�ttyKultainen = 0;
            Stats.KalojaKer�ttyYhteens� = 0;
            Stats.KerratKalastettu = 0;
            Stats.RahaaTienattuYhteens� = 0;
            Stats.KerratMyyty = 0;
        }
    }



}
