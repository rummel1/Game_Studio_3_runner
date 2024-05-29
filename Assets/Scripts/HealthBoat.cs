using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoat : MonoBehaviour, IHealth
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Health()
    {
        Destroy(gameObject);
        PirateSpawner.instance.SpawnPirate();
    }
}
