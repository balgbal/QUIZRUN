using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudController : MonoBehaviour
{
    private float speed =10.0f;
    public GameObject groud;
    private GameController gameControllerScript;

    void Start()
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (gameControllerScript.gameContinue)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        groud.transform.position += new Vector3(0, 0, 127.6f);
    }
}
