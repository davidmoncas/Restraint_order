using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryContainer;
    public GameObject icon_template;
 
    public List<inventory_object> objects_inventory;

    private void Start()
    {
        objects_inventory = new List<inventory_object>();
    }


    public void closeInventory() {
        inventoryContainer.SetActive(false);
    }

    public void openInventory() {
        inventoryContainer.SetActive(true);
    }

    public void addObject(inventory_object obj) { // add a new object to the list
        objects_inventory.Add(obj);
        arrangeObjects();
    }

    public void arrangeObjects() {


        //clear all the objects inside the container (not the most efficient way)
        foreach (Transform child in inventoryContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }


        float posX = -32; //position of the first element in the inventory
        for (int i = 0; i < objects_inventory.Count; i++) { // show all the objects in the inventory
            GameObject newIcon = Instantiate(icon_template);
            newIcon.GetComponent<Image>().sprite = objects_inventory[i].icon;
            newIcon.transform.parent = inventoryContainer.transform;
            newIcon.GetComponent<RectTransform>().anchoredPosition = new Vector3(posX + i * 20, 8.3f, 0);
            newIcon.GetComponent<RectTransform>().localScale = new Vector3(0.14f, 0.14f, 0.14f);
        }
    }

}
