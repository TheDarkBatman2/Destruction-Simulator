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

    public void ResetInventory(){
        foreach (ItemSlot slot in hotbarController.hotbarSlots){
            slot.SetItem(blankItem);
        }
    }
    
    public void AddItems(){

    }
    public void UpdateInventory(){
        // show current activate slot
        ItemSlot activeSlot = hotbarController.hotbarSlots[hotbarController.activeSlot];
        if (activeSlot.GetItem() != blankItem){ // For sure every item has prefab
            if (activeSlot.itemObject.activeSelf == false){ // to avoid laggy stuff , so it will check if its already activated or not
                hotbarController.ActivateSlot(hotbarController.activeSlot);
            }
        }
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            // will get current item
            // Fire code here
            Fire(hotbarController.hotbarSlots[hotbarController.activeSlot]);
        } 

        // Pickup
        if (Input.GetKeyDown(KeyCode.E)){
            CheckItem();
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            if (CheckSlot()){
                DropItem();
            }
        }
    }

    void CheckItem(){
        Ray ray = References.Instance.fpsCam.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit ,pickupRange)){
            PickupController temp = hit.transform.gameObject.GetComponent<PickupController>();
            if (temp != null){
                foreach (ItemSlot slot in hotbarController.hotbarSlots){ // check for space
                    if (slot.GetItem() == blankItem){
                        PickupItem(temp);
                        slot.SetItem(temp.item ,temp.gameObject);
                        break;
                    }
                    
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



    public void Fire(ItemSlot slot){
        Item item = slot.GetItem();
        if (item != null){ // it wont happen that slot doesnt have set item , but still :)
            if (slot.itemAmount >= 1){
                slot.DecreaseItemAmount(1);

                // if (item.itemType == ExplosiveItem.ExplosionType.Missile){
                //     // Missile
                // }
                // else if (item.itemType == ExplosiveItem.ExplosionType.TimeBomb){
                //     // TimeBomb
                // }
                // else if (item.itemType == ExplosiveItem.ExplosionType.Cannon){
                //     // Cannon
                // }
            }
        }
        
    }
}
