using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Boundary
{
    public float minX, maxX;
}
public class PlayerController: MonoBehaviour
{
    private Rigidbody _rb;
    public Boundary boundary;

    public SpeedBar SpeedBar;
    //[SerializeField] private Joystick _joystick;

   
    [SerializeField] private float _velocityRotationX;
    [SerializeField] private float _velocityRotationZ;
    [SerializeField] private float _speedBoat;


    private int _fastspeed=400;
    private int _slowspeed=150;
    private int _upspeed;
    private bool _upSpeedControl;
    
    public static float _forwardSpeed=150;
    public static float _leftrightSpeed=150;

    public void Start()
    {
        SpeedBar.SetMinValue(_upspeed);
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)&& _upspeed<100)
        {
            _forwardSpeed =_fastspeed;
            _upSpeedControl = true;

        }

        if (_upspeed==100)
        {
            _upSpeedControl = false;
        }
        if (Input.GetKeyUp(KeyCode.W)|| _upspeed==100)
        {
            _forwardSpeed = _slowspeed;
            _upSpeedControl = false;
        }
        
        switch (_upSpeedControl)
        {
            case true:
            {
                if (_upspeed>=0)
                {
                    if (_upspeed < 100)
                    {
                        _upspeed += 1;
                        SpeedBar.SetValue(_upspeed);
                    }
                }

                break;
            }
            case false:
            {
                if (_upspeed>=2)
                {
                    _upspeed -= 1;
                    SpeedBar.SetValue(_upspeed);
                }

                break;
            }
        }
    }

    void FixedUpdate()
    {
        Debug.Log(_upspeed);
        _movement();
        ForwardMovement();
    }

    private void ForwardMovement()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, _forwardSpeed*Time.deltaTime);
    }
    private void _movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,boundary.minX,boundary.maxX ), transform.position.y, transform.position.z);
        _rb.velocity=new Vector3(horizontalInput*_leftrightSpeed* Time.deltaTime, _rb.velocity.y,_rb.velocity.z);
        
        
        _rb.rotation=Quaternion.Euler(_rb.velocity.z*_velocityRotationZ,0,_rb.velocity.x*-_velocityRotationX);
    }

   

    private void OnTriggerEnter(Collider other)
    {
    }
}