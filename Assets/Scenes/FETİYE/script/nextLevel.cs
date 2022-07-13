using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLevel : MonoBehaviour
{
    //public GameObject nasiloynanir;
    private Scene _scene;
    //[SerializeField] private Button HowToPlayText;
    //[SerializeField] private Vector3 finalPosition;
    //private Vector3 initialPosition;
    
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();              //caching
       // initialPosition = transform.position;
    }
    void Start()
    {
       // nasiloynanir = GameObject.FindGameObjectWithTag("oynanir");
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
    //public void Update()
    //{
    //    //HowToPlayText.interactable = (indexNu != transform.childCount - 1);
    //    //for (int i = 0; i < transform.childCount; i++)
    //    //{
    //    //    transform.GetChild(i).gameObject.SetActive(i == indexNu);
    //    //}
    //    nasiloynanir.transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f);
    //    //transform.position += finalPosition;

    //}
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("application has quit.");
    }
    //private void OnDisable()
    //{
    //    transform.position = initialPosition;
    //}
}

