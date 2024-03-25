using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;
    [SerializeField] private Transform player;
    

    private float secondTime=60.1f;
    private float firstTime = 90.1f;
    
    void Start()
    {
        InvokeRepeating(nameof(FirstPlatformSpawn),0,3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > secondTime)
        {
            CancelInvoke(nameof(FirstPlatformSpawn));
            Invoke(nameof(SecondPlatform),0);
            secondTime += 90.1f;
            return;
        }

        if (Time.time>firstTime)
        {
            CancelInvoke(nameof(SecondPlatformSpawn));
            Invoke(nameof(FirstPlatform),0);
            firstTime += 90.1f;
            return;
        }
    }

    
    private void SecondPlatformSpawn()
    {
       
        GameObject nesne = Instantiate(platform2,new Vector3(platform2.transform.position.x,platform2.transform.position.y,Platform.endPoint.z), Quaternion.identity);
        Platform platform = nesne.GetComponent<Platform>();
        Destroy(nesne,25);
    }
    
    private void FirstPlatformSpawn()
    {
        GameObject nesne = Instantiate(platform1,new Vector3(platform1.transform.position.x,platform1.transform.position.y,Platform.endPoint.z), Quaternion.identity);
        Destroy(nesne,25);
    }

    private void SecondPlatform()
    {
        InvokeRepeating(nameof(SecondPlatformSpawn), 0f, 6);
    }
    private void FirstPlatform()
    {
        InvokeRepeating(nameof(FirstPlatformSpawn), 0f, 6);
    }
}
