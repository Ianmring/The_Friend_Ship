using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WoodplankUI : MonoBehaviour
{
    UIMovement uimain;
    Playergen player;
    KeyitemTrigger trigg;
    public bool islit;
    void Start() {
        uimain = gameObject.GetComponent<UIMovement>();
        player = uimain.player;
        trigg = uimain.Trig;
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<LighterUI>().islight) {
            islit = true;
            GetComponent<Image>().color = Color.red;
        }
    }
}
