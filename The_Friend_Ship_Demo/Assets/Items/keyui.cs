using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyui : UIMovement
{
    public override void Interactui() {
        base.Interactui();
        DiolaugeTrigger trigger;
        Diolauge_Trigger_2D trigger2d;
        if (targetobj.GetComponent<DiolaugeTrigger>()) {
            InventoryMenu.invmeninstance.RemoveUIKey(player.direction);
            Destroy(this.gameObject);
            trigger = targetobj.GetComponentInParent<DiolaugeTrigger>();
            trigger.Tstartdio("Key", "GiveItem");
            if (trigger.Item && trigger.name == "Plane") {
                trigger.meet = DiolaugeTrigger.meetstates.post;
               

            }
           
           
        }
        if (targetobj.GetComponent<Diolauge_Trigger_2D>()) {
            InventoryMenu.invmeninstance.RemoveUIKey(player.direction);
            Destroy(this.gameObject);
            trigger2d = targetobj.GetComponentInParent<Diolauge_Trigger_2D>();
            trigger2d.Tstartdio("Key", "GiveItem");
            if (trigger2d.Item && trigger2d.name == "Plane") {
                trigger2d.meet = Diolauge_Trigger_2D.meetstates2d.post;


            }
        }
        if (targetobj.GetComponent<XMarkgo>()) {
            targetobj.GetComponent<XMarkgo>().Unlockdio();
        } else {
            return;
        }
    }
   
}
