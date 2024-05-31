using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private GameObject fish1;
    [SerializeField] private Transform player;
    private Vector3 eren;
    

    private float secondTime=60.1f;
    private float firstTime = 90.1f;
    
    public void Start()
    {
        foreach (var o in GameObject.FindGameObjectsWithTag("Environment")) Destroy(o);
       
        Platform.endPoint = new Vector3(0, 0, 0);
        StartCoroutine(FirstSpawn());
        InvokeRepeating(nameof(FirstPlatformSpawn),1,3);
        InvokeRepeating(nameof(FirstFishSpawn),4,Random.Range(5,10));
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

    IEnumerator FirstSpawn()
    {
        GameObject nesne1 = Instantiate(platforms[0],new Vector3(platforms[0].transform.position.x,platforms[0].transform.position.y,Platform.endPoint.z), Quaternion.identity);
        Destroy(nesne1,40);
        yield return new WaitForSeconds(0.01f);
        for (int i = 0; i < 4; i++)
        {
            GameObject platform = platforms[Random.Range(0, 3)+Random.Range(0, 3)+Random.Range(0, 3)+Random.Range(0, 4)];
            GameObject nesne = Instantiate(platform,new Vector3(platform.transform.position.x,platform.transform.position.y,Platform.endPoint.z), Quaternion.identity);
            Destroy(nesne,60);
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void FirstFishSpawn()
    {
        
       // GameObject nesne = Instantiate(fish1,new Vector3(fish1.transform.position.x,fish1.transform.position.y,player.position.z+Random.Range(5,10)), Quaternion.identity);
       // Destroy(nesne,15);
    }
    private void SecondPlatformSpawn()
    {
        int random = Random.Range(0, 3)+Random.Range(0, 3)+Random.Range(0, 3)+Random.Range(0, 4);
        GameObject nesne = Instantiate(platforms[random],new Vector3(platforms[random].transform.position.x,platforms[random].transform.position.y,Platform.endPoint.z), Quaternion.identity);
        Destroy(nesne,90);
    }
    
    private void FirstPlatformSpawn()
    {
        int random = Random.Range(0, 3);
        GameObject nesne = Instantiate(platforms[random],new Vector3(platforms[random].transform.position.x,platforms[random].transform.position.y,Platform.endPoint.z), Quaternion.identity);
        Destroy(nesne,90);
    }

    private void SecondPlatform()
    {
        InvokeRepeating(nameof(SecondPlatformSpawn), 0f, 3);
    }
    private void FirstPlatform()
    {
        InvokeRepeating(nameof(FirstPlatformSpawn), 0f, 3);
    }
}
