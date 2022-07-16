using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UI-code : MonoBehaviour
{
    [Header("UIPages")]
    public GameObject settingScreen;
    public GameObject creditsScreen;
    public GameObject mainScreen;

    public void StartGame()
    {
        //oyunu baþlatacak kýsým.
        Application.loadLevel("levelismi") // oyunu açacaðý sahne veya levelin adý yazýlacak
     }

    public void Settings()
        {
         mainScreen.SetActive(false);
         settingsScreen.SetActive(true);

        }
    public void Credits()
    {
         mainScreen.SetActive(false);
         creditsScreen.SetActive(true);

     }
    public void Exit()
    {
          Application.Quit();

     }
}
