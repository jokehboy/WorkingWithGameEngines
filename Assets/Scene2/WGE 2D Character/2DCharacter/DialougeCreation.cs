using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


[System.Serializable]
    public class DialougeCreation : MonoBehaviour
    {
        public List<DialougeNodes> Nodes;

        public void AddNode(DialougeNodes node)
        {
            Nodes.Add(node);

            node.ID = Nodes.IndexOf(node);
        }

        public void AddOption(string Text, DialougeNodes node, DialougeNodes dest)
        {
            //Add destination if it isnt there
            if(!Nodes.Contains(dest))
            {
                AddNode(dest);
            }
            //Add parent node to destination if it isnt there
            if(!Nodes.Contains(node))
            {
                AddNode(node);
            }

            DialougeOptions opt;

            if(dest==null)
            {
                opt = new DialougeOptions(Text, -1);
            }
            else
            {
                opt = new DialougeOptions(Text, dest.ID);
            }

            node.options.Add(opt);

        }


        public void Dialouge()
        {
            Nodes = new List<DialougeNodes>();
        }




    }


