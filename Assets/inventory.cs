using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public GameObject inventoryContainer;
    
    public void closeInventory() {
        inventoryContainer.SetActive(false);
    }

    public void openInventory() {
        inventoryContainer.SetActive(true);
    }



}
