using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<KalaItem> inventory = new List<KalaItem>();
    public Transform inventoryContent;
    public GameObject inventorySlot;
    public DebugMenuScript DebugMenuScript;
    private int fishCaught;
    private void Awake()//luo singletonin
    {
        Instance = this;
    }
    public void Add(KalaItem kala)//lisää kalan inventoryyn jos sitä ei sieltä vielä löydy. muuten nostaa stackin kokoa ja refreshaa inventoryn
    {
        fishCaught++;
        if (inventory.Contains(kala))
        {
            kala.currentStack++;
        }
        else
        {
            kala.currentStack = 1;
            inventory.Add(kala);
        }
        RefreshInventory();
    }
    public void RefreshInventory()//poistaa inventoryn sisällön näkyviltä ja piirtää sen uudelleen
    {
        Clean();
        for (int i = 0; i < inventory.Count; i++)
        {
            GameObject InventorySlot = Instantiate(inventorySlot, inventoryContent);
            var itemName = InventorySlot.transform.Find("itemName").GetComponent<TextMeshProUGUI>();
            var itemCount = InventorySlot.transform.Find("itemCount").GetComponent<TextMeshProUGUI>();
            itemName.text = inventory[i].itemName;
            itemName.color = inventory[i].color;
            itemCount.text = inventory[i].currentStack.ToString();
        }
    }
    public void Clean()//tyhjentää näkyvän inventoryn
    {
        foreach (Transform childtransform in inventoryContent)
        {
            Destroy(childtransform.gameObject);
        }
    }
    public void RemoveItems()//tyhjentää näkyvän inventoryn ja poistaa inventoryn sisällön
    {
        foreach (Transform childtransform in inventoryContent)
        {
            Destroy(childtransform.gameObject);
            inventory.Clear();
        }
    }
    private int lompakko = 0;
    public void Myykalat()
    {
        if (inventory.Count == 0) return;
        lompakko = lompakko + invVal;
        RemoveItems();
        GameObject rahaText = GameObject.Find("RahatTextDebug");
        rahaText.GetComponent<TextMeshProUGUI>().text = "Rahat: " + lompakko.ToString();
        stats.KerratMyyty++;
        stats.RahaaTienattuYhteensä = stats.RahaaTienattuYhteensä + invVal;
        invVal = 0;
    }
    private int invVal = 0;
    public Stats stats;
    public void DebugInfo()
    {//väliaikainen
        int inventoryValue = 0;
        int totalStack = 0;
        int har = 0;
        int vih = 0;
        int sin = 0;
        int lii = 0;
        int kul = 0;
        foreach (KalaItem kala in inventory)
        {
            if (kala.rarity == "harmaa") { har = har + kala.currentStack; }
            if (kala.rarity == "vihreä") { vih = vih + kala.currentStack; }
            if (kala.rarity == "sininen") { sin = sin + kala.currentStack; }
            if (kala.rarity == "liila") { lii = lii + kala.currentStack; }
            if (kala.rarity == "kultainen") { kul = kul + kala.currentStack; }

            inventoryValue = inventoryValue + kala.value * kala.currentStack;
            invVal = inventoryValue;
            totalStack = totalStack + kala.currentStack;
        }
        if (DebugMenuScript.DebugMenu.active)
        {
            GameObject KalojenHarvinaisuusDebug = GameObject.Find("KalojenHarvinaisuusDebug");
            GameObject KalojenMääräDebug = GameObject.Find("KalojenMääräDebug");
            GameObject KalojenArvoDebug = GameObject.Find("KalojenArvoDebug");
            GameObject KalojaNapattuTextDebug = GameObject.Find("KalojaNapattuTextDebug");
            GameObject TunnitPelattuTextDebug = GameObject.Find("TunnitPelattuTextDebug");

            KalojenHarvinaisuusDebug.GetComponent<TextMeshProUGUI>().text = "harmaat: " + har + "\nvihreät: " + vih + "\nsiniset :" + sin + "\nliilat: " + lii + "\nkultaiset: " + kul;
            KalojenArvoDebug.GetComponent<TextMeshProUGUI>().text = "Kalojen arvo: " + inventoryValue.ToString();
            KalojenMääräDebug.GetComponent<TextMeshProUGUI>().text = "kalat: " + totalStack;

            KalojaNapattuTextDebug.GetComponent<TextMeshProUGUI>().text = "kaloja napattu: " + fishCaught;
            try
            {
                TunnitPelattuTextDebug.GetComponent<TextMeshProUGUI>().text = "Tunnit pelattu: " + stats.AikaPelattuTunnit.ToString().Substring(0, 4);
            }
            catch { }
        }
    }
}
