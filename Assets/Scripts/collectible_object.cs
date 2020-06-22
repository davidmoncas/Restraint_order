using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectible_object : MonoBehaviour
{

    Transform player;
    public string objectName;
    public TextMeshPro bottomText;

    void Start()
    {
        player = FindObjectOfType<moveCharacter>().transform;
        
    }


    void Update()
    {
        if (Vector2.Distance(player.position, transform.position)<1) { print("esta cerca " + objectName); }
    }
}
