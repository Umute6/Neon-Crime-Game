using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text dialogueTextMP; // var du text, ATTENTION TMP_Text new type for text!!
    public TMP_Text[] answersText;
    public GameObject[] answerButtons; // setActive
    public TMP_Text nameNPCText;
   // public Sprite spriteNPC;
    public GameObject dialogueBox; //tmtc, la box du dial mais peut-être changer l'encrage

    private Queue<DialogueMessage> dialogueQueue = new Queue<DialogueMessage>(); // FIFO, method for dialogues and lines
    private DialogueMessage currentMessage; // reprend le type DialogueMessage et la list answers est connectée
                                            // private DialogueMessage currentNPC;
                                            // public onClickButtonAnswer buttonAnswerHandler; //ajoute une réf au gestionnaire de boutons


    //method pour afficher nouveau msg
    public void StartDialogue(DialogueMessage message)
    {
        dialogueQueue.Clear();
        // currentNPC = nameNPC;
        currentMessage = message; //ajoute chaque msg de la chaîne au dialogueQueue

        while (currentMessage != null) // ajoute chaque msg de la chaîne au dialogueQueue
        {
            dialogueQueue.Enqueue(currentMessage); // '.' opérateur de traversée
            currentMessage = currentMessage.GetNextMessage(); // GetNextMessage() se trouve dans le ScriptableObject
        }

        //affiche le 1er msg
        DisplayNextMessage();
        //DisplaySpriteNPC();
    }

    //method pour afficher le prochain msg dans la file d'attente
    public void DisplayNextMessage()
    {
        if (dialogueQueue.Count == 0)
        {
            // cache la bôte de dial si file d'attente vide
            dialogueBox.SetActive(false);
            return;
        }
        //affiche le next msg dans file d'attente
        currentMessage = dialogueQueue.Dequeue();
        dialogueTextMP.text = currentMessage.message;
        dialogueBox.SetActive(true);

        if (currentMessage.next.Length > 1)
        {
            DisplayAnswers();
        }
        else
        {
            HideAnswers();
        }
        DisplayNameNPC();
    }

    private void DisplayNameNPC()
    {
        if (currentMessage != null)
        {
            if (!string.IsNullOrEmpty(currentMessage.nameNPC))
            {
                nameNPCText.text = currentMessage.nameNPC;
            }
            else
            {
                nameNPCText.text = "NPC";
            }
        }
        else
        {
            nameNPCText.text = "no NPC available";
        }

    }

    // private void DisplaySpriteNPC()
    // {
    //     if(currentMessage != null)
    //     {
    //         if (spriteNPC != null)
    //     }
    // }

    private void DisplayAnswers()
    {
        if (currentMessage != null && currentMessage.answers != null)
        {
            // affiche les réponses possible dans le texte des réponses
            for (int i = 0; i < answersText.Length && i < currentMessage.answers.Length; i++)
            {
                answersText[i].text = currentMessage.answers[i];
                answerButtons[i].SetActive(true);
            }

        }
        else
        {
            foreach (var answerText in answersText)
            {
                answerText.text = "no answer available";
            }
        }
    }

    private void HideAnswers()
    {
        foreach (var answerButton in answerButtons)
        {
            answerButton.SetActive(false);
        }
    }

    public void PlayerSelectedAnswer(int answerIndex)
    {
        if (currentMessage != null && currentMessage.next != null && answerIndex < currentMessage.next.Length)
        {
            //récupère le prochain msg en fonction de la réponse choisie
            currentMessage.SetSelectedAnswerIndex(answerIndex);
            DialogueMessage nextMessage = currentMessage.GetNextMessage(answerIndex);
            StartDialogue(nextMessage);
        }
    }

  
}
