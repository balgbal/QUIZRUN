using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public bool gameContinue = true;
    public GameObject questionPanel;
    public GameObject gameOverPanel;
    public GameObject mathPanel;
    public FloatingJoystick floatingJoystick;
    public Rigidbody playerRB;
    public float rlSpeed =30.0f;
    private float border = 5.0f;
    public GameObject mainChar;
    public Text time, healt, status;
    public float timeCounter = 0.0f;
    public int HealtCounter = 3;
    public string stringDeger;
    public bool IngOrMath;

    private void Start()
    {
        LessonSelection();
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
    public void LessonSelection()
    {
        stringDeger = PlayerPrefs.GetString("lessonSelection");
        if (stringDeger == "matematik")
        {
            IngOrMath = true;
            mathPanel = Instantiate(Resources.Load("MathPanel") as GameObject, questionPanel.transform);
        }
        else if (stringDeger == "ingilizce")
        {
            IngOrMath = false;
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
