using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinui : UIMovement
{
   public bool sideAgold;
    public bool sidebgold;

    public enum side { A, B};
    side sidee;

    public Image[] coin;

    bool flip;
    bool sideflip;


    string coinstate;

    string SendState;
    // Start is called before the first frame update
    public override void startingfunt() {
        base.startingfunt();
        coinstate = "NotPainted";
        SendState = "N/A";
        flipcoing();
    }

    // Update is called once per frame
    public override void Lateupfunt() {
        base.Lateupfunt();

        if (player.Ready > .5f && !flip && !sideflip) {
            flipcoing();
            flip = true;
        } else if (player.Ready < .5f ) {
            flip = false;
        }

        if (player.IReady > .5f && !flip && sideflip) {
            flipcoing();
            flip = true;
        } else if (player.Ready < .5f) {
            flip = false;
        }

     
    }

    public override void Interactui() {
        base.Interactui();
        DiolaugeTrigger trigger;
        if (targetobj.GetComponent<DiolaugeTrigger>()) {
            trigger = targetobj.GetComponent<DiolaugeTrigger>();
            trigger.Tstartdio(coinstate, SendState);

                      
        }
        
    }
    public void Paintcoin() {

        switch (sidee) {
            case side.A:
                coin[0].color = Color.yellow;
                sideAgold = true;
                coinstate = "Sidepainted";
                SendState = "N/A";
                break;
            case side.B:
                coin[1].color = Color.yellow;
                sidebgold = true;
                coinstate = "Sidepainted";
                SendState = "N/A";

                break;
          
        }

        if (sideAgold && sidebgold) {
            coinstate = "CoinPainted";
            SendState = "Dothing";

        }

    }

    void flipcoing() {
        switch (sidee) {
            case side.A:
                sidee = side.B;
                coin[1].gameObject.SetActive(true);
                coin[0].gameObject.SetActive(false);
                sideflip = true;

                break;
            case side.B:
                sidee = side.A;
                coin[0].gameObject.SetActive(true);
                coin[1].gameObject.SetActive(false);
                sideflip = false;

                break;
            
        }
    }
}
