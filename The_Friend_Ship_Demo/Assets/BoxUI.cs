using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxUI : UIMovement
{

    public enum boxstates { closed, Pryed, Open}
    public boxstates currentboxstate;
    public Image box;
    public Sprite[] boxstatesimages;
    CircleCollider2D colide;
    public bool open;
    public bool knifein;
  public  bool done;

    bool Watchgotten;
    // Start is called before the first frame update
    public override void startingfunt() {
        base.startingfunt();
        box = GetComponent<Image>();
        colide = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    public override void Lateupfunt() {
        base.Lateupfunt();

        if (!done) {
            if (knifein && !open) {
                currentboxstate = boxstates.Pryed;
            } else if (open && knifein) {
                currentboxstate = boxstates.Open;
                done = true;
            } else {
                currentboxstate = boxstates.closed;
            }
        }
        box.sprite = boxstatesimages[(int)currentboxstate];

        if ( open && ISlot.isslected && !Watchgotten) {
            
                anim.AnimButtons[0].SetActive(true);
                anim.anima[0].SetTrigger("Start");
            if (Input.GetButtonDown("Submit" + player.playernum)) {
                Debug.Log("Watch");
                Watchgotten = true;
            }

        } else {
            anim.AnimButtons[0].SetActive(false);

            //  anim.anima[animnum].SetTrigger("Exit");
        }
    }
}
