using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WoodplankUI : UIMovement
{
    public bool islit; 

   

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<LighterUI>().islight) {
            islit = true;
            GetComponent<Image>().color = Color.red;
        }
    }
}
