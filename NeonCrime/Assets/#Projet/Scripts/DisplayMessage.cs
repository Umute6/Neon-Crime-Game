using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{
    public DialogueMessage currentMessage;
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        // Button button = continueButton.GetComponent<Button>();
        // button.onClick.AddListener(ContinueDialogue);

        if (dialogueManager == null)
        {
            // si le DialogueManager n'est pas attribué, recherche-le dans la scène
            dialogueManager = FindObjectOfType<DialogueManager>();
            if (dialogueManager == null)
            {
                {
                    Debug.LogError("DialogueManager not assigned");
                    return;
                }
            }
        }

        // commence le dialogue avec le 1er msg
        dialogueManager.StartDialogue(currentMessage);
    }




    // Update is called once per frame
    void Update()
    {
        //appuyez sur n'importe quelle touche pour afficher le next msg
        if (Input.GetMouseButtonDown(0) && dialogueManager.IsCurrentMessageSkippable())
        {
            dialogueManager.DisplayNextMessage();

        }

        //if(answerIndex.OnClick)
    }
    // void ContinueDialogue()
    // {
    //     Debug.Log("Clicked");
    // }
}

