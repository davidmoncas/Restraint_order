using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectible_object_manager : MonoBehaviour
{

    private List<Transform> collectibles;
    private Transform player;
    public TextMeshProUGUI textBottom;
    private GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        //get the transform object of the player
        player = FindObjectOfType<moveCharacter>().transform;

        // get the position of all the collectibles on the scene and put them in a list
        GameObject[] _collectibles = GameObject.FindGameObjectsWithTag("collectible");
        collectibles = new List<Transform>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("collectible")) {
            collectibles.Add( obj.transform);
            
        }
        print(collectibles);
    }

    // Update is called once per frame
    void Update()
    {

        // if the player press spacebar near to an object it should grab it (and destroy the gameobject)
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (selectedObject != null) {
                collectibles.Remove(selectedObject.transform);
                Destroy(selectedObject.gameObject);

            }
        }


        // loop through all the collectibles to see if its near of any.
        foreach (Transform collectiblePosition in collectibles) {
        if (Vector2.Distance(collectiblePosition.position, player.position) < 0.5) {
            textBottom.text = "Grab " + collectiblePosition.name;
            selectedObject = collectiblePosition.gameObject;
            return;
        } 
        }
        textBottom.text = " ";
        selectedObject = null;


        


    }


    


}
