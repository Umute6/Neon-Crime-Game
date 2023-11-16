using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickButtonAnswer : MonoBehaviour
{
    public Button buttonAnswer1, buttonAnswer2, buttonAnswer3;
    //public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        buttonAnswer1.onClick.AddListener(TaskOnClick);
        buttonAnswer2.onClick.AddListener(delegate {TaskWithParameters("Hello");});
        buttonAnswer3.onClick.AddListener(()=> ButtonClicked(16));
        buttonAnswer3.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    void TaskWithParameters(string message)
    {
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }

    

}
