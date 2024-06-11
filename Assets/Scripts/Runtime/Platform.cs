using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer MeshRenderer;
    public static Vector3 endPoint;
    void Start()
    {
        endPoint = MeshRenderer.bounds.size + this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
