using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10.0f;
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
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
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
        time -= Time.deltaTime;
        if (time <= 0)
        {
            speed = speed * acceleration;
            time = 5.0f;
        }
    }
}
