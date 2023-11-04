using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }
    //add method
    public void StartDialogue(Dialogues dialogues)
    {
        Debug.Log("Startin w/" + dialogues.name);
        sentences.Clear();
        foreach (string sentence in dialogues.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    // public void DisplayNextSentence()
    // {
    //     if(sentences.Count == 0)
    //     {
    //         EndDialogue();
    //         return;
    //     }
    //     string sentence = sentences.Dequeue();
    //     Debug.Log(sentence);
    // }
    // void EndDialogue()
    // {
    //     Debug.Log("End of conversation");
    // }
}
