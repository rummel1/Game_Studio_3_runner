using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WoodObstacle : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.WoodObstacle==true)
            {
                _rb.constraints = RigidbodyConstraints.None;
                _rb.useGravity = true;
            }
            if (PlayerController.WoodObstacle==false)
            {
                Destroy(gameObject);
                PirateSpawner.instance.DeletePirate();
            }
        }
       
    }
}
