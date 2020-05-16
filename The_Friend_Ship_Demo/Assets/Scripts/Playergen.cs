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
    public string Controller;
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
    public float MovH;
    public float MovV;

    public Canvas playercanvas;
    public GameObject curssor;

    public bool iskeyboard;
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

        if (iskeyboard) {
            Mov.keyboard = true;
        }
        invmen.GenInv[direction] = invent;
      //  UIMana.OBJSelector[direction].PointAssignplayer(this, triggeritem);

        selecting = true;

    }


    // Update is called once per frame
    void Update() {


      

           


            if (Input.GetButtonDown(Controller + "MenuUP" + playernum.ToString()) && UIMana.itemcan) {
            //UIMana.toggleinvet();

            if (movement.MovInstance.Solo) {
                UIMana.playersready[0] = !UIMana.playersready[0];
                UIMana.playersready[1] = !UIMana.playersready[1];
                InventoryMenu.invmeninstance.interactionareamovep1 = true;
                InventoryMenu.invmeninstance.interactionareamovep2 = true;


            } else {
                UIMana.playersready[direction] = !UIMana.playersready[direction];

            }
            if (UIMana.playersready[direction]) {
                    Audiomana.Audioinstance.Play("ZipOpen");

                } else {
                    Audiomana.Audioinstance.Play("ZipClose");

                }
                UIMana.toggleinvet();
                invmen.equipitem(direction);

                Debug.Log("UP");


            }
            if (Input.GetButtonDown(Controller + "Exit" + playernum.ToString()) && !DiolaugeManager.DioInstance.indio) {
                UIMana.PauseMenu();
            }
       
            if (UIMana.menuisopen && isselectingitem) {
                if ((Itemselect > .1 && selecting) || Input.GetButtonDown(Controller + "ItemRB" + playernum.ToString())) {
                    Audiomana.Audioinstance.Play("Rum");
                    invmen.Itemup(direction);
                    if (invmen.itemselected[direction] >= 0) {
                        invmen.equipitem(direction);

                        // invent.AddKey(invmen.currentactiveitem[direction], false);
                    } else {
                        invmen.equipitem(direction);
                        //     invent.AddKey(null, false);

                    }

                    selecting = false;
                } else if ((Itemselect < -.1 && selecting) || Input.GetButtonDown(Controller + "ItemLB" + playernum.ToString())) {
                    Audiomana.Audioinstance.Play("Rum");
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
    
    private void FixedUpdate() {

        
        Mov.directions[direction] = Input.GetAxis(Controller + "Vertical_P" + playernum.ToString());
        Mov.directionsx[direction] = Input.GetAxis(Controller + "Horizontal_P" + playernum.ToString());
        Mov.Turnx[direction] = Input.GetAxis(Controller + "Horizontal_P" + playernum.ToString() + "_Turn");
        Itemselect = Input.GetAxis(Controller + "ItemScrool" + playernum.ToString());
        DirH = Input.GetAxis(Controller + "Horizontal_P" + playernum.ToString() + "_Launch");
        DirV = Input.GetAxis(Controller + "Vertical_P" + playernum.ToString() + "_Launch");
        MovH = Mov.directionsx[direction];
        MovV = Mov.directions[direction];
        Ready = Input.GetAxis(Controller + "Player_" + playernum.ToString() + "_Aim");
        IReady = Input.GetAxis(Controller + "Player_" + playernum.ToString() + "_Key");
        Mov.DirxM[direction] = DirH;
        Mov.DiryM[direction] = DirV;
        
    }









}

