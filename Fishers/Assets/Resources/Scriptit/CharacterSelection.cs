using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        // piilota nykyinen hahmo
        characters[selectedCharacter].SetActive(false);

        // p‰ivit‰ indeksi seuraavaan hahmoon ja varmistaa ett‰ indeksi pysyy listan rajoissa
        selectedCharacter = (selectedCharacter + 1) % characters.Length;

        // n‰yt‰ uusi hahmo
        characters[selectedCharacter].SetActive(true);
    }

    // metodi edellisen hahmon valitsemiseen
    public void PreviousCharacter()
    {
        // piilota nykyinen hahmo jotta n‰kyisi vain 1
        characters[selectedCharacter].SetActive(false);

        // v‰henn‰ indeksi‰ edelliseen hahmoon ja tarkista ettei indeksi mene negatiiviseksi k‰‰nt‰en sen tarvittaessa listan loppuun
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }

        // n‰yt‰ uusi valittu hahmo
        characters[selectedCharacter].SetActive(true);
    }

    // aloita peli valitulla hahmolla (Anton)
    public void StartGame()
    {
        // tallenna valitun hahmon indeksi pelaajan asetuksiin
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        // lataa pelin seuraavaan kohtaan (oletetaan ett‰ kohteen indeksi on 1)
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
