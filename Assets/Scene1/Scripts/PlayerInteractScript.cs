using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;


public class PlayerInteractScript : MonoBehaviour
{
    public VoxelChunk voxelChunk;

    GameObject menu;

    public InventoryManager inventory;

    bool isPaused;

    int blockHeld = 1;


    public float pullRadius;
    public float gravitationalPull;
    public float minRadius;
    public float distanceMultiplier;

    public LayerMask layersToPull;






    // Start is called before the first frame update
    void Start()
    {

        transform.GetSiblingIndex();
        menu = GameObject.Find("Canvas");
        menu.SetActive(false);
        isPaused = false;
    }



    bool PickThisBlock(out Vector3 v, float dist)
    {
        v = new Vector3();
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, dist))
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

    public void TogglePauseMenu(bool isPaused)
    {
        if (isPaused == false)
        {

            menu.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
        }
        else
        {
            menu.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;

        }
    }


    void blocks(int blockEquipped)
    {
        if (blockEquipped == 1)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(false);



        }
        if (blockEquipped == 2)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(false);
        }
        if (blockEquipped == 3)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(false);
        }
        if (blockEquipped == 4)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.F))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, pullRadius, layersToPull);

            foreach(var collider in colliders)
            {
                Vector3 direction = transform.position - collider.transform.position;

                if (direction.magnitude < minRadius) continue;

                float distance = direction.sqrMagnitude * distanceMultiplier + 1;

                Rigidbody rb = collider.GetComponent<Rigidbody>();

                rb.AddForce(direction.normalized * (gravitationalPull / distance)*rb.mass * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 v;
            if (PickThisBlock(out v, 4))
            {
                voxelChunk.DropBlock(v);
                voxelChunk.SetBlock(v, 0);

            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector3 v;



            if (blockHeld == 1)
            {
                if (inventory.itemAmounts[0] > 0)
                {
                    inventory.itemAmounts[0]--;
                    if (PickEmptyBlock(out v, 4))
                    {
                        voxelChunk.SetBlock(v, blockHeld);
                    }
                }
            }
            if (blockHeld == 2)
            {
                if (inventory.itemAmounts[1] > 0)
                {
                    inventory.itemAmounts[1]--;
                    if (PickEmptyBlock(out v, 4))
                    {
                        voxelChunk.SetBlock(v, blockHeld);
                    }
                }
            }
            if (blockHeld == 3)
            {
                if (inventory.itemAmounts[2] > 0)
                {
                    inventory.itemAmounts[2]--;
                    if (PickEmptyBlock(out v, 4))
                    {
                        voxelChunk.SetBlock(v, blockHeld);
                    }
                }
            }
            if (blockHeld == 4)
            {
                if (inventory.itemAmounts[3] > 0)
                {
                    inventory.itemAmounts[3]--;
                    if (PickEmptyBlock(out v, 4))
                    {
                        voxelChunk.SetBlock(v, blockHeld);
                    }
                }
            }


        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            blockHeld = 1;
            blocks(blockHeld);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            blockHeld = 2;
            blocks(blockHeld);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            blockHeld = 3;
            blocks(blockHeld);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            blockHeld = 4;
            blocks(blockHeld);
        }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused == false)
            {
                isPaused = true;
                TogglePauseMenu(isPaused);
            }
            else
            {
                isPaused = false;
                TogglePauseMenu(isPaused);
            }

        }

    }
}
