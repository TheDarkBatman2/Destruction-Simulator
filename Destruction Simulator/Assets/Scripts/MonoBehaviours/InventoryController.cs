using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    HotbarContoller hotbarController;
    public ExplosiveItem blankItem;
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

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            // will get current item
            // Fire code here
            Fire(hotbarController.hotbarSlots[hotbarController.activeSlot]);
        }        
    }

    public void Fire(ItemSlot slot){
        ExplosiveItem item = slot.GetItem();
        if (item != null){ // it wont happen that slot doesnt have set item , but still :)
            if (slot.itemAmount >= 1){
                slot.DecreaseItemAmount(1);

                if (item.itemType == ExplosiveItem.ExplosionType.Missile){
                    // Missile
                }
                else if (item.itemType == ExplosiveItem.ExplosionType.TimeBomb){
                    // TimeBomb
                }
                else if (item.itemType == ExplosiveItem.ExplosionType.Cannon){
                    // Cannon
                }
            }
        }
        
    }
}
