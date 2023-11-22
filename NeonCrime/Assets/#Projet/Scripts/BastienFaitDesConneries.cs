using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Profile {
    public int charisma;
    public int strength;
    public int deduction;
}


public class BastienFaitDesConneries : MonoBehaviour
{

    public Profile flirty = new Profile();
    public Profile detective = new Profile();

    public enum CharacterType
    {
        Flirty,
        Detective
    }

    public CharacterType type;

    public Profile selectedClass;

    public void SelectClass(CharacterType selectedType) {
        if (selectedType == CharacterType.Flirty) {
            selectedClass = flirty;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        flirty.charisma = 8;
        flirty.strength = 2;
        flirty.deduction = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
