using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform player;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
        //this.transform.position = Vector2.Lerp(this.transform.position, player.transform.position, 0.1f);

        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, 0.3f);

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        
    }
}
