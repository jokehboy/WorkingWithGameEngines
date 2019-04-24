using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class PlayerInteractScript : MonoBehaviour
{
    public VoxelChunk voxelChunk;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    bool PickThisBlock(out Vector3 v, float dist)
    {
        v = new Vector3();
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,dist))
        {
            v = hit.point - hit.normal / 2;
            v.x = Mathf.Floor(v.x);
            v.y = Mathf.Floor(v.y);
            v.z = Mathf.Floor(v.z);
            return true;
        }
        return false;
    }

    bool PickEmptyBlock(out Vector3 v, float dist)
    {
        v = new Vector3();
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, dist))
        {
            v = hit.point + hit.normal / 2;
            v.x = Mathf.Floor(v.x);
            v.y = Mathf.Floor(v.y);
            v.z = Mathf.Floor(v.z);
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 v;
            if (PickThisBlock(out v, 4))
            {
                voxelChunk.SetBlock(v, 0);
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Vector3 v;
            if(PickEmptyBlock(out v, 4))
            {

                Debug.Log(v);
                voxelChunk.SetBlock(v, 1);

            }
        }
    }
}
