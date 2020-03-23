using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giveitem : MonoBehaviour
{
    public Item[] Items;
    public Item Cash;
    public Item key;

    public Diolauge[] NewIntermdiolauges;

 public void GiveItem() {
        for (int i = 0; i < Items.Length; i++) {
            Inventory.instance.AddKey(Items[i], 1);
            GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[0];
        }
    }
    public void TradeItemOneWatch() {
        Inventory.instance.AddKey(Cash, 1);
        GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[1];

    }
    public void TradeItemOneTrail() {
        Inventory.instance.AddKey(key, 1);
        GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[2];

    }
    public void ItemMenuToot() {
        FindObjectOfType<Tutorial_Manager>().Tutorial(new Vector3(0,-175,0), "To access the the shared items menu, press the menu button.");

    }
    public void Fin() {
        uimanager.UIinstance.itemcan = true;
    }

   
}
