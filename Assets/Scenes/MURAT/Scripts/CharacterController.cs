using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public FloatingJoystick floatingJoystick;
    public Rigidbody playerRB;
    public float rlSpeed;
    private GameController gameControllerScript;
    private float border = 5.0f;

    private void Start()
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void Update()
    {
        if (gameControllerScript.gameContinue)
        {
            MoveClamp();
        }
    }
    private void FixedUpdate()
    {
        if (gameControllerScript.gameContinue)
        {
            Move();
        }
    }
    private void MoveClamp()
    {
        float posX = Mathf.Clamp(transform.position.x, -border, border);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
    public void Move()
    {
        Vector3 direction = Vector3.right * floatingJoystick.Horizontal;
        playerRB.AddForce(direction * rlSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
