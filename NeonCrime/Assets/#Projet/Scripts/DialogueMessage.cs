using UnityEngine;


[CreateAssetMenu]
public class DialogueMessage : ScriptableObject
{ /// class C# normale
    public Sprite spriteBckGrd;
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
    public virtual DialogueMessage GetNextMessage(int answer = 0) //new remplace le précédent GNM pour le jet Dice
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
