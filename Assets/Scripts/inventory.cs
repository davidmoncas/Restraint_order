using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryContainer;
    public TextMeshProUGUI title_object;
    public GameObject selectionRectangle;
    public GameObject inventory;

    public GameObject dialogContainer;

    public Animator duck , igor , dog;

    private Transform player;

    private cameraMovement cm;


    private GameObject selectedObject;
    private dialog_manager dm;

    public GameObject[] inventorySlots;

    private void Start()
    {
        cm = GameObject.FindObjectOfType<cameraMovement>();
        player = GameObject.FindObjectOfType<moveCharacter>().transform;
        dm = GameObject.FindObjectOfType<dialog_manager>();
    }



    public void addObject(string objectName, Sprite icon)
    { // add a new object to the list

        int emptySlot=-1;
        for (int i = 0; i < 3; i++) {
            if (inventorySlots[i].GetComponent<inventory_object>().objectName == "") { 
                emptySlot = i;
                break;
            }
        }


        inventorySlots[emptySlot].AddComponent<Image>();
        inventorySlots[emptySlot].GetComponent<Image>().sprite = icon;
        inventorySlots[emptySlot].GetComponent<inventory_object>().objectName = objectName;

    }


        public void selectObject(GameObject inventoryObject , RectTransform pos)
    {
        if (!selectionRectangle.activeSelf) selectionRectangle.SetActive(true);
        selectionRectangle.GetComponent<RectTransform>().anchoredPosition = pos.anchoredPosition;
        title_object.text = inventoryObject.GetComponent<inventory_object>().objectName;
        selectedObject = inventoryObject;
    }


    public void useObject() {

        if (dialogContainer.activeSelf) return;


        if (selectedObject.GetComponent<inventory_object>().objectName == "Bread crumbs") { // using the bread

            if (Vector2.Distance(player.position, duck.transform.position) < 4)
            {
                StartCoroutine(setCameraTarget(duck.transform, 7));
                igor.SetTrigger("run");
                duck.SetTrigger("chase");

                restartSlot();
                return;
            }
            else {
                dm.openDialog("Peter", "I don't think that throwing bread crumbs in here is useful...", 0);
            }
        }


        if (selectedObject.GetComponent<inventory_object>().objectName == "Bone")   //using the bone
        {

            if (Vector2.Distance(player.position, dog.transform.position) < 4)
            {
                StartCoroutine(setCameraTarget(dog.transform, 6));
                (dog.GetComponent<Collider2D>()).enabled = false;
                dog.SetTrigger("run");
                restartSlot();
                return;
            }
            else {
                dm.openDialog("Peter", "Throw the bone here? Why?", 0);
            }
        }

        if (selectedObject.GetComponent<inventory_object>().objectName == "Cherries") // using the berries
        {
            dm.openDialog("Peter", "hmmm, I wonder if she smells like cherries", 0);
        }


    }

    private void restartSlot() {
        inventory.SetActive(false);
        selectionRectangle.SetActive(false);
        selectedObject.GetComponent<inventory_object>().objectName = "";
        Destroy(selectedObject.GetComponent<Image>());
        title_object.text = "";

        selectedObject = null;
    }


    public IEnumerator setCameraTarget(Transform target, float time) {
        gameState.playing = false;
        Transform player = cm.target;
        cm.target = target;
        yield return new WaitForSeconds(time);
        cm.target = player;
        gameState.playing = true;
    }

}
