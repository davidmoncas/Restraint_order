using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inventory_object 
{
    public string objectName;
    public string description;
    public Sprite icon;

    public inventory_object(string objectName, string description, Sprite icon) {
        this.objectName = objectName;
        this.description = description;
        this.icon = icon;
    }

}
