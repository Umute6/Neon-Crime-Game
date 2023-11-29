using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Profile
{
    public int charisma;
    public int observation;
    public int deduction;
    public int empathy;
    public int eloquence;

}


public class ProfilePlayer : MonoBehaviour
{

    public Profile flirty = new Profile(); // les 3 profiles contiennent les 5 caracts
    public Profile detective = new Profile();
    public Profile clumpsy = new Profile();

    public enum CharacterType
    {
        Flirty,
        Detective,
        Clumpsy
    }

    public CharacterType type;

    public Profile selectedClass;

    //method pour sélectionner la classe 
    public void SelectClass(CharacterType selectedType)
    {
        if (selectedType == CharacterType.Flirty)
        {
            selectedClass = flirty;
        }
        else if (selectedType == CharacterType.Detective)
        {
            selectedClass = detective;
        }
        else if (selectedType == CharacterType.Clumpsy)
        {
            selectedClass = clumpsy;
        }
    }

    public int RollDice()
    {
        int dieRoll = Random.Range(1, 11);
        flirty.charisma = 8;
        flirty.observation = 5;
        flirty.deduction = 2;
        flirty.empathy = 6;
        flirty.eloquence = 4;

        detective.charisma = 5;
        detective.observation = 8;
        detective.deduction = 7;
        detective.empathy = 4;
        detective.eloquence = 2;

        clumpsy.charisma = 2;
        clumpsy.observation = 4;
        clumpsy.deduction = 2;
        clumpsy.empathy = 6;
        clumpsy.eloquence = 8;
        return dieRoll;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
