using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    //method will start convers
    public void StartDialogue()
    {
        FindAnyObjectByType<DialogueManager>().OpenDialogue(messages, actors);
        // SINGLETON (??!)
    }
}

[System.Serializable]
public class Message //template like un moule à cake
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
