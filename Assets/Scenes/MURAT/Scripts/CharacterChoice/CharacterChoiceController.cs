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
        selectedCharacter = selectedCharacter - 1;
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
    #region
    //[SerializeField] private Button previousButton;
    //[SerializeField] private Button nextButton;
    //[SerializeField] private int currentCharacter;
    //public GameObject characterController;
    //public GameObject selectCharacter;
    //public GameController gameControllerScript;
    //private void Awake()
    //{
    //    SelectCharacterIndex(0);
    //}
    //private void Start()
    //{
    //    gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
    //}
    //private void Update()
    //{
    //    SelectedCharacter();
    //}
    //public void SelectCharacterIndex(int indexNo)
    //{
    //    previousButton.interactable  = (indexNo!=0);
    //    nextButton.interactable  = (indexNo!=transform.childCount-1);
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        transform.GetChild(i).gameObject.SetActive(i == indexNo);
    //    }
    //}
    //public void ChangeChracter(int change)
    //{
    //    currentCharacter += change;
    //    SelectCharacterIndex(currentCharacter);

    //}
    //public void SelectedCharacter()
    //{
    //    if (currentCharacter == 0)
    //    {
    //        selectCharacter = characterController.transform.GetChild(0).transform.GetChild(1).gameObject;
    //    }
    //    else if (currentCharacter == 1)
    //    {
    //        selectCharacter = characterController.transform.GetChild(1).transform.GetChild(1).gameObject;
    //    }
    //    else if (currentCharacter == 2)
    //    {
    //        selectCharacter = characterController.transform.GetChild(2).transform.GetChild(1).gameObject;
    //    }
    //    else if (currentCharacter == 3)
    //    {
    //        selectCharacter = characterController.transform.GetChild(3).transform.GetChild(1).gameObject;
    //    }
    //    else if (currentCharacter == 4)
    //    {
    //        selectCharacter = characterController.transform.GetChild(4).transform.GetChild(1).gameObject;
    //    }
    //    else if (currentCharacter == 5)
    //    {
    //        selectCharacter = characterController.transform.GetChild(5).transform.GetChild(1).gameObject;
    //    }
    //    else if (currentCharacter == 6)
    //    {
    //        selectCharacter = characterController.transform.GetChild(6).transform.GetChild(1).gameObject;
    //    }
    //    else if (currentCharacter == 7)
    //    {
    //        selectCharacter = characterController.transform.GetChild(7).transform.GetChild(1).gameObject;
    //    }
    //    else if (currentCharacter == 8)
    //    {
    //        selectCharacter = characterController.transform.GetChild(8).transform.GetChild(1).gameObject;
    //    }
    //}
    #endregion
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
}
