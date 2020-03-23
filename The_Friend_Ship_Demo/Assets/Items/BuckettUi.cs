using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckettUi : UIMovement
{
    bool isoncoin;

   public coinui coin;

    public BoxUI box;

    bool painting;

    int animnum;
    // Start is called before the first frame update
    public override void startingfunt() {
        base.startingfunt();
        

    }

    public override void Lateupfunt() {
        base.Lateupfunt();

        switch (hold) {
            case playerholding.p1:
                animnum = 6;
                if (player.IReady > .5f && isoncoin && !painting) {
                    coin.Paintcoin();
                    painting = true;
                } else if (player.IReady < .5) {
                    painting = false;
                }
                break;
            case playerholding.p2:
                animnum = 7;
                if (player.Ready > .5f && isoncoin && !painting) {
                    coin.Paintcoin();
                    painting = true;
                } else if(player.Ready < .5) {
                    painting = false;
                }
                break;
         
        }
        if (box != null) {
            if (box.currentboxstate == BoxUI.boxstates.Pryed && Input.GetButtonDown("Submit" + player.playernum) && !box.open) {
                box.open = true;
             //   box.currentboxstate = BoxUI.boxstates.Open;
            } else if (box.currentboxstate == BoxUI.boxstates.Open) {
                anim.anima[0].SetTrigger("Exit");
                anim.AnimButtons[0].SetActive(false);
                box = null;
            }
        }
      
    }
    public override void EnterUI(Collider2D Coli) {
        base.EnterUI(Coli);

        if (Coli.gameObject.GetComponent<coinui>()) {
            //Buttons.SetActive(true);
            anim.AnimButtons[animnum].SetActive(true);
            anim.anima[animnum].SetTrigger("Start");
            isoncoin = true;
            coin = Coli.gameObject.GetComponent<coinui>();

        } else if (Coli.GetComponent<BoxUI>() ) {
          
            box = Coli.GetComponent<BoxUI>();
            if (box.currentboxstate == BoxUI.boxstates.Pryed ) {
                anim.AnimButtons[0].SetActive(true);
                anim.anima[0].SetTrigger("Start");
            }
        }
    }
    public override void ExitUI(Collider2D Coli) {
        base.ExitUI(Coli);
        if (Coli.gameObject.GetComponent<coinui>()) {
            //Buttons.SetActive(false);
            anim.AnimButtons[animnum].SetActive(false);

            isoncoin = false;
            coin = null;
        } else if (Coli.GetComponent<BoxUI>() ) {
            if (box != null) {
                anim.anima[0].SetTrigger("Exit");
                anim.AnimButtons[0].SetActive(false);
                box = null;
            }
         

        }

    }
   
}
