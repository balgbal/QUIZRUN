using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private int obstacleIndex;
    private float[] obstacleSpawnPos = new float[] { 0, 2.5f, -2.5f };
    private int obstacleSpawnIndex;
    private float speed = 10.0f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    private GameController gameControllerScript;
    private void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
        
    }
    private void Update()
    {

    }
    public void SpawnRandomObstacle()
    {
        if (gameControllerScript.gameContinue == true)
        {
            obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], new Vector3(obstacleSpawnPos[obstacleSpawnIndex], 0, 120), obstaclePrefabs[obstacleIndex].transform.rotation);

            obstacleSpawnIndex = Random.Range(0, obstacleSpawnPos.Length);


            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
    }
}
