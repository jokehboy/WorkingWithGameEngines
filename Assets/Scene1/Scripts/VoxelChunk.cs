using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelChunk : MonoBehaviour
{
    VoxelGen voxelGen;
    public int[,,] terrainArray;
    int chunkSize = 16;

    public delegate void EventBlockChanged();
    public static event EventBlockChanged OnEventDestroy;
    public static event EventBlockChanged OnEventPlace;
    



    public delegate void EventBlockChangedWithType(int blockType);
    public static event EventBlockChangedWithType OnEventBlockChanged;

    public static event EventBlockChanged OnEventGrassDestroyed;
    public static event EventBlockChanged OnEventDirtDestroyed;
    public static event EventBlockChanged OnEventSandDestroyed;
    public static event EventBlockChanged OnEventStoneDestroyed;

    public static event EventBlockChanged OnEventGrassPlaced;
    public static event EventBlockChanged OnEventDirtPlaced;
    public static event EventBlockChanged OnEventSandPlaced;
    public static event EventBlockChanged OnEventStonePlaced;



    public GameObject grass;
    public GameObject dirt;
    public GameObject sand;
    public GameObject stone;

    
   


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

    public void LoadChunk(string fileName)
    {
        terrainArray = XMLVoxelFileWriter.LoadChunkFromXML(16, fileName);

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
            if(blockType ==1 )
            {
                OnEventGrassPlaced();
            }
            if(blockType==2)
            {
                OnEventDirtPlaced();
            }
            if(blockType==3)
            {
                OnEventSandPlaced();
            }
            if(blockType==4)
            {
                OnEventStonePlaced();
            }

        }

        
    }

    public void DropBlock(Vector3 index)
    {
        Vector3 pos;
        pos.x = index.x;
        pos.y = index.y;
        pos.z = index.z;

        int targetBlock = terrainArray[(int)index.x, (int)index.y, (int)index.z];

        GameObject block = null;

        switch (targetBlock)
        {
            case 1:
                block = grass;
                break;
            case 2:
                block = dirt;
                break;
            case 3:
                block = sand;
                break;
            case 4:
                block = stone;
                break;
            default:
                block = grass;
                break;
        }

        GameObject spawnBlock = Instantiate(block, pos, transform.rotation) as GameObject;

        if (targetBlock == 1)
        {
            OnEventGrassDestroyed();
        }
        if (targetBlock == 2)
        {
            OnEventDirtDestroyed();
        }
        if (targetBlock == 3)
        {
            OnEventSandDestroyed();
        }
        if (targetBlock == 4)
        {
            OnEventStoneDestroyed();
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
            
        }
    }
}
