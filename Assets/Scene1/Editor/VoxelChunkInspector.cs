using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VoxelChunk))]
public class VoxelChunkInspector : Editor
{
    string fileName = "";




    public override void OnInspectorGUI()
    {
        VoxelChunk myTarget = (VoxelChunk)target;

        fileName = EditorGUILayout.TextField(fileName);

        if (GUILayout.Button("Load from XML"))
        {
            myTarget.LoadChunk(fileName);
        }
        if (GUILayout.Button("Save to XML"))
        {
            XMLVoxelFileWriter.SaveChunkToXML(myTarget.terrainArray, "VoxelChunk");
        }
        if (GUILayout.Button("Clear Terrain"))
        {
            myTarget.GetComponent<VoxelGen>().ClearPrevData();
        }

        

    }

}
   
    
