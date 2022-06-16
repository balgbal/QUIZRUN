using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KarakterScript : MonoBehaviour
{
    public GameObject[] karakterler;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        karakterler[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % karakterler.Length;
        karakterler[selectedCharacter].SetActive(true);

    }

    public void PreviousCharacter()
    {

        karakterler[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += karakterler.Length;

        }
        karakterler[selectedCharacter].SetActive(true);

    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(3, LoadSceneMode.Single);

    }
}
