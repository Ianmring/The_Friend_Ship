using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchUI : UIMovement
{
    public override void Interactui() {
        base.Interactui();
        DiolaugeTrigger trigger;
        if (targetobj.GetComponentInParent<DiolaugeTrigger>() ) {


            trigger = targetobj.GetComponentInParent<DiolaugeTrigger>();

            foreach (var item in trigger.diooptions) {
                if (item.thingtodo == "TradeItemOneWatch") {
                    InventoryMenu.invmeninstance.RemoveUIKey(player.direction);

                    Destroy(this.gameObject);

                }
            }
            trigger.Tstartdio("Watch", "TradeItemOneWatch");

        } else {
            return;
        }
    }
}
