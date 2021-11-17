using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarContoller : MonoBehaviour
{
    InventoryController inventoryController;
    public int hotbarSlotSize => transform.childCount;
    public int activeSlot = 0;
    public List<ItemSlot> hotbarSlots = new List<ItemSlot>(); // original hotbar class
    KeyCode[] hotbarKeys = new KeyCode[] {KeyCode.Alpha1 ,KeyCode.Alpha2 ,KeyCode.Alpha3 ,KeyCode.Alpha4 ,KeyCode.Alpha5 ,KeyCode.Alpha6 ,KeyCode.Alpha7 ,KeyCode.Alpha8 ,KeyCode.Alpha9};

    // should be called earlier than others
    private void Awake() {
        SetUpHotbarSlots();
        inventoryController = this.GetComponent<InventoryController>();
    }

    private void Update() {
        // Check for button press 1-9
        for (int i = 0; i < hotbarKeys.Length; i++){
            if (Input.GetKeyDown(hotbarKeys[i]))
            {
                //hight light here
                activeSlot = i;
                // inventoryController.UpdateInventory();
            }
        }
    }

    private void SetUpHotbarSlots(){
        for (int i = 0; i < hotbarSlotSize; i++){
            ItemSlot slot = transform.GetChild(i).GetComponent<ItemSlot>();
            hotbarSlots.Add(slot);
        }
    }

}
