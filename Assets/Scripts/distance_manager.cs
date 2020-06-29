using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance_manager : MonoBehaviour
{

    public int numberNPCS;

    public Collider2D[] NPCS;
    public float[] distances;   //radio of sight of the npc
    public GameObject[] eyes;

    public Transform player;
    public LayerMask ignoreLayer;
    private Healthbar hb;

    // Start is called before the first frame update
    void Start()
    {
        hb = GameObject.FindObjectOfType<Healthbar>();
    }

    // Update is called once per frame
    void Update()
    {

        for (int i=0;i<NPCS.Length;i++)
        {
            Vector2 dir = NPCS[i].bounds.center - player.position;
            Debug.DrawLine(player.position, NPCS[i].bounds.center);

            RaycastHit2D hit = Physics2D.Raycast(player.position, dir.normalized , distances[i], ~ignoreLayer);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("NPC"))
                {
                    eyes[i].SetActive(true);
                    hb.health += (0.5f / hit.distance);
                    
                }
                else {
                    eyes[i].SetActive(false);
                }

              
            }
            else
            {
                eyes[i].SetActive(false);
            }


        }


    }
}


