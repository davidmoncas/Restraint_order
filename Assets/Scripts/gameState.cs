using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class gameState : MonoBehaviour
{

    public GameObject gameOverCanvas;

    public static bool playing;

    public void gameOver() {
        playing = false;
        gameOverCanvas.SetActive(true);
    }
}
