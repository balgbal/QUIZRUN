using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class howtoplay : MonoBehaviour
{
    [HideInInspector]
    public GameObject nasiloynanir;
    public Button HowToPlayText;
    public GameObject Cube;
    
    void Start()
    {
        nasiloynanir = GameObject.FindGameObjectWithTag("oynanir");
        HowToPlayText.onClick.AddListener(oynanir);
        
    }
    public void oynanir()
    {
        
        nasiloynanir.transform.position = Cube.transform.position;
        
    }

}

