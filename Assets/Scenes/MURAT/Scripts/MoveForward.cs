using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speedd;
    public float acceleration = 1.3f;
    private GameController gameControllerScript;
    private float leftBound = 11f;
    public float time = 5f;
    private void Start()
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        SpeedControl();
        if (gameControllerScript.gameContinue == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speedd);
            DestroyObj();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        gameControllerScript.gameContinue = false;
    }
    private void DestroyObj()
    {
        if (transform.position.z < leftBound)
        {
            Destroy(gameObject);
        }
    }
    public void SpeedControl()
    {
        if (gameControllerScript.timeCounter >= 0 && gameControllerScript.timeCounter <= 10)
        {
            speedd = 10;
        }
        else if (gameControllerScript.timeCounter > 10 && gameControllerScript.timeCounter <= 20)
        {
            speedd = 15;
        }
        else if (gameControllerScript.timeCounter > 20 && gameControllerScript.timeCounter <= 30)
        {
            speedd = 20;
        }
        else if (gameControllerScript.timeCounter > 30 && gameControllerScript.timeCounter <= 40)
        {
            speedd = 25;
        }
        else if (gameControllerScript.timeCounter > 40 && gameControllerScript.timeCounter <= 50)
        {
            speedd = 30;
        }
        else if (gameControllerScript.timeCounter > 50 && gameControllerScript.timeCounter <= 60)
        {
            speedd = 35;
        }
        else if (gameControllerScript.timeCounter > 60 && gameControllerScript.timeCounter <= 70)
        {
            speedd = 40;
        }
        else if (gameControllerScript.timeCounter > 70 && gameControllerScript.timeCounter <= 80)
        {
            speedd = 45;
        }
        else if (gameControllerScript.timeCounter > 80 && gameControllerScript.timeCounter <= 90)
        {
            speedd = 50;
        }
        else if (gameControllerScript.timeCounter > 90 && gameControllerScript.timeCounter <= 100)
        {
            speedd = 55;
        }
        else if (gameControllerScript.timeCounter > 100)
        {
            speedd = 75;
        }
    }
}
