using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dialouge))]
public class DevDialougeCreation : EditorWindow
{

    
    static DevDialougeCreation window;
    bool[] list = new bool[10];

    Dialouge d;


    


    [MenuItem("CLICK ME PLEASE/DevDialougeEditor")]
    public static void Init()
    {
        window = (DevDialougeCreation)EditorWindow.GetWindow(typeof(DevDialougeCreation));
        window.Show();

        
    }

    public void OnGUI()
    {

        NodeList(0);
        NodeList(1);
        NodeList(2);
        NodeList(3);
        NodeList(4);
        NodeList(5);
        NodeList(6);
        NodeList(7);


    }

    void NodeList(int nodeNumber)
    {
        var level = EditorGUI.indentLevel;

        EditorGUILayout.Foldout(false, "Node" + nodeNumber.ToString());

        EditorGUILayout.LabelField("Enter what the NPC will say to the player");
        EditorGUILayout.TextField("");

        EditorGUILayout.LabelField("The Node ID");
        EditorGUILayout.IntField(0);



        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Enter what the player can say");
        EditorGUILayout.TextField("");
        EditorGUILayout.LabelField("The Destination ID");
        EditorGUILayout.IntField(0);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Enter what the player can say");
        EditorGUILayout.TextField("");
        EditorGUILayout.LabelField("The Destination ID");
        EditorGUILayout.IntField(0);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Enter what the player can say");
        EditorGUILayout.TextField("");
        EditorGUILayout.LabelField("The Destination ID");
        EditorGUILayout.IntField(0);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.Space();



        EditorGUI.indentLevel = level;
    }

}
