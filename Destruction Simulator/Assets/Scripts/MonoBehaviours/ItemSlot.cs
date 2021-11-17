using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Sprite icon;
    private ExplosiveItem item;

    //Encapsulation
    public ExplosiveItem GetItem(){
        return item;
    }

    public void SetItem(ExplosiveItem newItem)
    {
        // print(newItem.itemIcon);
        item = newItem;
        icon = newItem.itemIcon;
        // will change image of child , so it will display item
        // Auto update
        transform.GetChild(0).GetComponent<Image>().sprite = icon;
    }

}