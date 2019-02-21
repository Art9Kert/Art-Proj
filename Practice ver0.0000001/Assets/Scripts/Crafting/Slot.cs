using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Image Icon;
    Text Text;

    public Item myItem;
    public int myAmount;
    Crafting craftingScript;

    void Start()
    {
        craftingScript = GameObject.FindObjectOfType<Crafting>();
        Icon = GetComponent<Image>();
        Text = transform.GetChild(0).GetComponent<Text>();
        ShowUI();
    }

    public void AddItem(Item itemToAdd, int amnt)
    {
        if (itemToAdd == myItem)
        {
            myAmount += amnt;
        }
        else
        {
            myItem = itemToAdd;
            myAmount = amnt;
        }
        ShowUI();
    }

    public void RemoveItem(int amnt)
    {
        if (myItem != null)
        {
            myAmount -= amnt;
            if (myAmount <= 0)
            {
                myItem = null;
            }
        }
        ShowUI();
    }

    void ShowUI()
    {
        if (myItem != null)
        {
            Icon.enabled = true;
            Text.enabled = true;
            Icon.sprite = myItem.itemIcon;
            Text.text = myAmount.ToString();
        }
        else
        {
            Icon.enabled = false;
            Text.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        craftingScript.ShowTooltip(myItem);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        craftingScript.HideTooltip(myItem);
    }
}
