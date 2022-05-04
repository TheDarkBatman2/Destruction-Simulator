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
    public Sprite itemPanelIcon = null;
    // [SerializeField] private GameObject itemObject; // because it is set in PickupController and also we dont want data to reset on drop/pickup so we create local one
    [TextArea] public string description = "";

    [Header("If its not set , on pickup it will set rotation to 0")]
    public GameObject originalPrefab; // if we want to reset obejct or use its rotation in some cases

    [Header("Additional offset on pickup")]
    public Vector3 inHandOffset = new Vector3(0f, 0f, 0f);
    
}
