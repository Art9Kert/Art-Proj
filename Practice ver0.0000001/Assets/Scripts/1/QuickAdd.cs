using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickAdd : MonoBehaviour
{

    public ItemDatabase database;
    public Inventory inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inventory.AddItem(database.GetItemById(0), 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            inventory.AddItem(database.GetItemById(1), 1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            inventory.AddItem(database.GetItemById(3), 1);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            inventory.AddItem(database.GetItemById(4), 1);
        }
    }
}
