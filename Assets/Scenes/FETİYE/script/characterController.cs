using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }
    //private void FixedUpdate()
    //{
    //    _rigidbody.velocity = new Vector3(x: 0f, y: 0f, z: speed);
    //}
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    speed = 1.0f;
        //}
        //else
        //{
        //    speed = 0.0f;
        //}
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y, charPos.z + (Input.GetAxis("Vertical")*speed * Time.deltaTime));
        transform.position = charPos; 
        if (Input.GetAxis("Vertical") == 0.0f && Input.GetAxis("Horizontal") == 0.0f)
        { 
            _animator.SetFloat("Speed", 0.0f); 
        }
        else
        {
            _animator.SetFloat("Speed", 1.0f);
        }
       
        
    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y + 2.0f, charPos.z -3.0f);
    }
}
