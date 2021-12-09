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
                // hight light here

                // disable previous object
                DisableSlot(activeSlot);
                activeSlot = i;
                // enable current object
                // it will be in update inventory method
            }
            inventoryController.UpdateInventory();
        }
    }

    public void ActivateSlot(int indx){
        GameObject obj = hotbarSlots[indx].itemObject;
        if (obj != null){
            obj.SetActive(true);
            FixScale_Parent(obj);
        }
    }

    private void DisableSlot(int indx){
        GameObject obj = hotbarSlots[indx].itemObject;
        if (obj != null){
            obj.transform.SetParent(null); // to make sure if i fix scale it wont bug anything
            obj.SetActive(false);
        }
    }

    private void FixScale_Parent(GameObject obj){ // Scale
        inventoryController.gunContainer.transform.localScale = obj.transform.localScale;
        obj.transform.SetParent(inventoryController.gunContainer);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        obj.transform.localScale = Vector3.one;
    }

    private void SetUpHotbarSlots(){
        for (int i = 0; i < hotbarSlotSize; i++){
            ItemSlot slot = transform.GetChild(i).GetComponent<ItemSlot>();
            hotbarSlots.Add(slot);
        }
    }

}
