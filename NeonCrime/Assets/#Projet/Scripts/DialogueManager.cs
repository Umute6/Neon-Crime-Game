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
    public TMP_Text answersText;
    public GameObject dialogueBox; //tmtc, la box du dial mais peut-être changer l'encrage

    private Queue<string> dialogueQueue = new Queue<string>(); // FIFO, method for dialogues and lines
    private DialogueMessage currentMessage; // reprend le type DialogueMessage et la list answers est connectée

    
   //method pour afficher nouveau msg
   public void StartDialogue (DialogueMessage message)
   {
    dialogueQueue.Clear();
    DialogueMessage currentMessage = message; //ajoute chaque msg de la chaîne au dialogueQueue

    while (currentMessage != null) // ajoute chaque msg de la chaîne au dialogueQueue
    {
        dialogueQueue.Enqueue(currentMessage.message);
        currentMessage = currentMessage.GetNextMessage();
    }

    //affiche le 1er msg
    DisplayNextMessage();
    DisplayAnswers();
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
    string message = dialogueQueue.Dequeue();
    dialogueTextMP.text = message;
    dialogueBox.SetActive(true);

    DisplayAnswers();
   }

   private void DisplayAnswers()
   {
    if (currentMessage != null && currentMessage.answers != null)
    {
        // affiche les réponses possible dans le texte des réponses
        string answers = string.Join("\n", currentMessage.answers);
        answersText.text = answers;
    }
    answersText.text = "no answer available";
   }
   public void PlayerSelectedAnswer(int answerIndex)
   {
    if (currentMessage != null && currentMessage.next != null && answerIndex < currentMessage.next.Length)
    {
        //récupère le prochain msg en fonction de la réponse choisie
        DialogueMessage nextMessage = currentMessage.next[answerIndex];
        StartDialogue(nextMessage);
    }
   }
}
