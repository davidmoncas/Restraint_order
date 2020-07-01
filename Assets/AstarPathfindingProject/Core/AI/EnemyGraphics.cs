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


    // Update is called once per frame
    void Update()
    {

        print(Vector3.Distance(player.position, transform.position));
        if (Vector3.Distance(player.position, transform.position) < 5) aiDestin.target = player;
        else aiDestin.target = spawnPoint;

        if (aiPath.desiredVelocity.x >= 0.01f) transform.localScale = new Vector3(-1,1,1);
        else if(aiPath.desiredVelocity.x<=-0.01f) transform.localScale = new Vector3(1, 1, 1);
    }
}
