﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{

    public ItemDatabase database;
    public Inventory inventory;
    public GameObject craftingPanel;
    public GameObject craftingSlot;
    public GameObject tooltipPanel;
    public Text tooltipText;
    public Text lackText;
    private string lack = null;
    //public int playerLevel;

    void Start()
    {
        GenSlots();
    }

    void GenSlots()
    {
        for (int i = 0; i < database.databaseItems.Count; i++)
        {
            Item currentItem = database.databaseItems[i];
            if (currentItem.isCraftable /*&& playerLevel >= currentItem.MinLevelToCraft*/)
            {
                GameObject go = Instantiate(craftingSlot, craftingPanel.transform.position, Quaternion.identity);
                go.transform.SetParent(craftingPanel.transform);
                go.GetComponent<CraftingSlot>().myItem = currentItem;
            }
        }
    }

    public void CraftItem(Item itemToCraft)
    {
        if (itemToCraft.isCraftable)
        {
            if (CanCraft(itemToCraft))
            {
                Add(itemToCraft);
            }
            else
            {
                //print("Не хватает материалов");
                tooltipPanel.SetActive(true);
                lackText.text = lack;
                lack = null;
            }
        }
        else
        {
            return;
        }
    }

    bool CanCraft(Item itemToLookUp)
    {
        for (int i = 0; i < itemToLookUp.CraftItems.Count; i++)
        {
            Item currentItem = itemToLookUp.CraftItems[i];
            int currentAmount = itemToLookUp.CraftAmount[i];
            if (!inventory.HasInInventory(currentItem.itemName, currentAmount))
            {
                lack += currentAmount + " " + currentItem.itemName + "\n";
            }
        }
        if (lack == null)
        {
            return true;
        }
        return false;
    }

    void Add(Item itemToAdd)
    {
		if (inventory.AddItem(itemToAdd, itemToAdd.makesHowMany) == true){
			Remove(itemToAdd);
		}
    }

    void Remove(Item itemToRemove)
    {
        for (int i = 0; i < itemToRemove.CraftItems.Count; i++)
        {
            Item currentItem = itemToRemove.CraftItems[i];
            int currentAmount = itemToRemove.CraftAmount[i];
            inventory.RemoveItem(currentItem, currentAmount);
        }
    }

    public void ShowTooltip(Item tooltipItem)
    {
		tooltipText.text = tooltipItem.itemName;
        if (tooltipItem.isCraftable)
        {
            //tooltipText.text = tooltipItem.itemName;
            for (int i = 0; i < tooltipItem.CraftAmount.Count; i++)
            {
                tooltipText.text += "\n" + tooltipItem.CraftAmount[i] + " " + tooltipItem.CraftItems[i].itemName;
            }
        }

    }
    public void HideTooltip(Item tooltipItem)
    {
        tooltipText.text = "";
    }
    public void HideLackPanel()
    {
        tooltipPanel.SetActive(false);
    }
}
