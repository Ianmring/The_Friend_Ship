﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giveitem : MonoBehaviour
{
    public Item[] Items;
    public Item Cash;
    public Item key;
 public void GiveItem() {
        for (int i = 0; i < Items.Length; i++) {
            Inventory.instance.AddKey(Items[i], 1);

        }
    }
    public void TradeItemOneWatch() {
        Inventory.instance.AddKey(Cash, 1);
        Debug.Log("Cash");

    }
    public void TradeItemOneTrail() {
        Inventory.instance.AddKey(key, 1);

    }

}
