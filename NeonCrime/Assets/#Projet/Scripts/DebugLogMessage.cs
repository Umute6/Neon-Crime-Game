using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class DialogueMessage : ScriptableObject 

{ /// <summary>
/// class C# normale
/// </summary>
/// 
    public string nameNPC;
    [TextArea(3, 10)]
    public string message;

    public string[] answers;
    public DialogueMessage[] next;
    

    public DialogueMessage GetNextMessage() // renvoie un type DebugLogMessage
    {
        if (next != null && next.Length > 0)
        {
            return next[0]; // choisit le 1er
        }
        else
        {
            return null;
        }

    }
}
