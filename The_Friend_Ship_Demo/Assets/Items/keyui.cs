using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyui : UIMovement
{
    public bool unlocked;
    public override void Interactui() {
        base.Interactui();
        DiolaugeTrigger trigger;
        if (targetobj.GetComponentInParent<DiolaugeTrigger>()) {
            InventoryMenu.invmeninstance.RemoveUIKey(player.direction);
            Destroy(this.gameObject);
            trigger = targetobj.GetComponentInParent<DiolaugeTrigger>();
            trigger.Tstartdio("Key", "GiveItem");
            if (trigger.Item && trigger.name == "Plane") {
                trigger.meet = DiolaugeTrigger.meetstates.post;
               

            }
           
           
        } else {
            return;
        }
    }
    private void OnEnable() {
     //   Tutorial_Manager.tootinstance.Tutorial(this.gameObject.transform.position, "Items and interact with the outside world too! Who ever is controlling the object can over something and press A.");
    }
}
