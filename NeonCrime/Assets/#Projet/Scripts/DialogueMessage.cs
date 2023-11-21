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

    

    public virtual DialogueMessage GetNextMessage() // renvoie un type DebugLogMessage
    {
        return GetNextMessage(0);

    }

    public virtual  DialogueMessage GetNextMessage(int answer = 0) //new remplace le précédent GNM pour le jet Dice
    {
        if (next != null && next.Length == 1)
        {
            return next[answer]; // choisit le 1er
        }
        else
        {
            return null;
        }
        
        //à retourner une instance de DialogueMessage

    }
}



[CreateAssetMenu]
public class DiceRollDialogueMessage : DialogueMessage
{

    public DialogueMessage[] nextFailed;
    public int difficulty;
    

    private DialogueMessage SelectAnswer(int answer){
        Debug.Log("GetNextMessage called!");
        int rollDice = Random.Range(1, 11);
        Debug.Log(rollDice);
        int threshold = 6 - difficulty;

        DialogueMessage answerMessage = nextFailed[answer];
        if (rollDice <= threshold){
            answerMessage = next[answer];
        }

        return answerMessage;
    }

    public override DialogueMessage GetNextMessage(){
        return GetNextMessage(0);
    }

    public override DialogueMessage GetNextMessage(int answer = 0) //new remplace le précédent GNM pour le jet Dice
    {

        if (next != null && next.Length > 0)
        {
            return SelectAnswer(answer);
            //message = "Réussi";
        }
        else
        {
            return null;
        }
        //à retourner une instance de DialogueMessage

    }


}
