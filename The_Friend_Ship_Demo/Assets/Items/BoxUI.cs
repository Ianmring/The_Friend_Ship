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
    public Item watch;
   [SerializeField] bool Watchgotten;

   public int knifeshakes;

    int boxshakes;
   public bool shaking;
    bool boxshake;
    bool boxshaking;

   public bool Crushed;
    // Start is called before the first frame update
    public override void startingfunt() {
        base.startingfunt();
        box = GetComponent<Image>();
        colide = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    public override void Lateupfunt() {
        base.Lateupfunt();

        if (knifeshakes > 20) {
            open = true;
            shaking = false;
        } else if (knifeshakes == 0) {
            shaking = false;
        }

        if (!done) {
            if (knifein && !open) {
                currentboxstate = boxstates.Pryed;
            } else if (open && knifein ) {
                currentboxstate = boxstates.Open;
                done = true;
            } else { 
                currentboxstate = boxstates.closed;
            }
        }
        if (!shaking && !boxshaking ) {
            box.sprite = boxstatesimages[(int)currentboxstate];

        }

        if ( open && ISlot.isslected && !Watchgotten) {
            
                anim.AnimButtons[0].SetActive(true);
            if (Keyboard) {
                anim.anima[0].SetTrigger("StartK");

            } else {

                anim.anima[0].SetTrigger("Start");
            }
            if (Input.GetButtonDown("Submit" + player.playernum)) {
                BoxShake();
            }

        } else {
            anim.AnimButtons[0].SetActive(false);

            //  anim.anima[animnum].SetTrigger("Exit");
        }
    }
    public void KnifeShake(bool L , bool R) {
        shaking = true;
        knifeshakes++;
        if (L) {
            box.sprite = boxstatesimages[3];

        } else { 
            box.sprite = boxstatesimages[4];

        }

    }

    public void BoxShake() {
        boxshakes++;
        boxshaking = true;
        if (boxshake) {
            box.sprite = boxstatesimages[5];
            boxshake = false;
        } else {
            box.sprite = boxstatesimages[6];
            boxshake = true;
        }
        if (boxshakes > 20) {
            box.sprite = boxstatesimages[(int)currentboxstate];

            Inventory.instance.AddKey(watch, 1);
            Watchgotten = true;
        }
    }
      
}
