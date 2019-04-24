using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelChunk : MonoBehaviour
{
    VoxelGen voxelGen;
    int[,,] terrainArray;
    int chunkSize = 16;

    public delegate void EventBlockChanged();
    public static event EventBlockChanged OnEventDestroy;
    public static event EventBlockChanged OnEventPlace;
   


    // Start is called before the first frame update
    void Start()
    {
        voxelGen = GetComponent<VoxelGen>();
        terrainArray = new int[chunkSize, chunkSize, chunkSize];

        voxelGen.Initialise();
        InitTerrain();
        CreateTerrain();
        voxelGen.UpdateMesh();
    }

    void InitTerrain()
    {
        for(int x = 0; x<terrainArray.GetLength(0); x++)
        {
            for(int y = 0; y < terrainArray.GetLength(1); y++)
            {
                for(int z = 0; z<terrainArray.GetLength(2); z++)
                {
                    if(y == 3)
                    {
                        terrainArray[x, y, z] = 1;
                        terrainArray[0, 3, 1] = 4;
                        terrainArray[0, 3, 2] = 4;
                        terrainArray[0, 3, 3] = 4;
                        terrainArray[1, 3, 3] = 4;
                        terrainArray[1, 3, 4] = 4;
                        terrainArray[2, 3, 4] = 4;
                        terrainArray[3, 3, 4] = 4;
                        terrainArray[4, 3, 4] = 4;
                        terrainArray[5, 3, 4] = 4;
                        terrainArray[5, 3, 3] = 4;
                        terrainArray[5, 3, 2] = 4;
                        terrainArray[6, 3, 2] = 4;
                        terrainArray[7, 3, 2] = 4;
                        terrainArray[8, 3, 2] = 4;
                        terrainArray[9, 3, 2] = 4;
                        terrainArray[10, 3, 2] = 4;
                        terrainArray[11, 3, 2] = 4;
                        terrainArray[12, 3, 2] = 4;
                        terrainArray[13, 3, 2] = 4;
                        terrainArray[13, 3, 3] = 4;
                        terrainArray[14, 3, 3] = 4;
                        terrainArray[15, 3, 3] = 4;






                    }
                    else if(y<3)
                    {
                        terrainArray[x, y, z] = 2;
                    }
                }
            }
        }

    }

    void CreateTerrain()
    {
        for(int x =0; x<terrainArray.GetLength(0); x++)
        {
            for(int y = 0; y< terrainArray.GetLength(1); y++)
            {
                for(int z = 0; z< terrainArray.GetLength(2); z++)
                {
                    if(terrainArray[x,y,z] !=0)
                    {
                        string tex;

                        switch (terrainArray[x,y,z])
                        {
                            case 1:
                                tex = "Grass";
                                break;
                            case 2:
                                tex = "Dirt";
                                break;
                            case 3:
                                tex = "Sand";
                                break;
                            case 4:
                                tex = "Stone";
                                break;
                            default:
                                tex = "Grass";
                                break;
                        }

                        if (x == 0 || terrainArray[x - 1, y, z] == 0)
                        {
                            voxelGen.CreateNegXFace(x, y, z, tex);
                        }
                        // check if we need to draw the positive x face
                        if (x == terrainArray.GetLength(0) - 1 ||terrainArray[x + 1, y, z] == 0)
                        {
                            voxelGen.CreatePosXFace(x, y, z, tex);
                        }

                        // check if we need to draw the negative y face
                        if (y == 0 || terrainArray[x, y - 1, z] == 0)
                        {
                            voxelGen.CreateNegYFace(x, y, z, tex);
                        }
                        // check if we need to draw the positive y face
                        if (y == terrainArray.GetLength(0) - 1 ||terrainArray[x, y + 1, z] == 0)
                        {
                            voxelGen.CreatePosYFace(x, y, z, tex);
                        }

                        if (z == 0 || terrainArray[x, y , z-1] == 0)
                        {
                            voxelGen.CreateNegZFace(x, y, z, tex);
                        }
                        if (z == terrainArray.GetLength(0) - 1 || terrainArray[x, y , z+1] == 0)
                        {
                            voxelGen.CreatePosZFace(x, y, z, tex);
                        }


                        print("Create" + tex + " block");
                    }
                }
            }
        }
    }



    public void SetBlock(Vector3 index, int blockType)
    {
        if(index.x>0   &&   index.x < terrainArray.GetLength(0)   &&   index.y>0   &&index.y<terrainArray.GetLength(1)   &&   index.z>0   &&   index.z<terrainArray.GetLength(2))
        {
            terrainArray[(int)index.x, (int)index.y, (int)index.z] = blockType;
            CreateTerrain();
            voxelGen.UpdateMesh();
            if(blockType == 0)
            {
                OnEventDestroy();
            }
            else
            {
                OnEventPlace();
            }

        }

        
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            XMLVoxelFileWriter.SaveChunkToXML(terrainArray, "VoxelChunk");
        }

        if(Input.GetKeyDown(KeyCode.F2))
        {
            terrainArray = XMLVoxelFileWriter.LoadChunkFromXML(16, "VoxelChunk");

            CreateTerrain();
            voxelGen.UpdateMesh();
        }
    }
}
