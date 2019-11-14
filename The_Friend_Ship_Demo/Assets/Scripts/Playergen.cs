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
    InventoryMenu invmen;

  public  KeyitemTrigger triggeritem;

    public float Itemselect;

   public bool selecting;

    bool isselectingitem;
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
                UIMana.P1 = this.gameObject;
                break;

            case 1:
             //  playerrend.material = Mats[direction];
                UIMana.P2 = this.gameObject;
                break;


            default:
                break;
        }
        selecting = true;

    }


    // Update is called once per frame
    void Update() {


        Mov.directions[direction] = Input.GetAxis("Vertical_P" + playernum.ToString());
        Mov.directionsx[direction] = Input.GetAxis("Horizontal_P" + playernum.ToString());
        Mov.Turnx[direction] = Input.GetAxis("Horizontal_P" + playernum.ToString() + "_Turn");
        Itemselect = Input.GetAxis("ItemScrool" + playernum.ToString());


        if (UIMana.menuisopen && isselectingitem) {
            if (Itemselect > .1 && selecting) {
                InventoryMenu.invmeninstance.Itemup(direction);
                selecting = false;
            } else if (Itemselect < -.1 && selecting) {
                InventoryMenu.invmeninstance.ItemDown(direction);
                selecting = false;

            } else if (Itemselect == 0) {
                selecting = true;

            }
        }







            if (Input.GetButtonUp("Handoff" + playernum.ToString())) {
                Debug.Log("move");
                movement.MovInstance.Switchplayerpos();
            }

            if (Input.GetButtonDown("MenuUP" + playernum.ToString()) && invmen.Keyslots.Count > 1) {
                UIMana.playersready[direction] = true;
                isselectingitem = true;
            Debug.Log("DOWN");

        }
        if (Input.GetButtonUp("MenuUP" + playernum.ToString())) {
                //   Debug.Log("UP2");

                if (invmen.itemselected[direction] >= 0) {
                    invmen.equipitem(direction);
                    invent.AddKey(invmen.currentactiveitem[direction], false);
                } else {
                    invmen.equipitem(direction);
                    invent.AddKey(null, false);

                }
                UIMana.playersready[direction] = false;
                isselectingitem = false;
            Debug.Log("UP");


        }
        if (Input.GetButton("Exit" + playernum.ToString())) {
            Debug.Log("Quit");
            Application.Quit();


        }
    }
    



      
    
        
    
      
    }

