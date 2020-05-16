using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giveitem : MonoBehaviour
{
    public Item[] Items;
    public Item Cash;
    public Item key;

    public distancedio diotrigger;
    // public DiolaugeTrigger Plane;

    public Diolauge_Trigger_2D npctrigg;
    public Diolauge[] NewIntermdiolauges;
    public Diolauge[] NewMentiondiolauges;

    public Diolauge_Trigger_2D[] referenceNPCs;

   

    //public int currentrefNPCdiopoint;

 public void GiveItem() {
        if (Items.Length > 0) {
            for (int i = 0; i < Items.Length; i++) {
                Inventory.instance.AddKey(Items[i], 1);
               
            }
            if (GetComponent<DiolaugeTrigger>()) {
                GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[0];

            } else if (GetComponent<Diolauge_Trigger_2D>()) {
                GetComponent<Diolauge_Trigger_2D>().IntermDio = NewIntermdiolauges[0]; 
                GetComponent<Diolauge_Trigger_2D>().newintermdio();
            }
        }

        if (referenceNPCs.Length > 0) {
            foreach (var item in referenceNPCs) {
                item.meet = Diolauge_Trigger_2D.meetstates2d.mentioned;
                item.newdiolauge();
            }
            DiolaugeManager.DioInstance.currentstorymoment++;


        }

    }
    public void TradeItemOneWatch() {
        if (Cash != null) {
            Inventory.instance.AddKey(Cash, 1);
            if (GetComponent<DiolaugeTrigger>()) {
                GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[1]; //1

            } else if (GetComponent<Diolauge_Trigger_2D>()) {
                GetComponent<Diolauge_Trigger_2D>().IntermDio = NewIntermdiolauges[1];
                GetComponent<Diolauge_Trigger_2D>().newintermdio();

            }
        }
        if (referenceNPCs.Length > 0) {
            foreach (var item in referenceNPCs) {
                item.meet = Diolauge_Trigger_2D.meetstates2d.mentioned;
                item.newdiolauge();
            }

            DiolaugeManager.DioInstance.currentstorymoment++;
            //currentrefNPCdiopoint++;

        }
        Application.LoadLevel(Application.loadedLevel);
    }
    public void TradeItemOneTrail() {
        if (key != null) {
          //  Plane.meet = DiolaugeTrigger.meetstates.mentioned;
            Inventory.instance.AddKey(key, 1);

            if (GetComponent<DiolaugeTrigger>()) {
                GetComponent<DiolaugeTrigger>().IntermDio = NewIntermdiolauges[2]; //2

            }
            else if (GetComponent<Diolauge_Trigger_2D>()) {
                GetComponent<Diolauge_Trigger_2D>().IntermDio = NewIntermdiolauges[2];
                GetComponent<Diolauge_Trigger_2D>().newintermdio();

            }
            npctrigg.meet = Diolauge_Trigger_2D.meetstates2d.mentioned;
            diotrigger.gameObject.SetActive(true);
        }
        Debug.Log("Key got");
    }
    public void ItemMenuToot() {
 switch (movement.MovInstance.conttype) {
            case movement.controllertype.Xbox:             
                    Tutorial_Manager.tootinstance.Tutorial(new Vector3(0, 150, 0), "To access the shared items menu, press the menu button");               

                break;
            case movement.controllertype.XboxHyb:
                Tutorial_Manager.tootinstance.Tutorial(new Vector3(0, 150, 0), "To access the shared items menu, press the menu button or F1");
                break;
            case movement.controllertype.Playstation:
                Tutorial_Manager.tootinstance.Tutorial(new Vector3(0, 150, 0), "To access the shared items menu, press the touch screen button");
                break;
            case movement.controllertype.PlaystationHyb:
                Tutorial_Manager.tootinstance.Tutorial(new Vector3(0, 150, 0), "To access the shared items menu, press the touch screen button or F1");

                break;
            case movement.controllertype.Keypad:
                Tutorial_Manager.tootinstance.Tutorial(new Vector3(0, 150, 0), "To access the shared items menu, press F1");

                break;
         
        }
    }

    public void Newmention() {
        GetComponent<Diolauge_Trigger_2D>().IntermDio = NewIntermdiolauges[0];

    }
    public void Fin() {
        uimanager.UIinstance.itemcan = true;
    }

   
}
