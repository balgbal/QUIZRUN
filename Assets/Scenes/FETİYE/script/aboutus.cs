using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class aboutus : MonoBehaviour
{
    [HideInInspector]
    public GameObject hakkimizda;
    public Button About;
    public GameObject Cube;

    void Start()
    {
        hakkimizda = GameObject.FindGameObjectWithTag("about");
        About.onClick.AddListener(oynanir);

    }
    public void oynanir()
    {
        hakkimizda.transform.position = Cube.transform.position;
    }
    public void back()
    {
        hakkimizda.gameObject.SetActive(false);
    }
}
