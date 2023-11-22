using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


[CreateAssetMenu]
public class DialogueMessage : ScriptableObject

{ /// <summary>
/// class C# normale
/// </summary>
/// 
    public string nameNPC;
    public Sprite spriteNPC;
    [TextArea(3, 10)]
    public string message;

    public string[] answers;
    public int selectedAnswerIndex = -1;
    public DialogueMessage[] next; //peut-être changer le nom

    // public DialogueMessage(string name, Sprite profile, string msg, string[] ans, DialogueMessage[] nxt)
    // {
    //     nameNPC = name;
    //     profileNPC = profile;
    //     message = msg;
    //     answers = ans;
    //     next = nxt;
    // }

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
    public ProfilePlayer selectedClass;

    public DialogueMessage[] nextFailed; // parce 50% de rater
    public int difficulty; //prévu pour la voie choisie
    

    private DialogueMessage SelectAnswer(int answer){ //Sélectionne la réponse en fonction du lancer de dé
        //Debug.Log("GetNextMessage called!");
        int rollDice = Random.Range(1, 11);
        Debug.Log(rollDice); //////////// montre le random - à voir pour l'afficher au screen in game
        int threshold = 5 - difficulty;

            //Sélectionne le message de réponse en fonction du résultat du lancé de dé
        DialogueMessage answerMessage = nextFailed[answer]; //par défaut en cas d'échec
        if (rollDice <= threshold){
            answerMessage = next[answer];
        }

        return answerMessage;
    }


        //Override de la method GetNextMessage sans argument (pour compatibilité)
    public override DialogueMessage GetNextMessage(){
        //applle la version avec argument en passant 0 comme réponse par défaut
        return GetNextMessage(0);
    }

        //Override de la method GeNextMessage avec argument (réponse choisie par le player)
    public override DialogueMessage GetNextMessage(int answer = 0) //new remplace le précédent GNM pour le jet Dice
    {

        if (next != null && next.Length > 0)
        {
            //utilise la function SelectAnswer pour obtenir le message de réponse
            return SelectAnswer(answer);
            //message = "Réussi";
        }
        else
        {
            return null; // Retourne null si le tableau des msgs suivants est vide
        }
        //à retourner une instance de DialogueMessage

    }


}
