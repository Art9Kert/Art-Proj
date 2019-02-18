using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{

    public string itemName;
    public Sprite itemIcon;

    public bool isStackable;
    public int maxStackAmount;

    public bool isCraftable;
    public List<Item> CraftItems = new List<Item>();
    public List<int> CraftAmount = new List<int>();
    public int makesHowMany;
    //public int MinLevelToCraft;


}
