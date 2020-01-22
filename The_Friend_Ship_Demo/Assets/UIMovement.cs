using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    public RectTransform trans;
   public KeyitemTrigger Trig;
   public Playergen player;
   public Inventoryslot ISlot;
    float movmag;
    float xmax;
    float xmin;

    public enum playerholding { p1,p2};
    public playerholding hold;

  public  GameObject targetobj;

    Vector3 finalpo;

    public bool bigdecistion;

    bool p1;
    bool p2;

    public bool onbench;


    // Start is called before the first frame update
    void Start()
    {
        startingfunt();
    }
    
    void LateUpdate() 
    {

        Lateupfunt();

    }
    public virtual void startingfunt() {
        trans = GetComponent<RectTransform>();
        player = Trig.PL;
        ISlot = player.invmen.Islots[player.direction];
        ISlot.OBJ = this;
        ISlot.isspawned = true;
        movmag = 20;
        player.playercanvas.sortingOrder = Trig.KI.layer;
       
        switch (player.direction) {
            case 0:
                xmin = Screen.width * .4f;
                xmax = Screen.width;
                hold = playerholding.p1;
                break;
            case 1:
                xmin = 0;
                xmax = Screen.width * .6f;
                hold = playerholding.p2;
                break;

        }
        p1 = false;
        p2 = false;
    }

    public void Assignplayer(Playergen play, KeyitemTrigger Trigg) {
        trans = GetComponent<RectTransform>();

        player = play;
        Trig = Trigg;
        ISlot = play.invmen.Islots[player.direction];
        ISlot.OBJ = this;
       // ISlot.isspawned = true;
        movmag = 20;
       // play.playercanvas.sortingOrder = Trig.KI.layer;

        switch (play.direction) {
            case 0:
                xmin = Screen.width * .4f;
                xmax = Screen.width;
                hold = playerholding.p1;
                break;
            case 1:
                xmin = 0;
                xmax = Screen.width * .6f;
                hold = playerholding.p2;
                break;

        }
       //transform.SetParent(Trig.Itemslide.handleRect);
    }
    public void Newcontroller(Playergen Play) {

    }
    public virtual void Lateupfunt() {
        if (!Trig.isaway) {
            if (ISlot.isslected) {
                //  transform.position = new Vector3(trans.position.x + (player.DirH * movmag), trans.position.y + (player.DirV * movmag));
                transform.position = new Vector3(Mathf.Clamp(trans.position.x, xmin, xmax), Mathf.Clamp(trans.position.y, 0, Screen.height));
                finalpo = new Vector3(trans.position.x + (player.DirH * movmag), trans.position.y + (player.DirV * movmag));
                transform.position = Vector3.Lerp(trans.position, finalpo, .25f);
            } else {
                return;
            }
          

        //} else {
        //    if (!ISlot.ontable) {
        //        transform.localPosition = new Vector3(0f, 0f);

        //    }

        }

        if (bigdecistion) {

            if (Input.GetButtonDown("Submit1")) {
                p1 = true;
              
            }
            if (Input.GetButtonDown("Submit2")) {
                p2 = true;

            }

            if (p1 && p2) {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(trans.position);
                if (Physics.Raycast(ray, out hit)) {
                    //   Debug.Log(hit.collider.gameObject);
                    targetobj = hit.collider.gameObject;
                    Interactui();
                }
                p1 = false;
                p2 = false;
                bigdecistion = false;

            } else {
                targetobj = null;
            }
        } 
        else {


            if (Input.GetButtonDown("Submit" + player.playernum)) {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(trans.position);
                if (Physics.Raycast(ray, out hit)) {
                    //   Debug.Log(hit.collider.gameObject);
                    targetobj = hit.collider.gameObject;
                    Interactui();
                }

            } else {
                targetobj = null;
            }
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bench") {
            ISlot.ontable = true;
        }
        EnterUI(collision);
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bench") {
            ISlot.ontable = false;
        }
        ExitUI(collision);
    }
    public virtual void EnterUI(Collider2D Coli) {

    }
    public virtual void ExitUI(Collider2D Coli) {

    }
    public virtual void Interactui() {

    }
    // Update is called once per frame
   


}
