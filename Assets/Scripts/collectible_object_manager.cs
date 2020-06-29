using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectible_object_manager : MonoBehaviour
{

    private List<collectible_object> collectibles;
    private Transform player;
    public TextMeshProUGUI textBottom;
    private collectible_object selectedObject;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        //get the transform object of the player
        player = FindObjectOfType<moveCharacter>().transform;
        inventory = FindObjectOfType<Inventory>();

        // get the position of all the collectibles on the scene and put them in a list
        collectibles = new List<collectible_object>();
        foreach (collectible_object obj in FindObjectsOfType<collectible_object>()) {
            collectibles.Add( obj.GetComponent<collectible_object>());
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        // if the player press spacebar near to an object it should grab it (and destroy the gameobject)
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (selectedObject != null) {

                inventory.addObject(selectedObject.objectName, selectedObject.iconInventory);
                collectibles.Remove(selectedObject);
                Destroy(selectedObject.gameObject);

            }
        }


        // loop through all the collectibles to see if its near of any.
        foreach (collectible_object collectible in collectibles) {


            if (Vector2.Distance(collectible.pos, player.position) < 0.5)
            {

                collectible_object coll_prop = collectible.gameObject.GetComponent<collectible_object>();

                textBottom.text = "Grab " + coll_prop.objectName;
                selectedObject = collectible;
                return;
            }
        }
        textBottom.text = " ";
        selectedObject = null;


        


    }


    


}
