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
        Tutorial_Manager.tootinstance.Tutorial(new Vector3(0, 0, 0), "Any item left on the center area will stay there if a player switchs to another item");
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
    public override void EnterUI(Collider2D Coli) {
        base.EnterUI(Coli);
        if (Coli.gameObject.tag == "OBJ") {
            Debug.Log("collide");
        }
    }
    private void OnEnable() {
        islight = false;
        strikes = 0;

    }

}
