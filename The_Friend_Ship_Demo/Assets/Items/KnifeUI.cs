using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KnifeUI : UIMovement
{
    float vek;
    // Start is called before the first frame update
    public Transform dir;

    Image rend;

    CapsuleCollider2D cap;

    Vector3 dirrect;
    [SerializeField]
    BoxUI Box;
    // Update is called once per frame
    int animnum;

    [SerializeField]
    bool animationgo;
    
    public enum Animstates {none, Triggers, stick}
    public Animstates currenttriggers;



 public   bool L;
  public  bool R;

    public bool shaking;
    public override void Startfunt() {
        base.Startfunt();
        cap = dir.GetComponent<CapsuleCollider2D>();
        rend = dir.GetComponent<Image>();
        Tutorial_Manager.tootinstance.Tutorial(new Vector3(0, 0, 0), "This is the Item Menu, Both players must press the menu button again to exit the menu. ");
       // StartCoroutine("stickturn");

    }
    private void OnEnable() {

        if (rend != null) {
            rend.enabled = true;          
        }

        StartCoroutine("stickturn");
        //anim.AnimButtons[6].SetActive(false);

        //switch (hold) {
        //    case playerholding.p1:
        //        animnum = 6;

        //        break;
        //    case playerholding.p2:
        //        animnum = 7;

        //        break;

        //}

    }
    public override void Lateupfunt() {
        base.Lateupfunt();
        if (player.MovH > 0.5f) {
           dir.transform.Rotate(-Vector3.forward * Time.deltaTime * 50);
        } else if (player.MovH < -0.5f) {
            dir.transform.Rotate(Vector3.forward * Time.deltaTime * 50);

        }

        if (Box == null) {
            anim.AnimButtons[6].SetActive(false);

        } else {
            if (!Box.done && Box != null && currenttriggers == Animstates.Triggers) {
                anim.AnimButtons[6].SetActive(true);
                anim.anima[6].SetTrigger("Start");
            } else {
                anim.AnimButtons[6].SetActive(false);

            }

            if (!Box.done && Box != null && currenttriggers == Animstates.stick) {
                anim.AnimButtons[8].SetActive(true);
                if (Keyboard) {
                    anim.anima[8].SetTrigger("LeftRightKey");

                } else {
                    anim.anima[8].SetTrigger("LeftRight");
                }
            

                if (player.DirH > 0 && !R) {
                   
                    R = true;
                    L = false;
                    Box.KnifeShake(L,R);
                }

                if (player.DirH < 0 && !L) {
                    L = true;
                    R = false;
                    Box.KnifeShake(L, R);

                }


            } else {
                L = false;
                R = false;
                Box.knifeshakes = 0;
                shaking = false;
                anim.AnimButtons[8].SetActive(false);

            }
        }

      

      
        if (!ISlot.isslected) {
            // rend.enabled = true;
            if (Box != null) {
                Box.knifein = false;
                Box.open = false;
            }
           // Box = null;
          //  move = false;
        } 
        
        else {

            if (player.IReady > .5f && Box != null && !Box.done) {
                Box.knifein = true;
                rend.enabled = false;
                move = false;
                currenttriggers = Animstates.stick;


            } else if (Box != null) {

                Box.knifein = false;
                move = true;
                currenttriggers = Animstates.Triggers;


                rend.enabled = true;



            }

            
        }
    }

    public override void StayUI(Collider2D Coli) {

        base.EnterUI(Coli);

        if (Coli.GetComponent<BoxUI>() != null && ISlot.isslected) {

            if (Box == null) {
                Box = Coli.GetComponent<BoxUI>();

            }

            if (!Box.knifein && currenttriggers == Animstates.none) {
                currenttriggers = Animstates.Triggers;

            }
        }
    }
    public override void ExitUI(Collider2D Coli) {
        base.ExitUI(Coli);
        if (Coli.GetComponent<BoxUI>() != null) {

            currenttriggers = Animstates.none;

            Box.knifein = false;
            if (Box!= null && ISlot.isslected) {
               rend.enabled = true;

            }

            move = true;
            Box = null;
        }
    }
    public override void Interactui() {
        base.Interactui();
        DiolaugeTrigger trigger;
        if (targetobj.GetComponentInParent<DiolaugeTrigger>()) {

            trigger = targetobj.GetComponentInParent<DiolaugeTrigger>();
            trigger.Tstartdio("Knife", "N/A");
           

        } else {
            return;
        }
    }
    IEnumerator stickturn() {
        yield return null;
        if (Keyboard) {
            anim.anima[9].gameObject.SetActive(true);
            anim.anima[9].SetTrigger("LeftRightKey");
        } else {
            anim.anima[9].gameObject.SetActive(true);
            anim.anima[9].SetTrigger("LeftRight");
        }
        yield return new WaitForSeconds(3);
        anim.anima[9].SetTrigger("Done");
        anim.anima[9].gameObject.SetActive(false);

    }


}
