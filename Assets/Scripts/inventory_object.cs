using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required when using Event data.


public class inventory_object :MonoBehaviour, IPointerDownHandler
{
    public string objectName;
    public string description;
    private Inventory inventory;


    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        inventory.selectObject(this);
    }

}
