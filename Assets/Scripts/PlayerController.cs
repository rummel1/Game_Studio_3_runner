using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float minX, maxX;
}
public class PlayerController: MonoBehaviour
{
    private Rigidbody _rb;
    public Boundary boundary;

    [SerializeField] private Joystick _joystick;

   
    [SerializeField] private float _velocityRotationX;
    [SerializeField] private float _velocityRotationZ;
    [SerializeField] private float _speedBoat;
    
    
     public static float _forwardSpeed=150;
     public static float _leftrightSpeed=150;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,boundary.minX,boundary.maxX ), transform.position.y, transform.position.z);
        _rb.velocity=new Vector3(_joystick.Horizontal*_leftrightSpeed* Time.deltaTime, _rb.velocity.y,_rb.velocity.z);
        
        
        _rb.rotation=Quaternion.Euler(_rb.velocity.z*_velocityRotationZ,0,_rb.velocity.x*-_velocityRotationX);
    }

   

    private void OnTriggerEnter(Collider other)
    {
    }
}