using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer),typeof(MeshCollider))]
public class VoxelGen : MonoBehaviour {

    Mesh mesh;
    MeshCollider meshCollider;

    List<Vector3> vertextList;
    List<int> triIndexList;
    List<Vector2> UVList;
    int numOfQuads = 0;

    public List<string> textureNames;
    public List<Vector2> textureCoords;
    public float textureSize;

    Dictionary<string, Vector2> texturenameCoordDict;


	// Use this for initialization
	void Start ()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
        vertextList = new List<Vector3>();
        triIndexList = new List<int>();
        UVList = new List<Vector2>();

        CreateTextureNameCoordDict();

        CreateVoxel(0, 0, 0, "Dirt");

        mesh.vertices = vertextList.ToArray();
        mesh.triangles = triIndexList.ToArray();
        mesh.uv = UVList.ToArray();
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = mesh;
    }

    void CreateTextureNameCoordDict()
    {
        texturenameCoordDict = new Dictionary<string, Vector2>();

        if(textureNames.Count == textureCoords.Count)
        {
            for(int i = 0; i<textureNames.Count; i++)
            {
                texturenameCoordDict.Add(textureNames[i], textureCoords[i]);
            }
        }
        else
        {
            Debug.Log("Texture names and Texture Coords mismatch");
        }
    }

    void CreateNegZFace(int x, int y, int z, Vector2 uvCoords)
    {
        vertextList.Add(new Vector3(x, y + 1, z));
        vertextList.Add(new Vector3(x + 1, y + 1, z));
        vertextList.Add(new Vector3(x + 1, y, z));
        vertextList.Add(new Vector3(x, y, z));
        AddTriIndices();
        AddUVCoords(uvCoords);

    }

    void CreatePosZFace(int x, int y, int z, Vector2 uvCoords)
    {
        vertextList.Add(new Vector3(x + 1, y, z + 1));
        vertextList.Add(new Vector3(x + 1, y + 1, z + 1));
        vertextList.Add(new Vector3(x, y + 1, z + 1));
        vertextList.Add(new Vector3(x, y, z + 1));
        AddTriIndices();
        AddUVCoords(uvCoords);
    }

    void CreateNegXFace(int x, int y, int z, Vector2 uvCoords)
    {
        vertextList.Add(new Vector3(x, y, z + 1));
        vertextList.Add(new Vector3(x, y + 1, z + 1));
        vertextList.Add(new Vector3(x, y + 1, z));
        vertextList.Add(new Vector3(x, y, z));
        AddTriIndices();
        AddUVCoords(uvCoords);
    }

    void CreatePosXFace(int x, int y, int z, Vector2 uvCoords)
    {
        vertextList.Add(new Vector3(x + 1, y, z));
        vertextList.Add(new Vector3(x + 1, y + 1, z));
        vertextList.Add(new Vector3(x + 1, y + 1, z + 1));
        vertextList.Add(new Vector3(x + 1, y, z + 1));
        AddTriIndices();
        AddUVCoords(uvCoords);
    }

    void CreateNegYFace(int x, int y, int z, Vector2 uvCoords)
    {
        vertextList.Add(new Vector3(x, y, z + 1));
        vertextList.Add(new Vector3(x + 1, y, z + 1));
        vertextList.Add(new Vector3(x + 1, y, z));
        vertextList.Add(new Vector3(x, y, z));
        AddTriIndices();
        AddUVCoords(uvCoords);
    }

    void CreatePosYFace(int x, int y, int z, Vector2 uvCoords)
    {
        vertextList.Add(new Vector3(x, y+1, z+1));
        vertextList.Add(new Vector3(x+1, y+1, z+1));
        vertextList.Add(new Vector3(x+1, y+1, z));
        vertextList.Add(new Vector3(x, y+1, z));
        AddTriIndices();
        AddUVCoords(uvCoords);
    }



    void AddTriIndices()
    {
        triIndexList.Add(numOfQuads * 4);
        triIndexList.Add((numOfQuads * 4) + 1);
        triIndexList.Add((numOfQuads * 4) + 3);

        triIndexList.Add((numOfQuads * 4) + 1);
        triIndexList.Add((numOfQuads * 4) + 2);
        triIndexList.Add((numOfQuads * 4) + 3);
        numOfQuads++;
    }
	
    void AddUVCoords(Vector2 uvCoords)
    {
        UVList.Add(new Vector2(uvCoords.x, uvCoords.y + .5f));
        UVList.Add(new Vector2(uvCoords.x + .5f, uvCoords.y + .5f));
        UVList.Add(new Vector2(uvCoords.x + .5f, uvCoords.y));
        UVList.Add(new Vector2(uvCoords.x, uvCoords.y));

    }

    void CreateVoxel(int x, int y, int z, Vector2 uvCoords)
    {
        CreateNegXFace(x, y, z, uvCoords);
        CreatePosXFace(x, y, z, uvCoords);

        CreateNegYFace(x, y, z, uvCoords);
        CreatePosYFace(x, y, z, uvCoords);

        CreateNegZFace(x, y, z, uvCoords);
        CreatePosZFace(x, y, z, uvCoords);
        
    }

    void CreateVoxel(int x, int y, int z, string texture)
    {
        Vector2 uvCoords = texturenameCoordDict[texture];

        CreateNegXFace(x, y, z, uvCoords);
        CreatePosXFace(x, y, z, uvCoords);

        CreateNegYFace(x, y, z, uvCoords);
        CreatePosYFace(x, y, z, uvCoords);

        CreateNegZFace(x, y, z, uvCoords);
        CreatePosZFace(x, y, z, uvCoords);

    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
