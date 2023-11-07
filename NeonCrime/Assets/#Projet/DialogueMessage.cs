using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueMessage : ScriptableObject 
{
    public string npcName;

    [TextArea(3, 10)]
    public string[] currentMessage;

    public void DisplayMessages()
    {
        Debug.Log(npcName );
        for (int i = 0; i < currentMessage.Length; i++)
        {
            Debug.Log((i + 1) + currentMessage [i]);
        }
    }

}
