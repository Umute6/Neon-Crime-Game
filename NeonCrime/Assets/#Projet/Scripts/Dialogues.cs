using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogues
{
    public string name;
    [TextArea(3, 10)] // 3 is the minimal of lines and 10 the max
    public string[] sentences;
}
