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

    public bool knifein;
    // Start is called before the first frame update
    public override void startingfunt() {
        base.startingfunt();
        box = GetComponent<Image>();
        colide = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    public override void Lateupfunt() {
        base.Lateupfunt();
        if (knifein && currentboxstate != boxstates.Open) {
            currentboxstate = boxstates.Pryed;
        } else if (!knifein && currentboxstate != boxstates.Open) {
            currentboxstate = boxstates.closed;

        }

        box.sprite = boxstatesimages[(int)currentboxstate];
    }
}
