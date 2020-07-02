using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        
    }


    void Update()
    {
     
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, 0.3f);

        this.transform.position = new Vector3(Mathf.Clamp( this.transform.position.x,-1.82f,2.85f), Mathf.Clamp( this.transform.position.y,-1.5f,1.1f), -10);
        
    }
}
