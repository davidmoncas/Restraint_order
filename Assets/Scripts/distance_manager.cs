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
    private dialog_manager dm;


    private bool seenIgor = false, seenDog = false, seenElla = false;
    public bool detected = false;

    private bool finishGame=false;
    private cameraMovement cm;

    public GameObject finalScreen;

    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        hb = GameObject.FindObjectOfType<Healthbar>();
        dm = GameObject.FindObjectOfType<dialog_manager>();
        cm = GameObject.FindObjectOfType<cameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        detected = false;
        for (int i=0;i<NPCS.Length;i++)
        {
            Vector2 dir = NPCS[i].bounds.center - player.position;
            if (!gameState.playing) return;

            RaycastHit2D hit = Physics2D.Raycast(player.position, dir.normalized , distances[i], ~ignoreLayer);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("NPC"))
                {
                    detected = true;
                    if (i == 0 && !seenElla) {
                        seenElla = true;
                        dm.openDialog("Ella", "Wait, I think someone is watching me...*", 2);
                    }

                    if (i == 1 && !seenIgor)
                    {
                        seenIgor = true;
                        dm.openDialog("Igor", "I heard that guy Peter is back in town, I hate him more than I hate ducks", 1);
                    }


                    if (i == 2 && !seenDog)
                    {
                        seenDog = true;
                        dm.openDialog("Peter", "That's her dog, I think he doesn't like me either", 0);
                    }


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

        if (Vector3.Distance(player.position, NPCS[0].bounds.center) < radius && !detected && !finishGame) {
            finishGame = true;
            gameState.playing = false;
            StartCoroutine(endingScene());
        }

    }


    private IEnumerator endingScene() {
        cm.target = NPCS[0].transform;
        dm.openDialog("Ella", "...As I was saying, I'll be there in the Shopping Mall at one o clock tomorrow...", 2);
        yield return new WaitForSeconds(5);
        cm.target = player;
        dm.openDialog("Peter", "Perfect!, I will follow her to the shopping mall", 0);
        yield return new WaitForSeconds(5);
        finalScreen.SetActive(true);
    }
}


