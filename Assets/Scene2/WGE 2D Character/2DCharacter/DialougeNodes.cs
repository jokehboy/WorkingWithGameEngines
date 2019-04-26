using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


    public class DialougeNodes:MonoBehaviour
    {
        public int ID = -1;
        public string text;

        public List<DialougeOptions> options;

        public DialougeNodes()
        {
            options = new List<DialougeOptions>();
        }

        public DialougeNodes(string Text)
        {
            text = Text;
            options = new List<DialougeOptions>();
        }
    }


