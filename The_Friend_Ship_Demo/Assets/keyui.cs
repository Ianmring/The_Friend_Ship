using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyui : UIMovement
{
    public bool unlocked;
    public override void Interactui() {
        base.Interactui();
        DiolaugeTrigger trigger;
        if (targetobj.GetComponentInParent<DiolaugeTrigger>() && !unlocked) {
            
            trigger = targetobj.GetComponentInParent<DiolaugeTrigger>();
            trigger.Tstartdio("Key", "GiveItem");
            unlocked = true;

        } else {
            return;
        }
    }
}
