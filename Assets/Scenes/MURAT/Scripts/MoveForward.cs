using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Speed = 10.0f;
    private GameController gameControllerScript;
    private float leftBound = 11f;
    private void Start()
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        if (gameControllerScript.gameContinue == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -Speed);
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
}
