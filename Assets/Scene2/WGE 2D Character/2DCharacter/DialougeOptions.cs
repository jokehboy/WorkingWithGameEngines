using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


public class DialougeOptions: MonoBehaviour
{
    public string theText;
    public int DestNodeID;

    public DialougeOptions() { }

    public DialougeOptions(string Text, int destination)
    {
        this.theText = Text;
        this.DestNodeID = destination;
    }




}


