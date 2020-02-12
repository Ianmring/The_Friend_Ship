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

    public override void Lateupfunt() {
        base.Lateupfunt();
        if (move) {
            vek = Mathf.Atan2(-player.DirH, player.DirV) * Mathf.Rad2Deg;
            dir.eulerAngles = new Vector3(0, 0, vek);
        }
        if (animationgo) {
            anim.AnimButtons[animnum].SetActive(true);
            anim.anima[animnum].SetTrigger("Start");
        } else {
            anim.anima[animnum].SetTrigger("Exit");
            anim.AnimButtons[animnum].SetActive(false);
        }
        switch (hold) {
            case playerholding.p1:
                animnum = 6;
                if (player.IReady > .5f && Box != null) {
                    Box.knifein = true;
                    rend.enabled = false;
                    move = false;
                    animationgo = false;

                } else if (player.IReady < .5f && Box != null) {

                    Box.knifein = false;
                    rend.enabled = true;

                    move = true;


                }
                break;
            case playerholding.p2:
                animnum = 7;
                if (player.Ready > .5f && Box != null) {
                    Box.knifein = true;
                    rend.enabled = false;
                    move = false;
                    animationgo = false;

                } else if (player.Ready < .5f && Box != null) {

                    Box.knifein = false;
                    rend.enabled = true;

                    move = true;


                }
                break;

        }

       
        //transform.rotation = Quaternion.LookRotation()
    }

    public override void EnterUI(Collider2D Coli) {

        base.EnterUI(Coli);

        if (Coli.GetComponent<BoxUI>() != null) {
            animationgo = true;

            Box = Coli.GetComponent<BoxUI>();
        }
    }
    public override void ExitUI(Collider2D Coli) {
        base.ExitUI(Coli);
        if (Coli.GetComponent<BoxUI>() != null) {

            animationgo = false;

            Box.knifein = false;
            rend.enabled = true;

            move = true;
            Box = null;
        }
    }


}
