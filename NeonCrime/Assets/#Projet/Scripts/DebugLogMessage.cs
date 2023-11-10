using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class DebugLogMessage : ScriptableObject 

{ /// <summary>
/// class C# normale
/// </summary>
    public string message;
    public DebugLogMessage[] next;

    public DebugLogMessage GetNextMessage() // renvoie un type DebugLogMessage
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
