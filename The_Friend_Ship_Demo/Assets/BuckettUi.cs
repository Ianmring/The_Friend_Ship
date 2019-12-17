using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckettUi : UIMovement
{
    bool isoncoin;

   public coinui coin;

    bool painting;

    // Start is called before the first frame update
    public override void startingfunt() {
        base.startingfunt();
        

    }

    public override void Lateupfunt() {
        base.Lateupfunt();

        switch (hold) {
            case playerholding.p1:
                if (player.IReady > .5f && isoncoin && !painting) {
                    coin.Paintcoin();
                    painting = true;
                } else if (player.IReady < .5) {
                    painting = false;
                }
                break;
            case playerholding.p2:
                if (player.Ready > .5f && isoncoin && !painting) {
                    coin.Paintcoin();
                    painting = true;
                } else if(player.Ready < .5) {
                    painting = false;
                }
                break;
         
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {      
    
        if (collision.gameObject.GetComponent<coinui>()) {
            isoncoin = true;
            coin = collision.gameObject.GetComponent<coinui>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {

        if (collision.gameObject.GetComponent<coinui>()) {
            isoncoin = false;
            coin = null;
        }
    }
}
