using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public TMP_Text label;

       void Start()
    {
        int selectedChracter = PlayerPrefs.GetInt("Valikoitu hahmo");
        GameObject prefab = characterPrefabs[selectedChracter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        label.text = prefab.name;
    }
}
 