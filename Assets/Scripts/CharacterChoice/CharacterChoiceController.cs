using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CharacterChoiceController : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter;
    public string diffSelection;
    public string lessons;
    public AudioSource audioData;

    public Image SesliMOD;
    public Image SessizMOD;

    public Button SesKontrolButonu;

    bool ButonKontrolBool;
    private void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        characters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characters)
        {
            go.SetActive(false);
        }
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == selectedCharacter)
            {
                characters[selectedCharacter].SetActive(true);
            }
        }
    }

    public void MathSelection()
    {
        lessons = "matematik";
        PlayerPrefs.SetString("lessonSelection",lessons);
        PlayerPrefs.Save();
    }
    public void IngSelection()
    {
        lessons = "ingilizce";
        PlayerPrefs.SetString("lessonSelection", lessons);
        PlayerPrefs.Save();
    }
    public void DifficultyEasySelection()
    {
        diffSelection = "easy";
        PlayerPrefs.SetString("diffSelection",diffSelection);
        PlayerPrefs.Save();
    }
    public void DifficultyHardSelection()
    {
        diffSelection = "hard";
        PlayerPrefs.SetString("diffSelection", diffSelection);
        PlayerPrefs.Save();
    }
    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length - 1;
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
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameScene");
    }
    public void SoundKontrol()
    {
        if (ButonKontrolBool == false)
        {
            ButonKontrolBool = true;
            AudioListener.pause = true;

            SesliMOD.gameObject.SetActive(false);
            SessizMOD.gameObject.SetActive(true);

        }
        else
        {
            ButonKontrolBool = false;
            AudioListener.pause = false;

            SesliMOD.gameObject.SetActive(true);
            SessizMOD.gameObject.SetActive(false);

        }
    }
}
