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
   
    public Boundary boundary;

    public SpeedBar SpeedBar;
    //[SerializeField] private Joystick _joystick;

    private Rigidbody _rb;
    private int _maxHealth=3;
    [SerializeField] private float _velocityRotationX;
    [SerializeField] private float _velocityRotationZ;
    [SerializeField] private float _speedBoat;


    private int _fastspeed=400;
    private int _slowspeed=150;
    private int _upspeed;
    private bool _upSpeedControl;


    public GameObject deadScreen;
    public static float _forwardSpeed=150;
    public static float _leftrightSpeed=150;

    public void Start()
    {
        SpeedBar.SetMinValue(_upspeed);
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_maxHealth==0)
        {
            deadScreen.SetActive(true);
            gameObject.SetActive(false);
            
        }
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

    public void RetryButton()
    {
        gameObject.SetActive(true);
        _maxHealth = 3;
        transform.position = new Vector3(0, 0, 0);
        deadScreen.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.CompareTag("Fish"))
        {
            Debug.Log("fish");
            _maxHealth --;
        }
        if (other.CompareTag("Wood"))
        {
            Debug.Log("wood");
            _maxHealth --;
        }
        if (other.CompareTag("Stone"))
        {
            _maxHealth --;
            Debug.Log("stone");
        }
    }
}