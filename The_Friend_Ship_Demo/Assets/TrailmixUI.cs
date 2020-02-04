using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrailmixUI : UIMovement
{

    int animnum;

    public GameObject mix;
    public GameObject candy;

    public GameObject Bench;

    public Sprite[] bagstates;

    Transform placetospawn;
     int bitstospawn;
     int candytosapwn;

    public int candiesinbag;
    public int etcinbag;

    bool poured;
    public override void startingfunt() {
        base.startingfunt();
        bitstospawn = 10;
        candytosapwn = 5;
        Bench = InventoryMenu.invmeninstance.interactionarea;
    }

    // Update is called once per frame
    public override void Lateupfunt() {
        base.Lateupfunt();
        if (!poured) {
            switch (hold) {
                case playerholding.p1:
                    animnum = 6;
                    if (player.IReady > .5f && ISlot.ontable && !poured) {
                        pourtrailmix();
                    }
                    break;
                case playerholding.p2:
                    animnum = 7;
                    if (player.Ready > .5f && ISlot.ontable && !poured) {
                        pourtrailmix();
                    }
                    break;

            }
        }
    }

    public void pourtrailmix() {
        for (int i = 0; i < bitstospawn; i++) {

            
            GameObject mixx;
            mixx = Instantiate(mix, Bench.transform);
           
        }
        for (int b = 0; b < candytosapwn; b++) {


            GameObject mixx;
            mixx = Instantiate(candy, Bench.transform);
          

        }
        GetComponent<Image>().sprite = bagstates[0];
        poured = true;

    }
    public override void ExitUI(Collider2D Coli) {
        base.ExitUI(Coli);
        if (Coli.transform.tag == "Bench") {
            anim.AnimButtons[animnum].SetActive(false);
           // anim.anima[animnum].SetTrigger("Start");
        }
    }
    public override void EnterUI(Collider2D Coli) {
        base.EnterUI(Coli);
        if (Coli.transform.tag == "Bench") {
            anim.AnimButtons[animnum].SetActive(true);
            anim.anima[animnum].SetTrigger("Start");
        }
    }
}
