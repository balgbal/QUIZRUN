using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLevel : MonoBehaviour
{
    
    private Scene _scene;
    
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();            
      
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_scene.buildIndex+1);
        }
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex+1);
    }
    

    public void Previousscene()
    {
        SceneManager.LoadScene(_scene.buildIndex - 1);
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("application has quit.");
    }
    
}

