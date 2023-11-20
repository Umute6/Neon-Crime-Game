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

    public void SetSelectedAnswerIndex(int index)
    {
        selectedAnswerIndex = index;
    }


    public DialogueMessage GetNextMessage() // renvoie un type DebugLogMessage
    {
        if (next != null && next.Length == 1)
        {
            return next[0]; // choisit le 1er
        }
        else
        {
            return null;
        }

    }
}



[CreateAssetMenu]
public class DiceRollDialogueMessage : DialogueMessage
{
    public int difficulty;

    public new DialogueMessage GetNextMessage() //new remplace le précédent GNM pour le jet Dice
    {
        int rollDice = Random.Range(1, 11);
        if (rollDice <= 5)
        {
            message = "Réussi";
        }
        else
        {
            message = "Raté";
        }
        //à retourner une instance de DialogueMessage
        return base.GetNextMessage();

    }


}
