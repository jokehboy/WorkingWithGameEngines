using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer),typeof(MeshCollider))]
public class MeshGenerator : MonoBehaviour {

    Mesh mesh;
    MeshCollider meshCollider;

    List<Vector3> vertlist;
    List<int> triIndexList;
    List<Vector2> UVList;
    int numOfQuads = 0;


	// Use this for initialization
	void Start ()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();

        vertlist = new List<Vector3>();
        triIndexList = new List<int>();
        UVList = new List<Vector2>();

        CreateQuad(1,1, new Vector2(0,0.5f));
        CreateQuad(2, 1, new Vector2(0.5f,0.5f));

        mesh.vertices = vertlist.ToArray();
        mesh.triangles = triIndexList.ToArray();
        mesh.uv = UVList.ToArray();
        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = mesh;
		
	}
	
    void CreateQuad(int x , int y, Vector2 uvCoords)
    {
        //
        vertlist.Add(new Vector3(x, y+1, 0));
        vertlist.Add(new Vector3(x+1, y+1, 0));
        vertlist.Add(new Vector3(x+1, y, 0));
        vertlist.Add(new Vector3(x, y, 0));

        //
        triIndexList.Add(numOfQuads * 4);
        triIndexList.Add((numOfQuads * 4) + 1);
        triIndexList.Add((numOfQuads * 4) + 3);

        triIndexList.Add((numOfQuads * 4) + 1);
        triIndexList.Add((numOfQuads * 4) + 2);
        triIndexList.Add((numOfQuads * 4) + 3);
        numOfQuads++;

        UVList.Add(new Vector2(uvCoords.x, uvCoords.y + 0.5f));
        UVList.Add(new Vector2(uvCoords.x + 0.5f, uvCoords.y + 0.5f));
        UVList.Add(new Vector2(uvCoords.x + 0.5f, uvCoords.y));
        UVList.Add(new Vector2(uvCoords.x, uvCoords.y));
    }


    // Update is called once per frame
    void Update ()
    {
		
	}
}
