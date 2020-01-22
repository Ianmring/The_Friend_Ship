using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WoodplankUI : UIMovement
{
    public bool islit;



    // Update is called once per frame
    public override void EnterUI(Collider2D Coli) {
        base.EnterUI(Coli);
        if (Coli.GetComponent<LighterUI>().islight) {
            islit = true;
            GetComponent<Image>().color = Color.red;
        }
    }
  
}
