using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private void Start()
    {
        mainChar = GameObject.Find("MainChar");
        playerRB = mainChar.GetComponentInChildren<Rigidbody>();
    }
    private void Update()
    {
        if (gameContinue)
        {
            MoveClamp();
        }
        else
        {
            mathPanel.SetActive(true);
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
            mathPanel.SetActive(true);
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
