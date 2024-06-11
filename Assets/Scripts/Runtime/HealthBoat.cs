using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoat : MonoBehaviour, IHealth
{
    public void Health()
    {
        Destroy(gameObject);
        PirateSpawner.instance.SpawnPirate();
    }
}
