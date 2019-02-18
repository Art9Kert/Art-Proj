using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<GameObject> slots = new List<GameObject>();
    public bool AddItem(Item itemToAdd, int amount)
    {
        Slot emptySlot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToAdd && itemToAdd.isStackable && currentSlot.myAmount + amount <= itemToAdd.maxStackAmount)
            {
                currentSlot.AddItem(itemToAdd, amount);
                return true;
            }
            else if (currentSlot.myItem == null && emptySlot == null)
            {
                emptySlot = currentSlot;
            }
        }
        if (emptySlot != null)
        {
            emptySlot.AddItem(itemToAdd, amount);
            return true;
        }
        else
        {
            print("Нет места");
            return false;
        }
    }

    public void RemoveItem(Item itemToRemove, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if(currentSlot.myItem == itemToRemove){
                currentSlot.RemoveItem(amount);
            }
        }
    }

    public bool HasInInventory(string lookUpItem, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i].GetComponent<Slot>().myItem != null){
                if(slots[i].GetComponent<Slot>().myItem.itemName == lookUpItem && slots[i].GetComponent<Slot>().myAmount >= amount){
                    return true;
                }
            }
        }
        return false;
    }
}
