using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryContainer;
    public GameObject icon_template;
    public TextMeshProUGUI description;
    public TextMeshProUGUI title_object;
    public GameObject selectionRectangle;
 
    public List<GameObject> objects_inventory;
    private GameObject selectedObject;

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

    public void addObject(string objectName, string description, Sprite icon) { // add a new object to the list


        GameObject newIcon = Instantiate(icon_template);
        newIcon.GetComponent<inventory_object>().description = description;
        newIcon.GetComponent<inventory_object>().objectName = objectName;
        newIcon.GetComponent<Image>().sprite = icon;
        newIcon.transform.SetParent( inventoryContainer.transform);




        objects_inventory.Add(newIcon);
        arrangeObjects();
    }

    public void arrangeObjects() {

        float posX = -32; //position of the first element in the inventory
        for (int i = 0; i < objects_inventory.Count; i++)
        { // show all the objects in the inventory

            objects_inventory[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(posX + i * 20, 8.3f, 0);
            objects_inventory[i].GetComponent<RectTransform>().localScale = new Vector3(0.14f, 0.14f, 0.14f);
        }
    }

    public void selectObject(inventory_object obj) {
        if (!selectionRectangle.activeSelf) selectionRectangle.SetActive(true);
        selectionRectangle.GetComponent<RectTransform>().anchoredPosition = obj.GetComponent<RectTransform>().anchoredPosition;
        description.text = obj.description;
        title_object.text = obj.objectName;
        selectedObject = obj.gameObject;
    }

}
