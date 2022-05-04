using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    HotbarContoller hotbarController;
    public Item blankItem;
    public float pickupRange = 5f;
    void Start()
    {
        hotbarController = this.GetComponent<HotbarContoller>();
        ResetInventory();
    }

    public ItemSlot getEmptySlot(){
        foreach (ItemSlot slot in hotbarController.hotbarSlots){ // check for space
            if (slot.GetItem() == blankItem){
                return slot;
            }          
        }
        return null;
    }

    public void ResetInventory(){
        foreach (ItemSlot slot in hotbarController.hotbarSlots){
            slot.SetItem(blankItem);
        }
    }
    
    public void AddItem(PickupController itemPC){
        getEmptySlot().SetItem(itemPC.item ,itemPC.gameObject); // adds item here, Null check is somewhere else
    }

    public void UpdateActiveSlot(){
        // show current activate slot
        ItemSlot activeSlot = hotbarController.hotbarSlots[hotbarController.activeSlot];
        if (activeSlot.GetItem() != blankItem){ // For sure every item has prefab
            if (activeSlot.itemObject.activeSelf == false){ // to avoid laggy stuff , so it will check if its already activated or not
                hotbarController.ActivateItemInSlot(hotbarController.activeSlot);
            }
        }
        
    }

    void Update()
    {
        // Pickup
        if (Input.GetKeyDown(KeyCode.E)){
            // if it has valid state it will pickup item in range and if it has enough space
            CheckAndAddItem();
        }
        // Drop
        if (Input.GetKeyDown(KeyCode.Q)){
            if (CheckSlot()){
                DropItem();
            }
        }
    }

    void CheckAndAddItem(){
        Ray ray = References.Instance.fpsCam.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit ,pickupRange)){
            PickupController temp = hit.transform.gameObject.GetComponent<PickupController>();
            if (temp != null){
                if (getEmptySlot() != null){
                    PickupItem(temp);
                    AddItem(temp);
                }
            }
        }
    }

    void PickupItem(PickupController pickupController){
        pickupController.gameObject.SetActive(false); // it will enable it later if its current slot
        pickupController.OnPickup();

    }

    bool CheckSlot(){
        ItemSlot currSlot = hotbarController.hotbarSlots[hotbarController.activeSlot];
        if (currSlot.GetItem() != blankItem){
            return true;
        }
        return false;
    }
    void DropItem(){
        ItemSlot currSlot = hotbarController.hotbarSlots[hotbarController.activeSlot];
        currSlot.itemObject.transform.SetParent(null);
        PickupController droppedItemPickupController = currSlot.itemObject.AddComponent<PickupController>();
        droppedItemPickupController.item = currSlot.GetItem();
        droppedItemPickupController.OnDrop();
        currSlot.EmptySlot();
    }
}
