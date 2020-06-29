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

   

    public List<GameObject> objects_inventory;
    private string selectedObject;

    public GameObject[] inventorySlots;

    private void Start()
    {
        objects_inventory = new List<GameObject>();
    }


    public void closeInventory() {
        inventoryContainer.SetActive(false);
    }

    public void openInventory() {
        inventoryContainer.SetActive(true);
    }

    public void addObject(string objectName, Sprite icon)
    { // add a new object to the list

        int emptySlot=-1;
        for (int i = 0; i < 3; i++) {
            print(inventorySlots[i].GetComponent<inventory_object>().objectName);
            if (inventorySlots[i].GetComponent<inventory_object>().objectName == "") { 
                emptySlot = i;
                break;
            }
        }


        inventorySlots[emptySlot].AddComponent<Image>();
        inventorySlots[emptySlot].GetComponent<Image>().sprite = icon;
        inventorySlots[emptySlot].GetComponent<inventory_object>().objectName = objectName;

        //GameObject newIcon = Instantiate(icon_template);
        //newIcon.GetComponent<inventory_object>().objectName = objectName;
        //newIcon.GetComponent<Image>().sprite = icon;
        //newIcon.transform.SetParent(inventoryContainer.transform);

        //objects_inventory.Add(newIcon);
        //arrangeObjects();
    }

    public void arrangeObjects()
    {

        float posX = -32; //position of the first element in the inventory
        for (int i = 0; i < objects_inventory.Count; i++)
        { // show all the objects in the inventory

            objects_inventory[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(posX + i * 20, 8.3f, 0);
            objects_inventory[i].GetComponent<RectTransform>().localScale = new Vector3(0.14f, 0.14f, 0.14f);
        }
    }


        public void selectObject(string objectName , RectTransform pos)
    {
        if (!selectionRectangle.activeSelf) selectionRectangle.SetActive(true);
        selectionRectangle.GetComponent<RectTransform>().anchoredPosition = pos.anchoredPosition;
        title_object.text = objectName;
        selectedObject = objectName;
    }

}
