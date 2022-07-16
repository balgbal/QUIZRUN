using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool gameContinue = true;
    public GameObject gameOverPanel;
    #region character
    public FloatingJoystick floatingJoystick;
    public Rigidbody playerRB;
    public float rlSpeed;
    private float border = 5.0f;
    private GameObject mainChar;
    #endregion
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
            gameOverPanel.SetActive(true);
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
            gameOverPanel.SetActive(true);
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
