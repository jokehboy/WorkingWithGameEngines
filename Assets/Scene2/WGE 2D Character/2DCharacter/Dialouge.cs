using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class Dialouge : MonoBehaviour
{

    public List<string> NPCText = new List<string>();
    public List<int> NodeID = new List<int>();

    public List<string> Opt1 = new List<string>();
    public List<string> Opt2 = new List<string>();
    public List<string> Opt3 = new List<string>();
    public List<int> OptDestID1 = new List<int>();
    public List<int> OptDestID2 = new List<int>();
    public List<int> OptDestID3 = new List<int>();

    DialougeNodes node0,node1,node2,node3,node4,node5,node6,node7,node8,node9,node10,node11;
    


    
    static void Main(string[] args)
    {
        DialougeCreation dia = loadDialouge("");
        runDialouge(dia);
    }

    static void runDialouge(DialougeCreation dia)
    {
        int nodeID = 0;


        while(nodeID !=-1)
        {
            //nodeID = runNode(dia.Nodes[nodeID]);
        }

    }

    

    public void createDialouge()
    {
        DialougeCreation dia = new DialougeCreation();

        for(int i = 0; i< NPCText.Count; i++)
        {
            if(i==0)
            {
                DialougeNodes node0 = new DialougeNodes(NPCText[i]);
                dia.AddNode(node0);
                dia.AddOption(Opt1[i], node0, node1);
            }
            if(i==1)
            {
                DialougeNodes node1 = new DialougeNodes(NPCText[i]);
                dia.AddNode(node1);
                dia.AddOption(Opt1[i], node1, node2);
                dia.AddOption(Opt2[i], node1, node3);

            }
            if(i==2)
            {
                DialougeNodes node2 = new DialougeNodes(NPCText[i]);
                dia.AddNode(node2);
                dia.AddOption(Opt1[i], node1, node2);
            }
            if(i==3)
            {
                DialougeNodes node3 = new DialougeNodes(NPCText[i]);
                dia.AddNode(node3);
                
            }
            if(i==4)
            {

            }
            if(i==5)
            {

            }
            if(i==6)
            {

            }
            if(i==7)
            {

            }
            if(i==8)
            {

            }
            if(i==9)
            {

            }
            if(i==10)
            {

            }
            if(i==11)
            {

            }
        }

        XmlSerializer ser = new XmlSerializer(typeof(DialougeCreation));
        StreamWriter writer = new StreamWriter("TestDia.xml");

    }

    static DialougeCreation loadDialouge(string path)
    {
        XmlSerializer ser = new XmlSerializer(typeof(DialougeCreation));
        StreamReader reader = new StreamReader(path);
        DialougeCreation dia = (DialougeCreation)ser.Deserialize(reader);
        return dia;
    }

}
