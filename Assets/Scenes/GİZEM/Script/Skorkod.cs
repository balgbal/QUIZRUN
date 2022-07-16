using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skorkod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tekrar()
    {
        SceneManager.LoadScene("testSahnesi");
    }

    public void Menu()
    {
        SceneManager.LoadScene("AnaMenu");
    }
}
