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

   

    private string selectedObject;

    public GameObject[] inventorySlots;

    private void Start()
    {
        
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

    }


        public void selectObject(string objectName , RectTransform pos)
    {
        if (!selectionRectangle.activeSelf) selectionRectangle.SetActive(true);
        selectionRectangle.GetComponent<RectTransform>().anchoredPosition = pos.anchoredPosition;
        title_object.text = objectName;
        selectedObject = objectName;
    }

}
