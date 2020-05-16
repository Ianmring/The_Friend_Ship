using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoom : MonoBehaviour
{

  

    bool there;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayersSelector>()) {
            there = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayersSelector>()) {
            there = false;
        }
    }

    private void Update() {
        if (there) {
            if (Input.GetButtonDown(DiolaugeManager.DioInstance.p1C + "Submit" + DiolaugeManager.DioInstance.p1I.ToString()) ) {

                movement.MovInstance.currentroom.Exitroom();
            }
            if (Input.GetButtonDown(DiolaugeManager.DioInstance.p2C + "Submit" + DiolaugeManager.DioInstance.p2I.ToString())) {

                movement.MovInstance.currentroom.Exitroom();
            }
        }
    }
  

}
