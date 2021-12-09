using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "BaseItem", menuName ="Item/BaseItem")]
public class Item : ScriptableObject
{
    [Header("Item Stats")]
    public string itemName = "Defulat Item";
    public Sprite itemIcon = null;
    // [SerializeField] private GameObject itemObject; // because it is set in PickupController and also we dont want data to reset on drop/pickup so we create local one
    [TextArea] public string description = "";


}
