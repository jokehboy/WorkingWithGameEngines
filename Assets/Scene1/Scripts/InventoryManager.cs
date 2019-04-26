using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Transform parentPanel;

    public List<Sprite> itemSprites;
    public List<string> itemNames;
    public List<int> itemAmounts;

    public GameObject startItem;

    


    List<InventoryItemScript> inventoryList;



    // Start is called before the first frame update
    void Start()
    {

        

        inventoryList = new List<InventoryItemScript>();

        for(int i = 0; i<itemNames.Count; i++)
        {
            GameObject inventoryItem = (GameObject)Instantiate(startItem);

            inventoryItem.transform.SetParent(parentPanel);

            inventoryItem.SetActive(true);

            InventoryItemScript iis = inventoryItem.GetComponent<InventoryItemScript>();
            iis.itemSprite.sprite = itemSprites[i];
            iis.itemNameText.text = itemNames[i];
            iis.itemName = itemNames[i];
            iis.itemAmountText.text = itemAmounts[i].ToString();
            iis.itemAmount = itemAmounts[i];

            inventoryList.Add(iis);

            DisplayListInOrder();
        }
    }


    



    void DisplayListInOrder()
    {
        float yOffset = 55f;

        Vector3 startPos = startItem.transform.position;

        foreach(InventoryItemScript iis in inventoryList)
        {
            iis.transform.position = startPos;
            startPos.y -= yOffset;
        }
    }

    public void SelectionSortInventory()
    {
        for (int i = 0; i < inventoryList.Count - 1; i++)
        {
            int minIndex = i;

            for (int j = i; j < inventoryList.Count; j++)
            {
                if (inventoryList[j].itemAmount < inventoryList[minIndex].itemAmount)
                {
                    minIndex = j;
                }

            }
            if (minIndex != i)
            {
                InventoryItemScript iis = inventoryList[i];
                inventoryList[i] = inventoryList[minIndex];
                inventoryList[minIndex] = iis;
            }
        }

        DisplayListInOrder();
    }

    List<InventoryItemScript> QuickSort(List<InventoryItemScript>listIn)
    {
        if(listIn.Count <= 1)
        {
            return listIn;
        }
        int pivotIndex = 0;

        List<InventoryItemScript> leftList = new List<InventoryItemScript>();

        List<InventoryItemScript> rightList = new List<InventoryItemScript>();

        for(int i =1; i<listIn.Count; i++)
        {
            if(listIn[i].itemAmount >listIn[pivotIndex].itemAmount)
            {
                leftList.Add(listIn[i]);
            }
            else
            {
                rightList.Add(listIn[i]);
            }
        }

        leftList = QuickSort(leftList);
        rightList = QuickSort(rightList);

        leftList.Add(listIn[pivotIndex]);
        leftList.AddRange(rightList);
        return leftList;
    }

    public void StartQuickSort()
    {
        inventoryList = QuickSort(inventoryList);
        DisplayListInOrder();
    }

    public void SortByNameAZ()
    {
        for (int i = 0; i < inventoryList.Count - 1; i++)
        {
            int minIndex = i;

            for (int j = i; j < inventoryList.Count; j++)
            {
                if (string.Compare(inventoryList[j].itemName,inventoryList[minIndex].itemName)<0)
                {
                    minIndex = j;
                }

            }
            if (minIndex != i)
            {
                InventoryItemScript iis = inventoryList[i];
                inventoryList[i] = inventoryList[minIndex];
                inventoryList[minIndex] = iis;
            }
        }
        DisplayListInOrder();
    }

    public void SortByNameZA()
    {
        for (int i = 0; i < inventoryList.Count - 1; i++)
        {
            int minIndex = i;

            for (int j = i; j < inventoryList.Count; j++)
            {
                if (string.Compare(inventoryList[j].itemName, inventoryList[minIndex].itemName) > 0)
                {
                    minIndex = j;
                }

            }
            if (minIndex != i)
            {
                InventoryItemScript iis = inventoryList[i];
                inventoryList[i] = inventoryList[minIndex];
                inventoryList[minIndex] = iis;
            }
        }
        DisplayListInOrder();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemNameText.text == "Grass")
            {
                inventoryList[i].itemAmountText.text = itemAmounts[0].ToString();
            }
            if (inventoryList[i].itemNameText.text == "Dirt")
            {
                inventoryList[i].itemAmountText.text = itemAmounts[1].ToString();
            }
            if (inventoryList[i].itemNameText.text == "Sand")
            {
                inventoryList[i].itemAmountText.text = itemAmounts[2].ToString();
            }
            if (inventoryList[i].itemNameText.text == "Stone")
            {
                inventoryList[i].itemAmountText.text = itemAmounts[3].ToString();
            }
        }
    }
}
