using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject aboutPanel;
    
    public void CloseHowToPlayPanel()
    {
        howToPlayPanel.SetActive(false);
    }
    public void CloseAboutPanel()
    {
        aboutPanel.SetActive(false);
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
        aboutPanel.SetActive(true);
    }
   
}
