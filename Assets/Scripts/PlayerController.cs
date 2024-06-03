using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using LeaderboardCreatorDemo;
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

    public LeaderboardManager LeaderboardManager;
    public SpeedBar SpeedBar;
    //[SerializeField] private Joystick _joystick;

    private Rigidbody _rb;
    public static int MaxHealth=1;
    [SerializeField] private float _velocityRotationX;
    [SerializeField] private float _velocityRotationZ;
    [SerializeField] private float _speedBoat;


    private int _levelScore;
    private int _bestScore;
    public static int fastspeed=700;
    public static int slowspeed=300;
    private int _upspeed;
    private bool _upSpeedControl;


    public GameObject sound;
    public Animator Pirateanim;
    public GameObject deadScreen;
    public static int _forwardSpeed=300;
    public static int _leftrightSpeed=300;
    public static bool WoodObstacle;

    public void Start()
    {
        SpeedBar.SetMinValue(_upspeed);
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(nameof(PirateAnim));
    }

    private void Update()
    {
        if (MaxHealth<=0)
        {  
            deadScreen.SetActive(true); 
            gameObject.SetActive(false);
            sound.SetActive(false);
            _levelScore = ScoreSystem.instance.score;
            LeaderboardManager.UploadEntry();
            if (_levelScore>_bestScore)
            {
                //best score'u kaydet ve yazdır.
            }
            
            
        }
        if (Input.GetKeyDown(KeyCode.W)&& _upspeed<100)
        {
            _forwardSpeed =fastspeed;
            _upSpeedControl = true;
            WoodObstacle = true;

        }

        if (_upspeed==100)
        {
            _upSpeedControl = false;
        }
        if (Input.GetKeyUp(KeyCode.W)|| _upspeed==100)
        {
            _forwardSpeed = slowspeed;
            _upSpeedControl = false;
            WoodObstacle = false;
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

    private IEnumerator PirateAnim()
    {
        while (true)
        {
            
            float waitTime = UnityEngine.Random.Range(5f, 15f);
            Pirateanim.SetTrigger("Ter");
            yield return new WaitForSeconds(waitTime);
        }
        
        // ReSharper disable once IteratorNeverReturns
    }
    public void RetryButton()
    {
        sound.SetActive(true);
        ScoreSystem.instance.ResetScore();
        PirateSpawner.pirateCount = 1;
        gameObject.SetActive(true);
        MaxHealth = 1;
        transform.position = new Vector3(0, 0, 0);
        deadScreen.SetActive(false);
        
    }

    public void MainMenu()
    {
        ScoreSystem.instance.ResetScore();
        PirateSpawner.pirateCount = 1;
        MaxHealth = 1;
        transform.position = new Vector3(0, 0, 0);
    }
    
}