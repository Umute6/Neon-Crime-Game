using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public struct DataColor
{
    public string name;
    public Color color;
}
[RequireComponent(typeof(Image))]
public class ChangeColorNPC : MonoBehaviour
{
    public List<DataColor> colors;
    public Color defaultColor = Color.white;

    private Image _imageNPC;
    private Image imageNPC{
        get{
            if (_imageNPC == null){
                _imageNPC = GetComponent<Image>();
            }
            return _imageNPC;
        }
    }
    void Start()
    {
        //obtenir le composant rendererNPC attaché à cet objet
        

    }

    public void ChangeColor(string name)
    {
        foreach(DataColor dataColor in colors){
            if(dataColor.name.ToLower() == name.ToLower()){
                print(imageNPC);
                imageNPC.color = dataColor.color;
                return;
            }
        }
        imageNPC.color = defaultColor;
    }
}


