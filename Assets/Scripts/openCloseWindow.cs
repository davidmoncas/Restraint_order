﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCloseWindow : MonoBehaviour
{
    public GameObject inventoryContainer;

    public void closeInventory()
    {
        inventoryContainer.SetActive(false);
        gameState.playing = true;
    }

    public void openInventory()
    {
        inventoryContainer.SetActive(true);
        gameState.playing = false;
    }
}
