using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrailmixUI : UIMovement
{
    [SerializeField]
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
    bool tooton;
    public GameObject Mixholder;
   public string bagstate;

    public override void startingfunt() {
        base.startingfunt();
        bitstospawn = 7;
        candytosapwn = 8;
        Bench = InventoryMenu.invmeninstance.interactionarea;

        for (int i = 0; i < bitstospawn; i++) {


            GameObject mixx;
            mixx = Instantiate(mix, Mixholder.transform);
            Thingsinbag.Add(mixx);
            etcinbag++;
        }
        for (int b = 0; b < candytosapwn; b++) {


            GameObject mixx;
            mixx = Instantiate(candy, Mixholder.transform);
            Thingsinbag.Add(mixx);
            candiesinbag++;

        }
        Tutorial_Manager.tootinstance.Tutorialoff();


    }

    // Update is called once per frame
    public override void Lateupfunt() {
        base.Lateupfunt();
       

        if (candiesinbag > 0 || etcinbag > 0) {
            

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
            if (ISlot.ontable && ISlot.isslected) {
                anim.AnimButtons[animnum].SetActive(true);
                if (Keyboard) {
                    anim.anima[animnum].SetTrigger("StartK");

                } else {
                    anim.anima[animnum].SetTrigger("Start");
                }
            } else {

                anim.AnimButtons[animnum].SetActive(false);

            }
        } else {
            anim.AnimButtons[animnum].SetActive(false);
        }


        if (Input.GetButtonDown("Submit" + player.playernum)) {
            if (thingtoget != null && thingtoget.GetComponent<TrailBit>()) {
                TrailBit  Trail;
                Trail = thingtoget.GetComponent<TrailBit>();
                thingtoget.transform.SetParent(Mixholder.transform);
                Trail.movetoBag();
                Thingsinbag.Add(Trail.gameObject);
                lastthing = thingtoget;
                thingtoget = null;
                etcinbag++;
            }
           else if (thingtoget != null && thingtoget.GetComponent<candy>()) {
                candy candyy;
                candyy = thingtoget.GetComponent<candy>();
                thingtoget.transform.SetParent(Mixholder.transform);
                candyy.movetoBag();
                Thingsinbag.Add(candyy.gameObject);
                lastthing = thingtoget;
                thingtoget = null;
                candiesinbag++;
            }
        }

      

        if (thingtoget != null ) {
            anim.AnimButtons[0].SetActive(true);

            if (Keyboard) {
                anim.anima[0].SetTrigger("StartK");

            } else {
                anim.anima[0].SetTrigger("Start");
            }
            //anim.AnimButtons[0].transform.localPosition = new Vector3(-222, -135);

        } else {
            anim.AnimButtons[0].SetActive(false);

        }

        if (candiesinbag < etcinbag || candiesinbag == etcinbag) {
            bagstate = "Mix";

        }
        else if (candiesinbag >= 1 && candiesinbag < 12 && etcinbag == 0) {
            bagstate = "Kindofcandies";
        }
         else if(candiesinbag >= 16 && etcinbag == 0) {
            bagstate = "FullCandy";
            if (!tooton) {
                Tutorial_Manager.tootinstance.Tutorial(new Vector3(0, 0), "Items can interact with the outside world too! \n \n Who ever is controlling the object can hover the object's pointer over something and press A \n \n Space if you're on a keyboard.");
                tooton = true;
            }
        } else {
            bagstate = "Empty";
        }
    }
    public override void Interactui() {
        base.Interactui();
        DiolaugeTrigger trigger;
        if (targetobj.GetComponentInParent<DiolaugeTrigger>()) {

            trigger = targetobj.GetComponentInParent<DiolaugeTrigger>();
            foreach (var item in trigger.diooptions) {
                if (item.thingtodo == "TradeItemOneTrail" && item.situation == "FullCandy" && bagstate == "FullCandy") {
                    InventoryMenu.invmeninstance.RemoveUIKey(player.direction);
                    Tutorial_Manager.tootinstance.Tutorialoff();
                    Destroy(this.gameObject);

                }
            }

            trigger.Tstartdio(bagstate, "TradeItemOneTrail");

        } else {
            return;
        }
    }
    public void pourtrailmix() {
       
      //  if (!poured) {
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
        //} else if (!singlepour)         
        //{

        //    if (Thingsinbag[Thingsinbag.Count -1].GetComponent<TrailBit>()) {
        //        etcinbag--;
        //    } else if (Thingsinbag[Thingsinbag.Count - 1].GetComponent<candy>()) {
        //        candiesinbag--;
        //    }
        //        Thingsinbag[Thingsinbag.Count-1].transform.SetParent(Bench.transform);
        //        Thingsinbag[Thingsinbag.Count-1].SendMessage("movetoBench");
        //        Thingsinbag.RemoveAt(Thingsinbag.Count-1);
           
        //}

       

    }
    public override void ExitUI(Collider2D Coli) {
        base.ExitUI(Coli);

        thingtoget = null;
       
    }
  
    private void OnTriggerStay2D(Collider2D Coli) {
        if (Coli.GetComponent<TrailBit>() || Coli.GetComponent<candy>()) {
            thingtoget = Coli.gameObject;

        }
    }
}
