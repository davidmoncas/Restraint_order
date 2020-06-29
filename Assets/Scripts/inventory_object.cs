using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_object : MonoBehaviour
{
    public string objectName;
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void OnPointerDown()
    {
        if(this.objectName!="")
        inventory.selectObject(this.objectName , this.GetComponent<RectTransform>());

    }

}
