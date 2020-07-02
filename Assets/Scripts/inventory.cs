using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryContainer;
    public GameObject icon_template;
    public TextMeshProUGUI title_object;
    public GameObject selectionRectangle;
    public GameObject inventory;

    public Animator duck , igor , dog;

    private cameraMovement cm;


    private GameObject selectedObject;

    public GameObject[] inventorySlots;

    private void Start()
    {
        cm = GameObject.FindObjectOfType<cameraMovement>();
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

        if (selectedObject.GetComponent<inventory_object>().objectName == "Bread crumbs") { // using the bread
            StartCoroutine(setCameraTarget(duck.transform, 7));
            igor.SetTrigger("run");
            duck.SetTrigger("chase");

            restartSlot();
        }


        if (selectedObject.GetComponent<inventory_object>().objectName == "Bone")   //using the bone
        {
            StartCoroutine(setCameraTarget(dog.transform, 6));
            Destroy(dog.GetComponent<Collider2D>());
            dog.SetTrigger("run");
            restartSlot();
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
