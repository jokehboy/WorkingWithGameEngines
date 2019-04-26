using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropping : MonoBehaviour
{
    InventoryManager inventory;

    public delegate void OnEventPickup();
    public static event OnEventPickup OnEventPick; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

     void Awake()
    {
        inventory = GameObject.Find("InventoryObject").GetComponent<InventoryManager>();
        
    }

     

     void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            OnEventPick();
            if (gameObject.name == "Grass(Clone)")
            {
                inventory.itemAmounts[0]++;
            }
            if (gameObject.name == "Dirt(Clone)")
            {
                inventory.itemAmounts[1]++;
            }
            if (gameObject.name == "Sand(Clone)")
            {
                inventory.itemAmounts[2]++;
            }
            if (gameObject.name == "Stone(Clone)")
            {
                inventory.itemAmounts[3]++;
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
