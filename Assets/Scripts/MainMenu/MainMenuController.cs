using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject aboutPanel;
    public AudioSource audioData;



    public Image SesliMOD;
    public Image SessizMOD;

    public Button SesKontrolButonu;

    bool ButonKontrolBool;


    private void Start()
    {
        audioData.Play();
        SesliMOD.gameObject.SetActive(true);
        SessizMOD.gameObject.SetActive(false);
    }
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
        Application.Quit();
    }
    public void HowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }
    public void About()
    {
        aboutPanel.SetActive(true);
    }
    public void ButonKontrol()
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
