using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PirateSpawner : MonoBehaviour
{

    public GameObject retryButton;
    public GameObject MainMenuButton;
    public static PirateSpawner instance { get; set; }
    public static int pirateCount=1;
    private GameObject[] pirateObj;
    [SerializeField] private GameObject piratePrefab;
    [SerializeField] private Transform pirateShip;
    [SerializeField] private Transform[] piratePositions;

    public AudioClip[] obstacleSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        pirateObj = new GameObject[1];
        pirateObj = new GameObject[2];
        pirateObj = new GameObject[3];
        pirateObj = new GameObject[4];
        pirateObj = new GameObject[5];
    }

    private void Update()
    {
        Debug.Log("pirate"+pirateCount);
        Debug.Log(PlayerController.MaxHealth);
        if (PlayerController.MaxHealth>0)
        {
            retryButton.SetActive(false);
            MainMenuButton.SetActive(false);
        }
    }
    
    public void SpawnPirate()
    {
            switch (pirateCount)
            {
                case 1:
                    pirateObj[0] = Instantiate(piratePrefab, new Vector3(piratePositions[0].position.x,piratePositions[0].position.y,piratePositions[0].position.z), Quaternion.identity, pirateShip);
                    pirateCount++;
                    PlayerController.MaxHealth++;
                    break;
                case 2:
                    pirateObj[1] = Instantiate(piratePrefab, new Vector3(piratePositions[1].position.x,piratePositions[1].position.y,piratePositions[1].position.z), Quaternion.identity, pirateShip);
                    pirateCount++;
                    PlayerController.MaxHealth++;
                    break;
                case 3:
                    pirateObj[2] =Instantiate(piratePrefab, new Vector3(piratePositions[2].position.x,piratePositions[2].position.y,piratePositions[2].position.z), Quaternion.identity, pirateShip);
                    pirateCount++;
                    PlayerController.MaxHealth++;
                    break;
                case 4:
                    pirateObj[3] = Instantiate(piratePrefab, new Vector3(piratePositions[3].position.x,piratePositions[3].position.y,piratePositions[3].position.z), Quaternion.identity, pirateShip);
                    pirateCount++;
                    PlayerController.MaxHealth++;
                    break;
                case 5:
                    pirateObj[4] = Instantiate(piratePrefab, new Vector3(piratePositions[4].position.x,piratePositions[4].position.y,piratePositions[4].position.z), Quaternion.identity, pirateShip);
                    pirateCount++;
                    PlayerController.MaxHealth++;
                    break;
            }
    }
    
    public void DeletePirate()
    {
            switch (pirateCount)
            {
                case 1:
                    SoundManager.instance.PlaySound(obstacleSound[Random.Range(0,2)]);
                    PlayerController.MaxHealth--;
                    CinemachineShake.instance.ShakeCamera(10f,0.6f);
                    StartCoroutine(VideoRetry());
                    break;
                case 2:
                    SoundManager.instance.PlaySound(obstacleSound[Random.Range(0,2)]);
                    Destroy(pirateObj[0]);
                    pirateCount--;
                    PlayerController.MaxHealth--;
                    CinemachineShake.instance.ShakeCamera(10f,0.6f);
                    break;
                case 3:
                    SoundManager.instance.PlaySound(obstacleSound[Random.Range(0,2)]);
                    Destroy(pirateObj[1]);
                    pirateCount--;
                    PlayerController.MaxHealth--;
                    CinemachineShake.instance.ShakeCamera(10f,0.6f);
                    break;
                case 4:
                    SoundManager.instance.PlaySound(obstacleSound[Random.Range(0,2)]);
                    Destroy(pirateObj[2]);
                    pirateCount--;
                    PlayerController.MaxHealth--;
                    CinemachineShake.instance.ShakeCamera(10f,0.6f);
                    break;
                case 5:
                    SoundManager.instance.PlaySound(obstacleSound[Random.Range(0,2)]);
                    Destroy(pirateObj[3]);
                    pirateCount--;
                    PlayerController.MaxHealth--;
                    CinemachineShake.instance.ShakeCamera(10f,0.6f);
                    break;
                case 6:
                    SoundManager.instance.PlaySound(obstacleSound[Random.Range(0,2)]);
                    Destroy(pirateObj[4]);
                    pirateCount--;
                    PlayerController.MaxHealth--;
                    CinemachineShake.instance.ShakeCamera(10f,0.6f);
                    break;
            }
              
    }
   private IEnumerator VideoRetry()
   {
       yield return new WaitForSeconds(10);
       retryButton.SetActive(true);
       MainMenuButton.SetActive(true);
           
    }

    
}
