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
    }

}
