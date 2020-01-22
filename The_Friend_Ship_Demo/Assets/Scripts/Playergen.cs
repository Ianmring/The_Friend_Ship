using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Playergen : MonoBehaviour
{

    playerselect playa;
    movement Mov;
   public Button butt;

    // public int PLAYER;

    public int direction;
    public int playernum;

   // public Material[] Mats;

    public Renderer playerrend;

    int newplayernum;

    public bool isdemo;

   public uimanager UIMana;

    inventorygeneral invent;
    public InventoryMenu invmen;

  public  KeyitemTrigger triggeritem;

    public float Itemselect;

   public bool selecting;

  public  bool isselectingitem;


    public float Ready;
    public float IReady;
    public float DirH;
    public float DirV;

    public Canvas playercanvas;
    public GameObject curssor;
    // Start is called before the first frame update
    void Start()
    {
        invent = GetComponent<inventorygeneral>();
        invmen = FindObjectOfType<InventoryMenu>();
        UIMana = FindObjectOfType<uimanager>();
        playa = FindObjectOfType<playerselect>();
        Mov = GetComponentInParent<movement>();
        // playerrend = GetComponent<Renderer>();
        switch (direction)
        {
            case 0:
              //  playerrend.material = Mats[direction];
                playercanvas = UIMana.p1;
                curssor = UIMana.P1curss;
                UIMana.oneplayer = this;
                break;

            case 1:
             //  playerrend.material = Mats[direction];
                playercanvas = UIMana.p2;
           //     UIMana.OBJSelector[direction].PointAssignplayer(this, triggeritem);
                curssor = UIMana.P2curss;
                UIMana.twoplayer = this;
                break;


            default:
              

                break;
        }
        invmen.GenInv[direction] = invent;
        UIMana.OBJSelector[direction].PointAssignplayer(this, triggeritem);

        selecting = true;

    }


    // Update is called once per frame
    void Update() {




        if (Input.GetButtonUp("Handoff" + playernum.ToString())) {
                Debug.Log("move");
                movement.MovInstance.Switchplayerpos();
            }

        if (Input.GetButtonUp("MenuUP" + playernum.ToString())) {
            UIMana.playersready[direction] = !UIMana.playersready[direction];
            UIMana.toggleinvet();                    
            Debug.Log("UP");


        }
        if (Input.GetButtonUp("Exit" + playernum.ToString()) && !DiolaugeManager.DioInstance.indio) {
            UIMana.PauseMenu();
        }
    }
    
    private void FixedUpdate() {

        Mov.directions[direction] = Input.GetAxis("Vertical_P" + playernum.ToString());
        Mov.directionsx[direction] = Input.GetAxis("Horizontal_P" + playernum.ToString());
        Mov.Turnx[direction] = Input.GetAxis("Horizontal_P" + playernum.ToString() + "_Turn");
        Itemselect = Input.GetAxis("ItemScrool" + playernum.ToString());
        DirH = Input.GetAxis("Horizontal_P" + playernum.ToString() + "_Launch");
        DirV = Input.GetAxis("Vertical_P" + playernum.ToString() + "_Launch");
        Ready = Input.GetAxis("Player_" + playernum.ToString() + "_Aim");
        IReady = Input.GetAxis("Player_" + playernum.ToString() + "_Key");

        if (UIMana.menuisopen && isselectingitem) {
            if (Itemselect > .1 && selecting) {
               invmen.Itemup(direction);
                if (invmen.itemselected[direction] >= 0) {
                    invmen.equipitem(direction);
                   // invent.AddKey(invmen.currentactiveitem[direction], false);
                } else {
                    invmen.equipitem(direction);
               //     invent.AddKey(null, false);

                }
                selecting = false;
            } else if (Itemselect < -.1 && selecting) {
              invmen.ItemDown(direction);
                if (invmen.itemselected[direction] >= 0) {
                    invmen.equipitem(direction);
                  //  invent.AddKey(invmen.currentactiveitem[direction],  false);
                } else {
                    invmen.equipitem(direction);
                 //   invent.AddKey(null, false);

                }
                selecting = false;

            } else if (Itemselect == 0) {
                selecting = true;

            }
        }
    }









}

