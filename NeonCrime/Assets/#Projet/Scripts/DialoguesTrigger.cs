using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesTrigger : MonoBehaviour
{
   public Dialogues dialogues;

   private void OnTiggerEnter2D(Collider2D other)
   {
    if (other.CompareTag("NPC"))
    {

      FindObjectOfType<DialogueManager>().StartDialogue(dialogues);

    }
   }
}


// https://www.youtube.com/watch?v=PswC-HlKZqA