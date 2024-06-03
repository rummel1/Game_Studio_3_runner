using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeDifficultiy : MonoBehaviour
{

    public static bool StartButtonActive=false;
    
    private float _equalsTime;
    void Start()
    {
        //bir butona basılınca yani play(tek scene ile) oyun belirli bi zaman içinde(equals time a bağlı olarak) zorlaşmaya başlayacak
    }
    public void HarderLevelFalse()
    {
        StartButtonActive = false;
        PlayerController._forwardSpeed = 300;
        PlayerController.fastspeed = 700;
        PlayerController.slowspeed = 300;
    }
    public void HarderLevelActive()
    {
        StartButtonActive = true;
        _equalsTime = Time.time + 1;
    }
    void Update()
    {
        if (StartButtonActive)
        { 
            if (Time.time>_equalsTime && PlayerController._forwardSpeed<1001)
            {
                PlayerController._forwardSpeed += 2;
                PlayerController.fastspeed += 2;
                PlayerController.slowspeed += 2;
                _equalsTime += 1;
                Debug.Log(PlayerController._forwardSpeed);
                
                
            }
        }
    }
}
