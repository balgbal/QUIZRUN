using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekrar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter3D(Collision3D temas)
    {
        if (temas.gameObject.tag == "tekrar")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
