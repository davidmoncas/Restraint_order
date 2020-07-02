using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGraphics : MonoBehaviour
{

    public AIPath aiPath;
    public Transform spawnPoint;
    public AIDestinationSetter aiDestin;
    public Transform player;
    public Animator animator;

    bool switchDir = false;
    // Update is called once per frame
    void Update()
    {

     print(Vector3.Distance(player.position, transform.position));
        if (Vector3.Distance(player.position, transform.position) < 5) aiDestin.target = player;
        else aiDestin.target = spawnPoint;

        if (transform.position == Vector3.zero) animator.Play("idle_right");




            if (aiPath.desiredVelocity.x >= 0.01f) {
          //  transform.localScale = new Vector3(-1, 1, 1);
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("walk_left"))
            animator.Play("walk_left");

        }
        else if (aiPath.desiredVelocity.x <= -0.01f) {
           // transform.localScale = new Vector3(1, 1, 1);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("walk_right"))
                animator.Play("walk_right");
        }


        /*
      if (aiPath.desiredVelocity.y >= 0.1f)
        {
            //  transform.localScale = new Vector3(-1, 1, 1);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("walk_up"))
                animator.Play("walk_up");

        }
        else if (aiPath.desiredVelocity.y <= -0.1f)
        {
            // transform.localScale = new Vector3(1, 1, 1);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("walk_down"))
                animator.Play("walk_down");
        }
     */  
    }

 
}
