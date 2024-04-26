using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Obstacles : MonoBehaviour, IDamage
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        Destroy(gameObject);
        PlayerController.MaxHealth -= 1;
    }
}
