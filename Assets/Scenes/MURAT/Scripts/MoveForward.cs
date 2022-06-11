using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Speed = 10.0f;
    private GameController gameControllerScript;
    private void Start()
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        if (gameControllerScript.gameContinue)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -Speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        gameControllerScript.gameContinue = false;
    }
}
