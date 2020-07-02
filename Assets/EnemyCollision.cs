using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public Transform player;
    public Transform spawnPoint;
    private void Update()
    {

    

        if (Vector3.Distance(player.position, transform.position) < 0.9f) {

            FindObjectOfType<gameState>().gameOver();
            Time.timeScale = 0;
        }

        else if (Vector3.Distance(spawnPoint.position, transform.position) < 0.5f)
        {

            GetComponent<Animator>().Play("idle_right");
        }
    }

}
