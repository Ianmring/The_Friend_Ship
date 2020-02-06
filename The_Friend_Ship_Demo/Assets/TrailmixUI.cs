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

   // public List<TrailBit> bits;
    //public List<candy> candys;
    public List<GameObject> Thingsinbag;
    Transform placetospawn;
     int bitstospawn;
     int candytosapwn;

    public int candiesinbag;
    public int etcinbag;

    [SerializeField]
    GameObject thingtoget;
    [SerializeField]
    GameObject lastthing;
    

    bool poured;
    bool singlepour;
    bool doublepour;
    public override void startingfunt() {
        base.startingfunt();
        bitstospawn = 10;
        candytosapwn = 7;
        Bench = InventoryMenu.invmeninstance.interactionarea;

        for (int i = 0; i < bitstospawn; i++) {


            GameObject mixx;
            mixx = Instantiate(mix, this.transform);
            Thingsinbag.Add(mixx);
            etcinbag++;
        }
        for (int b = 0; b < candytosapwn; b++) {


            GameObject mixx;
            mixx = Instantiate(candy, this.transform);
            Thingsinbag.Add(mixx);
            candiesinbag++;

        }


    }

    // Update is called once per frame
    public override void Lateupfunt() {
        base.Lateupfunt();
       

        if (candiesinbag > 0 || etcinbag > 0) {
            if (ISlot.ontable) {
                anim.AnimButtons[animnum].SetActive(true);
                anim.anima[animnum].SetTrigger("Start");
            } else {
                anim.AnimButtons[animnum].SetActive(false);

            }

            switch (hold) {
                case playerholding.p1:
                    animnum = 6;
                    if (player.IReady > .5f) {
                        if (ISlot.ontable) {
                            pourtrailmix();
                        }
                        if (!singlepour) {
                            singlepour = true;

                        } 
                    } else {
                        singlepour = false;
                    }
                    break;
                case playerholding.p2:
                    animnum = 7;
                    if (player.Ready > .5f) {
                        if (ISlot.ontable) {
                            pourtrailmix();
                        }
                        if (!singlepour) {
                            singlepour = true;

                        }
                    } else {
                        singlepour = false;
                    }
                    break;

            }
        } else {
            anim.AnimButtons[animnum].SetActive(false);
        }


        if (Input.GetButtonDown("Submit" + player.playernum)) {
            if (thingtoget != null && thingtoget.GetComponent<TrailBit>()) {
                TrailBit  Trail;
                Trail = thingtoget.GetComponent<TrailBit>();
                thingtoget.transform.SetParent(this.transform);
                Trail.movetoBag();
                Thingsinbag.Add(Trail.gameObject);
                lastthing = thingtoget;
                thingtoget = null;
                etcinbag++;
            }
           else if (thingtoget != null && thingtoget.GetComponent<candy>()) {
                candy candyy;
                candyy = thingtoget.GetComponent<candy>();
                thingtoget.transform.SetParent(this.transform);
                candyy.movetoBag();
                Thingsinbag.Add(candyy.gameObject);
                lastthing = thingtoget;
                thingtoget = null;
                candiesinbag++;
            }
        }

      

        if (thingtoget != null ) {
            anim.AnimButtons[0].SetActive(true);

            anim.anima[0].SetTrigger("Start");
            //anim.AnimButtons[0].transform.localPosition = new Vector3(-222, -135);

        } else {
            anim.AnimButtons[0].SetActive(false);

        }
    }

    public void pourtrailmix() {
       
        if (!poured) {
            foreach (var item in Thingsinbag) {
                item.transform.SetParent(Bench.transform);
                item.gameObject.SendMessage("movetoBench");
              //  item.movetoBench();
            }
            //foreach (var item in candys) {
            //    item.transform.SetParent(Bench.transform);
            //    item.movetoBench();

            //}
            Thingsinbag.Clear();
            //candys.Clear();
            GetComponentInChildren<Image>().sprite = bagstates[0];
            etcinbag = 0;
            candiesinbag = 0;
            poured = true;
        } else if (!singlepour)         
        {

            if (Thingsinbag[Thingsinbag.Count -1].GetComponent<TrailBit>()) {
                etcinbag--;
            } else if (Thingsinbag[Thingsinbag.Count - 1].GetComponent<candy>()) {
                candiesinbag--;
            }
                Thingsinbag[Thingsinbag.Count-1].transform.SetParent(Bench.transform);
                Thingsinbag[Thingsinbag.Count-1].SendMessage("movetoBench");
                Thingsinbag.RemoveAt(Thingsinbag.Count-1);
           
        }

       

    }
    public override void ExitUI(Collider2D Coli) {
        base.ExitUI(Coli);

        thingtoget = null;
        //if (Coli.GetComponent<TrailBit>()) {
        //    trailtoget = null;
        //}
        //if (Coli.GetComponent<candy>()) {
        //    candytoget = null;
        //}
    }
    //public override void EnterUI(Collider2D Coli) {
    //    base.EnterUI(Coli);
    //    if (Coli.GetComponent<TrailBit>() || Coli.GetComponent<candy>()) {
    //        thingtoget = Coli.gameObject;

    //    }

    //    //if (Coli.GetComponent<TrailBit>()) {
    //    //    trailtoget = Coli.GetComponent<TrailBit>();
    //    //}
    //    //if (Coli.GetComponent<candy>()) {
    //    //    candytoget = Coli.GetComponent<candy>();
    //    //}
    //}
    private void OnTriggerStay2D(Collider2D Coli) {
        if (Coli.GetComponent<TrailBit>() || Coli.GetComponent<candy>()) {
            thingtoget = Coli.gameObject;

        }
    }
}
