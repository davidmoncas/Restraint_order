using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectible_object_manager : MonoBehaviour
{

    private List<collectible_object> collectibles;
    private Transform player;
    public TextMeshProUGUI textBottom;
    public GameObject textBottomContainer;
    private collectible_object selectedObject;
    private dialogObject selectedDialog;
    private Inventory inventory;
    private dialog_manager dm;

    public Animator backpack;

    private List<dialogObject> dialogs;

    // Start is called before the first frame update
    void Start()
    {
        //get the transform object of the player
        player = FindObjectOfType<moveCharacter>().transform;
        inventory = FindObjectOfType<Inventory>();

        dm = FindObjectOfType<dialog_manager>();

        // get the position of all the collectibles on the scene and put them in a list
        collectibles = new List<collectible_object>();
        foreach (collectible_object obj in FindObjectsOfType<collectible_object>()) {
            collectibles.Add( obj.GetComponent<collectible_object>());
            
        }

        // get the position of all the dialogs on the scene and put them in a list
        dialogs = new List<dialogObject>();
        foreach (dialogObject dialog in FindObjectsOfType<dialogObject>())
        {
            dialogs.Add(dialog);

        }

    }

    // Update is called once per frame
    void Update()
    {

        // if the player press spacebar near to an object it should grab it (and destroy the gameobject)
        if (Input.GetKeyDown(KeyCode.Space) ) {
            if (selectedObject != null) {

                inventory.addObject(selectedObject.objectName, selectedObject.iconInventory);
                collectibles.Remove(selectedObject);
                backpack.SetTrigger("grow");
                Destroy(selectedObject.gameObject);

            }

            if (selectedDialog != null) {
                dm.openDialog("Peter", selectedDialog.messages[Random.Range(0, selectedDialog.messages.Length)], 0);
            }
        }

        if (gameState.playing)
        {
            // loop through all the collectibles to see if its near of any.
            foreach (collectible_object collectible in collectibles)
            {


                if (Vector2.Distance(collectible.transform.position, player.position) < 0.5)
                {

                    collectible_object coll_prop = collectible.gameObject.GetComponent<collectible_object>();

                    textBottomContainer.SetActive(true);
                    textBottom.text = "Grab " + coll_prop.objectName;
                    selectedObject = collectible;
                    
                    return;
                }
            }

            // loop through all the collectibles to see if its near of any.
            foreach (dialogObject dialog in dialogs)
            {
                if (Vector2.Distance(dialog.transform.position, player.position) < 1)
                {

                    textBottomContainer.SetActive(true);
                    textBottom.text = dialog.title;
                    selectedDialog = dialog;
                    return;
                }
            }
        }



        textBottomContainer.SetActive(false);
        textBottom.text = " ";
        selectedObject = null;
        selectedDialog = null;

        


    }


    


}
