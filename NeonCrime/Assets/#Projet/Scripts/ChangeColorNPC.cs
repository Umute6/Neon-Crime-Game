using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChangeColorNPC : MonoBehaviour
{
    [SerializeField] private Color npcCyan = Color.cyan;
    [SerializeField] private Color npcJaune = Color.yellow;

    private Image imageNPC;
    void Start()
    {
        //obtenir le composant rendererNPC attaché à cet objet
        imageNPC = GetComponent<Image>();
        imageNPC.color = Color.white;
        
    }

    public void ChangeColorToCyan()
    {
        if (imageNPC != null)
        {
            imageNPC.color = npcCyan;
        }
    }
     public void ChangeColorToJaune()
    {
        if (imageNPC != null)
        {
            imageNPC.color = npcJaune;
        }
    }
    
}
