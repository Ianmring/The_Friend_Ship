﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    public TextMeshProUGUI Description;

    public bool bigdecistion;

    bool p1;
    bool p2;

    public bool onbench;

    public testanim anim;

    public GameObject Buttons;

    public bool move;

    public float sidescale;

    public bool interactionItem;

   public bool inverse;

    Vector3 OGscale;
    Vector3 OGButtonScale;

    bool inversegate;

    bool showinginfo;

    // Start is called before the first frame update
    void Start()
    {

      

    }
    
    void LateUpdate() 
    {

        Lateupfunt();

    }
    public virtual void Startfunt() {
        move = true;
        trans = GetComponent<RectTransform>();
        player = Trig.PL;
        ISlot = player.invmen.Islots[player.direction];
        ISlot.OBJ = this;
        ISlot.isspawned = true;
        movmag = 20;
        player.playercanvas.sortingOrder = Mathf.RoundToInt(Trig.KI.layer.x);
        anim = GetComponentInChildren<testanim>();
        Buttons = anim.gameObject;
        OGscale = transform.localScale;
        OGButtonScale = Buttons.transform.localScale;
        switch (player.direction) {
            case 0:
                xmin = Screen.width * .4f;
                xmax = Screen.width;
                hold = playerholding.p1;
                if (inverse && transform.localScale.x < 0) {
                    this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
                    Buttons.transform.localScale = new Vector3(Buttons.transform.localScale.x * -1, Buttons.transform.localScale.y);
                }
                Buttons.transform.localPosition = new Vector3(-sidescale, 0);

                break;
            case 1:
                xmin = 0;
                xmax = Screen.width * .6f;
                hold = playerholding.p2;

                if (inverse ) {
                    this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
                    Buttons.transform.localScale = new Vector3(Buttons.transform.localScale.x * -1, Buttons.transform.localScale.y);
                }
                Buttons.transform.localPosition = new Vector3(sidescale, 0);
                break;

        }
        p1 = false;
        p2 = false;
        showinginfo = false;
        StartCoroutine("RSstickturn");

        startingfunt();

    }
    public virtual void startingfunt() {
       
    }

    public void Assignplayer(Playergen play, KeyitemTrigger Trigg) {


        trans = GetComponent<RectTransform>();

        player = play;
        Trig = Trigg;
        ISlot = play.invmen.Islots[player.direction];
        ISlot.OBJ = this;
       // ISlot.isspawned = true;
        movmag = 20;
        //Debug.Log("new sorting layer: " + play.playercanvas.sortingOrder);
        // Debug.Log("new player: " + Trigg.PL.direction);


        switch (play.direction) {
            case 0:
                xmin = Screen.width * .4f;
                xmax = Screen.width;
                hold = playerholding.p1;
                if (inverse && transform.localScale.x < 0) {
                    this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
                    Buttons.transform.localScale = new Vector3(Buttons.transform.localScale.x * -1, Buttons.transform.localScale.y);
                }
                Buttons.transform.localPosition = new Vector3(sidescale, 0);
                inversegate = false;

                break;
            case 1:
                xmin = 0;
                xmax = Screen.width * .6f;
                hold = playerholding.p2;
                if (inverse && transform.localScale.x > 0 ) {
                    this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
                    Buttons.transform.localScale = new Vector3(Buttons.transform.localScale.x * -1, Buttons.transform.localScale.y);
                }
                Buttons.transform.localPosition = new Vector3(-sidescale, 0);
                break;

        }
        if (this.gameObject.activeSelf) {
            StartCoroutine("RSstickturn");

        }
        //transform.SetParent(Trig.Itemslide.handleRect);
    }
    public void Newcontroller(Playergen Play) {

    }
    public virtual void Lateupfunt() {
        if (!Trig.isaway && move) {
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
        if (Input.GetButtonDown("Handoff" + player.playernum)) {
            showinginfo = true;
        }else if(Input.GetButtonUp("Handoff" + player.playernum)) {
            showinginfo = false;
        }

        if (ISlot.isslected && ISlot.isspawned && showinginfo) {
            anim.AnimButtons[10].SetActive(true);
        } else {
            anim.AnimButtons[10].SetActive(false);

        }
        if (bigdecistion) {

            if (Input.GetButtonDown("Submit1")) {
                p1 = true;
              
            }
            if (Input.GetButtonDown("Submit2")) {
                p2 = true;

            }

            if (p1 && p2 && interactionItem) {

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


            if (Input.GetButtonDown("Submit" + player.playernum) ) {

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
    public virtual void StayUI(Collider2D Coli) {

    }
    public virtual void Interactui() {

    }
    private void OnTriggerStay2D(Collider2D collision) {


       
        StayUI(collision);
    }
    // Update is called once per frame

    IEnumerator RSstickturn() {
        yield return new WaitForSeconds(.1f);
        
        anim.anima[8].gameObject.SetActive(true);
        anim.anima[8].SetTrigger("Round");
        yield return new WaitForSeconds(3);
        anim.anima[8].SetTrigger("Done");
        anim.anima[8].gameObject.SetActive(false);

    }

}