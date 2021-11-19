using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Sprite icon;
    private ExplosiveItem item;
    public int itemAmount = 0;

    // we need to check if slot is empty or not AND to update inventory so we make it functional
    public int IncreaseItemAmount(int amount){
        // if != blank item ...

        itemAmount += amount;
        transform.GetChild(1).GetComponent<Text>().text = itemAmount.ToString();

        return amount; // just incase if we needed it
    }
    public int DecreaseItemAmount(int amount){
        if (itemAmount >= 1)
        {
            itemAmount -= amount;
            transform.GetChild(1).GetComponent<Text>().text = itemAmount.ToString();
        }
        else
        {
            EmptySlot();
        }
        return amount; // just incase if we needed it
    }

    //Encapsulation
    public ExplosiveItem GetItem(){
        return item;
    }

    

    public void SetItem(ExplosiveItem newItem ,int amount = 0)
    {
        // print(newItem.itemIcon);
        item = newItem;
        icon = newItem.itemIcon;
        itemAmount = amount;
        // will change image of child , so it will display item
        // Auto update
        transform.GetChild(0).GetComponent<Image>().sprite = icon;
    }


    public void EmptySlot(){
        // set slot to blank and 0 item amount

    }

}