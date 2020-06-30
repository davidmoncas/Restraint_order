using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialog_manager : MonoBehaviour
{

    public GameObject dialogContainer;
    public TextMeshProUGUI title;
    public TextMeshProUGUI dialog;
    public GameObject[] portraits;
    private Coroutine typingCoroutine;
    private bool runningCoroutine=false;
    private string completeMessage;


    void Start()
    {
        gameState.playing = false;
        openDialog("peter", "There's Ella, I realy need to know what is she saying, I need to know everything!", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogContainer.activeSelf)
            {
                if (runningCoroutine)   // show all the message
                {
                    StopCoroutine(typingCoroutine);
                    dialog.text = completeMessage;
                    runningCoroutine = false;
                }
                else {  // close the window
                    gameState.playing = true;
                    dialogContainer.SetActive(false);
                }
            }
        }
    }

    public void openDialog(string character, string message, int portraitNumber) {

       gameState.playing = false; //pause the game while showing the dialog

        completeMessage = message;
        dialogContainer.SetActive(true);
        title.text = character;
        typingCoroutine = StartCoroutine(writingDialog(message));

        foreach (GameObject portrait in portraits) {
            portrait.SetActive(false);
        }
        portraits[portraitNumber].SetActive(true);
    }


    private IEnumerator writingDialog(string message) {

       

        runningCoroutine = true;
        string showingMessage = "";
        dialog.text = showingMessage;
        for (int i = 0; i < message.Length; i++) {
            showingMessage += message[i];
            dialog.text = showingMessage;
            yield return new WaitForSeconds(0.05f);
        }

        runningCoroutine = false;
    }


}
