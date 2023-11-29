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
    public OnkiItem Onki;
    public Sy�ttiItem Sy�tti;
    [SerializeField] public Cooldown cooldown;

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
        if (ActiveScene == "MainScene")//kun ollaan oikeassa sceness�: s��t�� kalastusnapin v�rin oikein riippuen siit� onko cooldown k�ynniss� vai ei
        {
            if (cooldown.isCoolingdown) { kalanappu.GetComponent<Image>().color = Color.red; }
            else { kalanappu.GetComponent<Image>().color = new Color(0.3066038f, 0.3887759f, 1f, 1f); }
        }
    }
    public void CalculateNumberOfRolls()//laskee montako kalaa pelaaja saa
    {
        if (Random.RandomRange(0f, 100f) <= Sy�tti.sy�tinTeho)
        {
            numberOfRolls++;
        }
    }
    public void KalastaNappi()//arpoo pelaajalle kalan tai kalat riippuen heittojen m��r�st�. sis�lt�� harvinaisuuden, cooldownin ja statsit.
    {
        if (cooldown.isCoolingdown) return;
        cooldown.CooldownTime = Onki.cooldown;
        Stats.KerratKalastettu++;

        for (int i = 0; numberOfRolls >= i; i++)
        {
            CalculateNumberOfRolls();

            float harvinaisuus = Random.RandomRange(0f, 100f);
            harvinaisuus = harvinaisuus * Onki.power;
            if (harvinaisuus <= 0.5f) { StartMinigame(); }
            else if (harvinaisuus <= 5) { valitseKala(liila); Stats.KalojaKer�ttyLiila++; }
            else if (harvinaisuus <= 20) { valitseKala(sininen); Stats.KalojaKer�ttySininen++; }
            else if (harvinaisuus <= 50) { valitseKala(vihre�); Stats.KalojaKer�ttyVihre�++; }
            else if (harvinaisuus >= 0) { valitseKala(harmaa); Stats.KalojaKer�ttyHarmaa++; }

            numberOfRolls--;
            Stats.KalojaKer�ttyYhteens�++;
        }
        numberOfRolls = 1;

        cooldown.StartCooldown();
    }
    public List<KalaItem> harmaa = new List<KalaItem>();
    public List<KalaItem> vihre� = new List<KalaItem>();
    public List<KalaItem> sininen = new List<KalaItem>();
    public List<KalaItem> liila = new List<KalaItem>();
    public List<KalaItem> kultainen = new List<KalaItem>();
    public void valitseKala(List<KalaItem> currentRarity)//laskee saaatavilla olevat kalat ja arpoo niist� jonkin pelaajalle
    {
        List<KalaItem> availablefish = new List<KalaItem>();
        foreach (KalaItem fisu in currentRarity)
        {
            if (fisu.startTime <= VuorokausiRytmi.hours && fisu.endTime > VuorokausiRytmi.hours)
            {
                availablefish.Add(fisu);
            }
        }
        InventoryManager.Instance.Add(availablefish[Random.RandomRange(0, availablefish.Count)]);
    }

    public GameObject miniGameTarget;
    bool movingToRight = true;
    public GameObject MinipeliNappi;
    public GameObject minigame;
    public GameObject minigamePanel;
    public GameObject timer;
    float s;
    public void StartMinigame()//k�ynnist�� minipelin ja tuo esiin tarvittavat asiat
    {
        pos = Random.RandomRange(-200f, 200f);
        runCR = true;
        minigame.SetActive(true);
        MinipeliNappi.SetActive(true);
        kalanappu.SetActive(false);
        StartCoroutine(MinigameTarget());
    }
    public void StopMinigame()//lopettaa mini pelin ja piilottaa tarvittavat asiat
    {
        runCR = false;
        minigame.SetActive(false);
        MinipeliNappi.SetActive(false);
        kalanappu.SetActive(true);        
        StopCoroutine(MinigameTarget());
    }
    public void MinigameCheck()//checkkaa onko minipelin "t�ht�in" oikealla kohdalla ja antaa kalan sen perusteella
    {
        StopMinigame();
        if (pos >= -20 && pos < 10)
        {
            valitseKala(kultainen); Stats.KalojaKer�ttyKultainen++;
            //onnistumis ��ni?
        }
        else
        {
            //kusemis ��ni?
        }
    }
    bool runCR;
    float pos = -200;
    private void FixedUpdate()//laskee ajan jota k�ytet��n minipeliss�
    {
        s -= Time.fixedDeltaTime;
    }
    public IEnumerator MinigameTarget()//timeri ja liikuttaa minipelin "t�ht�int�"
    {
        timer.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
        s = 5.5f;
        float targetSpeed = Random.RandomRange(0.6f, 2.5f); // arpoo minipelin vaikeustason
        while (runCR)
        {
            if (s < 0.5f)
            {
                StopMinigame();
            }
            timer.GetComponent<TextMeshProUGUI>().text = string.Format("{00}", s.ToString().Substring(0,1)); ; //piirt�� minipelin timerin ja s��t� v�rin asian mukaiseksi
            timer.GetComponent<TextMeshProUGUI>().color = new Color(1, s/5.5f, s/5.5f, 1);
            miniGameTarget.transform.position = minigamePanel.transform.TransformPoint(pos, 0, 0);//siirt�� minipelin "t�ht�int�"
            if (movingToRight)
            {
                pos += targetSpeed;
                if (pos >= 200)
                {
                    movingToRight = false;
                }
            }
            else
            {
                pos -= targetSpeed;
                if (pos <= -200)
                {
                    movingToRight = true;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}

