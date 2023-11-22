using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ChangeColorNPC : MonoBehaviour
{
    [SerializeField] private Color npcCyan = Color.cyan;
    [SerializeField] private Color npcJaune = Color.yellow;

    private Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = npcCyan;
        
    }

    
}
