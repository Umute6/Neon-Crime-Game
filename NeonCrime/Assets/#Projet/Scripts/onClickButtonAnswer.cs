using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickButtonAnswer : MonoBehaviour
{
    public Button buttonAnswer1, buttonAnswer2, buttonAnswer3;
    public DialogueManager dialogueManager;

    //Start is called before the first frame update
    void Start()
    {
        buttonAnswer1.onClick.AddListener(()=>TaskOnClick(0));
        buttonAnswer2.onClick.AddListener(()=> TaskOnClick(1));
        buttonAnswer3.onClick.AddListener(()=> TaskOnClick(2));
    }

    void TaskOnClick(int answerIndex)
    {
        dialogueManager.PlayerSelectedAnswer(answerIndex);
    } 

}
