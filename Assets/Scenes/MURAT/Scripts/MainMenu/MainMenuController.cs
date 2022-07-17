using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject howToPlayPanel;
    private void Start()
    {

    }
    public void CloseHowToPlayPanel()
    {
        howToPlayPanel.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("CharacterChoiceV2");
    }
    public void Quit()
    {

    }
    public void HowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }
    public void About()
    {

    }
}
