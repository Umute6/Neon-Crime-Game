using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DiceRollDialogueMessage : DialogueMessage
{
    public ProfilePlayer selectedClass;
    public ProfilePlayer profile;

    public DialogueMessage[] nextFailed; // parce 50% de rater
    public int difficulty; //prévu pour la voie choisie


    private DialogueMessage SelectAnswer(int answer)
    { //Sélectionne la réponse en fonction du lancer de dé
        //Debug.Log("GetNextMessage called!");
        int rollDice = Random.Range(1, 11);
        Debug.Log("Base Roll: " + rollDice); //////////// montre le random - à voir pour l'afficher au screen in game
        int threshold = 10 - difficulty;
        Debug.Log("Le seuil est de" + threshold);

        //Sélectionne le message de réponse en fonction du résultat du lancé de dé
        DialogueMessage answerMessage = nextFailed[answer]; //par défaut en cas d'échec
        if (rollDice <= threshold)
        {

            answerMessage = next[answer];
        }

        return answerMessage;
    }


    //Override de la method GetNextMessage sans argument (pour compatibilité)
    public override DialogueMessage GetNextMessage()
    {
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