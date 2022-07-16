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
        //oyunu ba�latacak k�s�m.
        Application.loadLevel("levelismi") // oyunu a�aca�� sahne veya levelin ad� yaz�lacak
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
