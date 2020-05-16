using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchUI : UIMovement
{
    public override void Interactui() {
        base.Interactui();
        DiolaugeTrigger trigger;
        Diolauge_Trigger_2D trigger2d;

        if (targetobj.GetComponentInParent<DiolaugeTrigger>()) {


            trigger = targetobj.GetComponentInParent<DiolaugeTrigger>();

            foreach (var item in trigger.diooptions) {
                if (item.thingtodo == "TradeItemOneWatch") {
                    InventoryMenu.invmeninstance.RemoveUIKey(player.direction);

                    Destroy(this.gameObject);

                }
            }
            trigger.Tstartdio("Watch", "TradeItemOneWatch");

        } else if (targetobj.GetComponentInParent<Diolauge_Trigger_2D>()) {

            trigger2d = targetobj.GetComponentInParent<Diolauge_Trigger_2D>();

            foreach (var item in trigger2d.diooptions) {
                if (item.thingtodo == "TradeItemOneWatch") {
                    InventoryMenu.invmeninstance.RemoveUIKey(player.direction);

                    Destroy(this.gameObject);

                }
            }
            trigger2d.Tstartdio("Watch", "TradeItemOneWatch");

        } else {
            return;
        }
    }
    public override void startingfunt() {
        base.startingfunt();
        interactionItem = true;
    }
}
