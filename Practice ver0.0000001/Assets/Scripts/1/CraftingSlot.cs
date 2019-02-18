using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IPointerClickHandler {

	Crafting craftingScript;
	public Item myItem;
	Image Icon;
	void Start(){
		if (myItem == null){
			Destroy (gameObject);
		}
		craftingScript = GameObject.FindObjectOfType<Crafting>();
		Icon = GetComponent<Image>();
		Icon.sprite = myItem.itemIcon;
	}
	public void OnPointerClick(PointerEventData eventData){
		craftingScript.CraftItem(myItem);
	}
}
