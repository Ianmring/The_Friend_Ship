﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giveitem : MonoBehaviour
{
    public Item[] Items;
    public Item Cash;
    public Item key;
    public DiolaugeTrigger Plane;
    public Diolauge[] NewIntermdiolauges;

 public void GiveItem() {
        if (Items.Length > 0) {
            for (int i = 0; i < Items.Length; i++) {
                Inventory.instance.AddKey(Items[i], 1);
                GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[0];
            }
        }
        
    }
    public void TradeItemOneWatch() {
        if (Cash != null) {
            Inventory.instance.AddKey(Cash, 1);
            GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[1];
        }
        Application.LoadLevel(Application.loadedLevel);
    }
    public void TradeItemOneTrail() {
        if (key != null) {
            Plane.meet = DiolaugeTrigger.meetstates.mentioned;
            Inventory.instance.AddKey(key, 1);
            GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[2];
        }
        Debug.Log("Key got");
    }
    public void ItemMenuToot() {
        FindObjectOfType<Tutorial_Manager>().Tutorial(new Vector3(0,0), "To access the the shared items menu, press the menu button \n \n or F1 if using a Keyboard.");

    }
    public void Fin() {
        uimanager.UIinstance.itemcan = true;
    }

   
}
