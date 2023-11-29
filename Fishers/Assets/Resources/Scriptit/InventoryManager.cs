using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public VuorokausiRytmi VuorokausiRytmi;
    public List<QuestItem> quests = new List<QuestItem>();
    public List<KalaItem> inventory = new List<KalaItem>();
    public Transform inventoryContent;
    public GameObject inventorySlot;
    public DebugMenuScript DebugMenuScript;
    private int fishCaught;

    private void Awake()//luo singletonin
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        foreach (QuestItem questItem in quests)
        {
            questItem.QuestIsActive = false;
            questItem.criteriaCurrent = 0;
        }
    }
    private void Update()
    {
        if (VuorokausiRytmi.hours == 8 && VuorokausiRytmi.mins == 0 && VuorokausiRytmi.seconds == 0)
        {
            GiveQuest();
        }
    }
    public void QuestCompleted(QuestItem questItem)
    {
        lompakko += questItem.questReward;
    }
    public void QuestCriteriaCheck(KalaItem kala)
    {
        foreach (QuestItem quest in quests)
        {
            if (quest.startHour > quest.endHour)
            {
                if ((VuorokausiRytmi.hours < 24 && quest.startHour <= VuorokausiRytmi.hours) || VuorokausiRytmi.hours >= 0 && quest.endHour > VuorokausiRytmi.hours)//yˆ questeille
                {
                    if (kala.rarity == quest.rarity)
                    {
                        quest.criteriaCurrent++;
                        if (quest.criteriaCurrent >= quest.criteriaNeeded)
                        {
                            QuestCompleted(quest);
                            quest.QuestIsActive = false;
                        }
                    }
                    if (quest.anyRarity)
                    {
                        quest.criteriaCurrent++;
                        if (quest.criteriaCurrent >= quest.criteriaNeeded)
                        {
                            QuestCompleted(quest);
                            quest.QuestIsActive = false;
                        }
                    }
                }
            }
            else
            {
                if (quest.startHour < VuorokausiRytmi.hours && quest.endHour > VuorokausiRytmi.hours)//p‰iv‰ questeille
                {
                    if (kala.rarity == quest.rarity)
                    {
                        quest.criteriaCurrent++;
                        if (quest.criteriaCurrent >= quest.criteriaNeeded)
                        {
                            QuestCompleted(quest);
                            quest.QuestIsActive = false;
                        }
                    }
                    if (quest.anyRarity)
                    {
                        quest.criteriaCurrent++;
                        if (quest.criteriaCurrent >= quest.criteriaNeeded)
                        {
                            QuestCompleted(quest);
                            quest.QuestIsActive = false;
                        }
                    }
                }
            }
        }
    }
    public void Add(KalaItem kala)//lis‰‰ kalan inventoryyn jos sit‰ ei sielt‰ viel‰ lˆydy. muuten nostaa stackin kokoa. lopuksi refreshaa inventoryn // suorittaa myˆs questien edistymisen tarkistuksen
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
        
        RefreshQuestPanel();
        QuestCriteriaCheck(kala);
    }
    public Transform questContent;
    public GameObject questPrefab;
    // harmaa = D9D9D9
    // vihre‰ = 00FF00
    // sininen = 0000FF
    // liila = FF00FF
    // kultainen = FFEB04    
    public void RefreshQuestPanel()
    {
        CleanQuests();
        for (int i = 0; i < quests.Count; i++)
        {
            if (quests[i].QuestIsActive)
            {
                GameObject QuestSlot = Instantiate(questPrefab, questContent);
                var title = QuestSlot.transform.Find("title").GetComponent<TextMeshProUGUI>();
                string shownDesc = string.Format(quests[i].desc, quests[i].displaydRarity, quests[i].criteriaCurrent, quests[i].criteriaNeeded,quests[i].questReward);
                title.text = shownDesc;
            }
        }
    }
    public void GiveQuest()//voi antaa vaan kaksi tai yksi questi‰
    {
        for (int q = 0; q <= quests.Count; q++)
        {
            quests[Random.RandomRange(0, quests.Count)].QuestIsActive = true;
        }
        foreach (QuestItem questItem in quests)
        {
            questItem.criteriaCurrent = 0;
        }
    }
    public void RefreshInventory()//poistaa inventoryn sis‰llˆn n‰kyvilt‰ ja piirt‰‰ sen uudelleen
    {
        CleanInventory();
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
    public void CleanQuests()
    {
        foreach (Transform childtransform in questContent)
        {
            Destroy(childtransform.gameObject);
        }
    }
    public void RemoveQuest(QuestItem quest)
    {
        foreach (Transform childtransform in questContent)
        {
            Destroy(childtransform.gameObject);
            quests.Remove(quest);
        }
    }
    public void CleanInventory()//tyhjent‰‰ n‰kyv‰n inventoryn
    {
        foreach (Transform childtransform in inventoryContent)
        {
            Destroy(childtransform.gameObject);
        }
    }
    public void RemoveItems()//tyhjent‰‰ n‰kyv‰n inventoryn ja poistaa inventoryn sis‰llˆn
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
        stats.RahaaTienattuYhteens‰ = stats.RahaaTienattuYhteens‰ + invVal;
        invVal = 0;
    }
    private int invVal = 0;
    public Stats stats;


    //v‰liaikainen
    public void DebugInfo()
    {
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
            if (kala.rarity == "vihre‰") { vih = vih + kala.currentStack; }
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
            GameObject KalojenM‰‰r‰Debug = GameObject.Find("KalojenM‰‰r‰Debug");
            GameObject KalojenArvoDebug = GameObject.Find("KalojenArvoDebug");
            GameObject KalojaNapattuTextDebug = GameObject.Find("KalojaNapattuTextDebug");
            GameObject TunnitPelattuTextDebug = GameObject.Find("TunnitPelattuTextDebug");

            KalojenHarvinaisuusDebug.GetComponent<TextMeshProUGUI>().text = "harmaat: " + har + "\nvihre‰t: " + vih + "\nsiniset :" + sin + "\nliilat: " + lii + "\nkultaiset: " + kul;
            KalojenArvoDebug.GetComponent<TextMeshProUGUI>().text = "Kalojen arvo: " + inventoryValue.ToString();
            KalojenM‰‰r‰Debug.GetComponent<TextMeshProUGUI>().text = "kalat: " + totalStack;

            KalojaNapattuTextDebug.GetComponent<TextMeshProUGUI>().text = "kaloja napattu: " + fishCaught;
            try
            {
                TunnitPelattuTextDebug.GetComponent<TextMeshProUGUI>().text = "Tunnit pelattu: " + stats.AikaPelattuTunnit.ToString().Substring(0, 4);
            }
            catch { }
        }
    }
}
