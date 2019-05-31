using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Store Item Slot")]

public class StoreItemInfo : ScriptableObject
{
    public Item ItemTobuy;
    public Item[] costItems;
    public int[] costAmmounts;

  //  public InventoryMenu Inv;


}
