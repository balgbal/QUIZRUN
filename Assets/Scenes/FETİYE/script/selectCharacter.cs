using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectCharacter : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter;
    private void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        characters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            characters[i] = transform.GetChild(i).gameObject;
        foreach (GameObject go in characters)
            go.SetActive(false);
        if (characters[selectedCharacter])
            characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = selectedCharacter -1;  
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length-1;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == characters.Length)
            selectedCharacter = 0;
        characters[selectedCharacter].SetActive(true);
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene("0-3");
    }
    

}
