using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LighterUI : UIMovement
{
   public Sprite[] lightstates;
    Image lighter;
    public bool islight;
    int numberofstrikes;
    int strikes;
    bool isstruck;
  
    public override void startingfunt() {
        base.startingfunt();
        lighter = GetComponent<Image>();
        numberofstrikes = Random.Range(5, 8);
    }
    public override void Lateupfunt() {
        base.Lateupfunt();

        if (player.Ready > .5f && !isstruck && Trig.isusing && !islight && strikes < numberofstrikes) {
            strikes++;
            isstruck = true;


        } else if (strikes >= numberofstrikes && Trig.isusing) {
            islight = true;
        } else if (!Trig.isusing) {
            islight = false;
            strikes = 0;
        } else if (player.Ready < .5f && !islight) {
            isstruck = false;
        }

        if (islight) {
            lighter.sprite = lightstates[1];
        } else {
            lighter.sprite = lightstates[0];
        }

    }
    // Update is called once per frame
  
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "OBJ") {
            Debug.Log("collide");
        }
    }
}
