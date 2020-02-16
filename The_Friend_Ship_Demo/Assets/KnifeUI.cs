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
    public override void Startfunt() {
        base.Startfunt();
        cap = dir.GetComponent<CapsuleCollider2D>();
        rend = dir.GetComponent<Image>();
    }
    private void OnEnable() {
        if (rend != null) {
            rend.enabled = true;

        }
    }
    public override void Lateupfunt() {
        base.Lateupfunt();
        if (move) {
            vek = Mathf.Atan2(-player.DirH, player.DirV) * Mathf.Rad2Deg;
            dir.eulerAngles = new Vector3(0, 0, vek);
        } 

        if (animationgo && !Box.done && Box !=null) {
            anim.AnimButtons[animnum].SetActive(true);
            anim.anima[animnum].SetTrigger("Start");
        } else {
            anim.AnimButtons[animnum].SetActive(false);

          //  anim.anima[animnum].SetTrigger("Exit");
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
            switch (hold) {
                case playerholding.p1:
                    animnum = 6;
                    if (player.IReady > .5f && Box != null) {
                        Box.knifein = true;
                        rend.enabled = false;
                        move = false;
                        animationgo = false;

                    } else if (Box != null) {

                        Box.knifein = false;
                        move = true;

                        rend.enabled = true;



                    }
                    break;
                case playerholding.p2:
                    animnum = 7;
                    if (player.Ready > .5f && Box != null) {
                        Box.knifein = true;
                        rend.enabled = false;
                        move = false;
                        animationgo = false;

                    } else if (Box != null) {

                        Box.knifein = false;
                        move = true;

                        rend.enabled = true;



                    }
                    break;



                    //transform.rotation = Quaternion.LookRotation()
            }

        }
    }

    public override void StayUI(Collider2D Coli) {

        base.EnterUI(Coli);

        if (Coli.GetComponent<BoxUI>() != null && ISlot.isslected) {

            if (Box == null) {
                Box = Coli.GetComponent<BoxUI>();

            }

            if (!Box.knifein) {
                animationgo = true;

            }
        }
    }
    public override void ExitUI(Collider2D Coli) {
        base.ExitUI(Coli);
        if (Coli.GetComponent<BoxUI>() != null) {

            animationgo = false;

            Box.knifein = false;
            if (Box!= null && ISlot.isslected) {
               rend.enabled = true;

            }

            move = true;
            Box = null;
        }
    }


}
