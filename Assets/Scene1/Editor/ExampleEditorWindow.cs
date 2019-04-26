using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleEditorWindow : EditorWindow
{
    Color color;
    static ExampleEditorWindow window;

    [MenuItem("MyCustomWindows/ExampleWidnow")]
    static void Init()
    {
        window = (ExampleEditorWindow)EditorWindow.GetWindow(typeof(ExampleEditorWindow));
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Use this to change the colour of the selected object");

        using (var horizontalScope = new EditorGUILayout.HorizontalScope())
        {
            color = EditorGUILayout.ColorField("Colour", color);
            if(GUILayout.Button("Change colour"))
            {
                foreach(var o in Selection.objects)
                {
                    GameObject go = (GameObject)o;
                    if(go != null)
                    {
                        go.GetComponent<Renderer>().material.color = color;
                    }
                }
                if(Selection.objects.Length <1)
                {
                    Debug.Log("Must select game object");
                }

            }
        }
    }

}
