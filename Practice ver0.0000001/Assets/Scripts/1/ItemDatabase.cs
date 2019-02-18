using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> databaseItems = new List<Item>();

    public Item GetItemById(int id)
    {
        Item itemToReturn = databaseItems[id];
        return itemToReturn;
    }

}
