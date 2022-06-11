using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpForce = 4.0f;
    public float speed = 1.0f;
    private float moveDirection;
    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody _rigidbody2;
    private Animator _animator2;

    void Awake()
    {
        _animator2 = GetComponent<Animator>();
    }

    void Start()
    {
        _rigidbody2 = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2.velocity != Vector3.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        _rigidbody2.velocity = new Vector3(x: speed * moveDirection, _rigidbody2.velocity.y, z: speed);
        if ( jump == true)
        {
            _rigidbody2.velocity = new Vector3( x:jumpForce , _rigidbody2.velocity.y, _rigidbody2.velocity.z);
            jump = false;
        }
    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) { 
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _animator2.SetFloat("Speed", speed);
            } else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _animator2.SetFloat("Speed", speed);
            }
        }
            else if ( grounded == true )
            {
                moveDirection = 0.0f;
                _animator2.SetFloat("Speed", 0.0f);
            }

        if ( grounded == true && Input.GetKey(KeyCode.Space))
        {
            jump = true;
            grounded = false;
            _animator2.SetTrigger("jump");
            _animator2.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter(Collision collision)                                     
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            _animator2.SetBool("grounded", true);
            grounded = true;
        }

    }
}
