using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIItem : MonoBehaviour
{
      UIMovement uimain;
    Playergen player;
    KeyitemTrigger trigg;
        void Start()
    {
      uimain =  gameObject.GetComponent<UIMovement>();
        player = uimain.player;
        trigg = uimain.Trig;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(player.Controller+"Submit" + player.playernum.ToString()) && trigg.isusing) {
            Debug.Log("Hit");
        }


    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "OBJ") {
            Debug.Log("collide");
        }
    }

}
