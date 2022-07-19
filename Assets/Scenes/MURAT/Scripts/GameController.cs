using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public bool gameContinue = true;
    public GameObject gameOverPanel;
    public GameObject mathPanel;
    public FloatingJoystick floatingJoystick;
    public Rigidbody playerRB;
    public float rlSpeed =30.0f;
    private float border = 5.0f;
    public GameObject mainChar;
    public Text time, healt, status;
    float timeCounter = 0.0f;
    public int HealtCounter = 3;
    private void Start()
    {
        mainChar = GameObject.Find("MainChar");
        playerRB = mainChar.GetComponentInChildren<Rigidbody>();
    }
    private void Update()
    {
        TimeControl();
        if (gameContinue)
        {
            MoveClamp();            
        }
        else
        {
            if (HealtCounter != 0)
            {
                mathPanel.SetActive(true);
            }
            else
            {
                gameContinue = false;
                mathPanel.SetActive(false);
                gameOverPanel.SetActive(true);
            }
            
        }
    }
    private void FixedUpdate()
    {
        if (gameContinue)
        {
            Move();
        }
        else
        {
            if (HealtCounter != 0)
            {
                mathPanel.SetActive(true);
            }
            else
            {
                gameContinue = false;
                mathPanel.SetActive(false);
                gameOverPanel.SetActive(true);
            }
        }
    }
    public void TimeControl()
    {
        if (gameContinue)
        {
            timeCounter += Time.deltaTime;
            time.text = (int)timeCounter + "";
        }
        else
        {
            status.text = "Skor : " + (int)timeCounter;
        }
    }
    private void MoveClamp()
    {
        float posX = Mathf.Clamp(mainChar.transform.position.x, -border, border);
        mainChar.transform.position = new Vector3(posX, mainChar.transform.position.y, mainChar.transform.position.z);
    }
    public void Move()
    {
        Vector3 direction = Vector3.right * floatingJoystick.Horizontal;
        playerRB.AddForce(direction * rlSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
