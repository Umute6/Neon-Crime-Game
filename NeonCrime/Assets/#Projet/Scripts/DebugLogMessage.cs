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
    private int selectedAnswerIndex = -1;
    public DialogueMessage[] next;

    public void SetSelectedAnswerIndex (int index)
    {
        selectedAnswerIndex = index;
    }
    

    public DialogueMessage GetNextMessage( ) // renvoie un type DebugLogMessage
    {
        if (next != null && selectedAnswerIndex >= 0 && selectedAnswerIndex < next.Length)
        {
            return next[selectedAnswerIndex]; // choisit le 1er
        }
        else
        {
            return null;
        }

    }
}
