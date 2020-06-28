using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance_manager : MonoBehaviour
{

    public int numberNPCS;

    public Transform[] NPCS;
    public float[] distances;   //radio of sight of the npc

    public Transform player;
    private int maxDist=20;
    public LayerMask ignoreLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        foreach (Transform npc in NPCS)
        {

            Vector2 dir = npc.position - player.position;

            RaycastHit2D hit = Physics2D.Raycast(player.position, dir , maxDist, ~ignoreLayer);
            if (hit.collider != null)
            {
               // print(hit.collider);
            }



        }


    }
}


