using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarContoller : MonoBehaviour
{
    public Color defaultSlotColor;
    public Color activeSlotColor;
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

    public void Start(){
        SlotColorEnabled(0);
    }

    private void Update() {
        // Check for button press 1-9
        for (int i = 0; i < hotbarKeys.Length; i++){
            
            if (Input.GetKeyDown(hotbarKeys[i]))
            {
                if (i != activeSlot) { // if its not currently active

                    // disable previous object
                    DisableItemInSlot(activeSlot);
                    SlotColorDisabled(activeSlot); // prev active slot
                    activeSlot = i;
                    SlotColorEnabled(activeSlot); // cur active slot

                    break;

                    // enable current object
                    // it will be in update inventory method
                }
            }
        }
        inventoryController.UpdateActiveSlot(); // it checks stuff and enables item in slot if its true
    }

    // Changing color of slot is just visual and basically does nothing xD
    public void SlotColorDisabled(int indx){
        hotbarSlots[indx].gameObject.GetComponent<Image>().color = defaultSlotColor;  // Changes color of slot
    }
    public void SlotColorEnabled(int indx){
        hotbarSlots[indx].gameObject.GetComponent<Image>().color = activeSlotColor; // Change color of slot
    }
    public void ActivateItemInSlot(int indx){
        GameObject obj = hotbarSlots[indx].itemObject;
        if (obj != null){
            References.Instance.itemPanelTexture.sprite = hotbarSlots[indx].GetItem().itemPanelIcon;  // Sets the texture of item panel
            obj.SetActive(true);
            FixScale_Parent(obj);
        }
    }

    private void DisableItemInSlot(int indx){
        GameObject obj = hotbarSlots[indx].itemObject;
        References.Instance.itemPanelCounts.text = "---"; // Sets the panel counts to ---
        if (obj != null){
            References.Instance.itemPanelTexture.sprite = null;  // Sets the texture of item panel
            obj.transform.SetParent(null); // to make sure if i fix scale it wont bug anything
            obj.SetActive(false);
        }
    }

    private void FixScale_Parent(GameObject obj){ // Fixes scale of object
        // for most cases Indx is active slot , if it caused bug fix it :)
        References.Instance.gunContainer.transform.localScale = obj.transform.localScale;
        obj.transform.SetParent(References.Instance.gunContainer);
        obj.transform.localPosition = Vector3.zero;
        if (hotbarSlots[activeSlot].GetItem().originalPrefab != null){
            obj.transform.localRotation = hotbarSlots[activeSlot].GetItem().originalPrefab.transform.rotation; // it will set rotation to original prefab rotation so it will be useful in some cases
        }
        else {
            obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }        
        obj.transform.localScale = Vector3.one;
    }

    private void SetUpHotbarSlots(){
        for (int i = 0; i < hotbarSlotSize; i++){
            ItemSlot slot = transform.GetChild(i).GetComponent<ItemSlot>();
            hotbarSlots.Add(slot);
        }
    }

}
