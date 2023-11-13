using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kalamekaniikatscipt : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public Stats Stats;
    public VuorokausiRytmi VuorokausiRytmi;
    [SerializeField] private Cooldown cooldown;
    [SerializeField] [Tooltip("Matalempi = parempi")] public float ongenTeho;
    private int numberOfRolls = 1;
    GameObject kalanappu;
    private void Start()
    {
        kalanappu = GameObject.Find("kalastaNappi");
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        string ActiveScene = scene.name;
        if (ActiveScene == "MainScene")
        {
            if (cooldown.isCoolingdown) { kalanappu.GetComponent<Image>().color = Color.red; }
            else { kalanappu.GetComponent<Image>().color = new Color(0.3066038f, 0.3887759f, 1f, 1f); }
        }
    }
    public SyöttiItem Syötti;
    public void CalculateNumberOfRolls()
    {
        if (Random.RandomRange(0f, 100f) <= Syötti.syötinTeho)
        {
            numberOfRolls++;
        }
    }
    public void KalastaNappi()
    {
        if (cooldown.isCoolingdown) return;

        Stats.KerratKalastettu++;

        for (int i = 0; numberOfRolls >= i; i++)
        {
            CalculateNumberOfRolls();

            float harvinaisuus = Random.RandomRange(0f, 100f);
            harvinaisuus = harvinaisuus * ongenTeho;
            if (harvinaisuus <= 0.5f) { valitseKala(kultainen); Stats.KalojaKerättyKultainen++; }
            else if (harvinaisuus <= 5) { valitseKala(liila); Stats.KalojaKerättyLiila++; }
            else if (harvinaisuus <= 20) { valitseKala(sininen); Stats.KalojaKerättySininen++; }
            else if (harvinaisuus <= 50) { valitseKala(vihreä); Stats.KalojaKerättyVihreä++; }
            else if (harvinaisuus >= 0) { valitseKala(harmaa); Stats.KalojaKerättyHarmaa++; }

            numberOfRolls--;
            Stats.KalojaKerättyYhteensä++;
        }
        numberOfRolls = 1;

        cooldown.StartCooldown();
    }
    public List<KalaItem> harmaa = new List<KalaItem>();
    public List<KalaItem> vihreä = new List<KalaItem>();
    public List<KalaItem> sininen = new List<KalaItem>();
    public List<KalaItem> liila = new List<KalaItem>();
    public List<KalaItem> kultainen = new List<KalaItem>();
    public void valitseKala(List<KalaItem> kalaItems)
    {
        List<KalaItem> availablefish = new List<KalaItem>();
        foreach (KalaItem fisu in kalaItems)
        {
            if (fisu.startTime <= VuorokausiRytmi.hours && fisu.endTime > VuorokausiRytmi.hours)
            {
                availablefish.Add(fisu);
            }
        }
        InventoryManager.Instance.Add(availablefish[Random.RandomRange(0, availablefish.Count)]);
    }
}

