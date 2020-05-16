using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryMenu : MonoBehaviour
{
    #region Singelton
    public static InventoryMenu invmeninstance;

    private void Awake() {
       invmeninstance = this;
    }

    #endregion
    public Transform keyitemparent;
   
    Inventory inventory;

    public GameObject slot;

    public GameObject interactionarea;

   public List<Inventoryslot> Keyslots  = new List<Inventoryslot>();

    [SerializeField]
    Animator[] ltrt;

    [SerializeField]
    Animator AButt;

    public Transform[] selector;

    public GameObject inventoryUI;

    public int[] itemselected;

    public Item[] currentactiveitem;

    public Inventoryslot[] Islots;

    public inventorygeneral[] GenInv;
    [SerializeField]
    List<Animator> p1anim;
    [SerializeField]
    List<Animator> p2anim;

    Vector3 unequp;

    GameObject objecttodestory;

    [SerializeField]
   public  bool interactionareamovep1;
    [SerializeField]
  public  bool interactionareamovep2;

    [SerializeField]
    Slider slide;

    int itemslot;
    // Start is called before the first frame update
    void Start()
    {
    
        itemselected = new int[2];
        currentactiveitem = new Item[2];
        Islots = new Inventoryslot[2];
        GenInv = new inventorygeneral[2];
        itemselected[0] = -1;
        itemselected[1] = -1;
        unequp = selector[0].transform.position;

       

        inventoryUI.SetActive(false);
        inventory = Inventory.instance;



        inventory.onkeyitemchangedcallback += AddUIKey;

        inventory.onKeyitemSamecallback += UpdateSlotKey;
        foreach (var item1 in selector[0].GetComponentInChildren<testanim>().anima) {
            p1anim.Add(item1);
        }
        foreach (var item2 in selector[1].GetComponentInChildren<testanim>().anima) {
            p2anim.Add(item2);
        }
    }


    public void StoptAnim(int playernum) {

        if (playernum == 0) {
            foreach (var item in p1anim) {
                item.SetTrigger("Exit");
            }
        } else {
            foreach (var item in p2anim) {
                item.SetTrigger("Exit");
            }
        }

    }


    public void Itemup(int playernum) {

        if (Keyslots.Count > 1) {

            if (itemselected[0] == Keyslots.Count - 2 && itemselected[1] == Keyslots.Count - 1) {
                itemselected[0] = Keyslots.Count - 2;
            } else if (itemselected[1] == Keyslots.Count - 2 && itemselected[0] == Keyslots.Count - 1) {
                itemselected[1] = Keyslots.Count - 2;
            } else {
                selector[playernum].gameObject.SetActive(true);
                itemselected[playernum]++;
                if (itemselected[0] == itemselected[1]) {
                    itemselected[playernum]++;
                }
                if (itemselected[playernum] > Keyslots.Count - 1) {
                    itemselected[playernum] = Keyslots.Count - 1;
                }

                selector[playernum].transform.position = Keyslots[itemselected[playernum]].transform.position;
              

            }


        }
        
    }
    public void ItemDown(int playernum) {
        if (Keyslots.Count > 1) {

                selector[playernum].gameObject.SetActive(true);

                itemselected[playernum]--;
                if (itemselected[0] == itemselected[1]) {
                    itemselected[playernum]--;
                }



                if (itemselected[playernum] < -1) {
                    itemselected[playernum] = -1;
                selector[playernum].transform.position = unequp;

            }

                if (itemselected[playernum] < 0) {
                selector[playernum].transform.position = unequp;
                } else {

                selector[playernum].transform.position = Keyslots[itemselected[playernum]].transform.position;
               
            }
           // }


           
        }
    }
    public void LateUpdate() {


        if (!movement.MovInstance.Solo) {


            if (interactionareamovep1 && uimanager.UIinstance.playersready[0]) {
                ltrt[0].gameObject.SetActive(true);

                if (GenInv[0].player.iskeyboard) {
                    ltrt[0].SetTrigger("StartK");

                } else {
                    ltrt[0].SetTrigger("Start" + GenInv[0].player.Controller);
                }
                if (GenInv[0].player.Ready > 0.1f) {
                    slide.value = GenInv[0].player.Ready;

                } else if (!interactionareamovep2) {
                    slide.value = 0;
                }


            } else {
                ltrt[0].gameObject.SetActive(false);
            }

            if (interactionareamovep2 && uimanager.UIinstance.playersready[1]) {
                ltrt[1].gameObject.SetActive(true);

                if (GenInv[1].player.iskeyboard) {
                    ltrt[1].SetTrigger("StartK");

                } else {
                    ltrt[1].SetTrigger("Start" + GenInv[1].player.Controller);
                }

                if (GenInv[1].player.IReady > 0.1f) {
                    slide.value = (GenInv[1].player.IReady) * -1;

                } else if (!interactionareamovep1) {
                    slide.value = 0;
                }

            } else {
                ltrt[1].gameObject.SetActive(false);

            }


        } else {


            switch (movement.MovInstance.steer) {
                case movement.PlayerSteering.P1:
                    if (interactionareamovep1) {
                        if (movement.MovInstance.keyboard) {
                            AButt.gameObject.SetActive(true);
                            AButt.SetTrigger("StartK");

                            if (Input.GetButtonDown(movement.MovInstance.controllerL + "Submit2")) {
                                interactionarea.SetActive(!interactionarea.activeSelf);
                            }

                        } else {
                            AButt.gameObject.SetActive(true);
                            AButt.SetTrigger("Start" + GenInv[0].player.Controller);
                            if (Input.GetButtonDown(movement.MovInstance.controllerL + "Submit1")) {
                                interactionarea.SetActive(!interactionarea.activeSelf);
                            }
                        }
                       
                    } else {
                        AButt.SetTrigger("Exit");
                        AButt.gameObject.SetActive(false);

                    }
                    break;
                case movement.PlayerSteering.P2:
                    if (interactionareamovep2) {
                        if (movement.MovInstance.keyboard) {
                            AButt.gameObject.SetActive(true);
                            AButt.SetTrigger("StartK");
                            if (Input.GetButtonDown(movement.MovInstance.controllerL + "Submit2")) {
                                interactionarea.SetActive(!interactionarea.activeSelf);
                            }

                        }
                        else {
                            AButt.gameObject.SetActive(true);
                            AButt.SetTrigger("Start" + GenInv[0].player.Controller);
                            if (Input.GetButtonDown(movement.MovInstance.controllerL + "Submit1")) {
                                interactionarea.SetActive(!interactionarea.activeSelf);
                            }

                        }
                      

                    } else {
                        AButt.SetTrigger("Exit");
                        AButt.gameObject.SetActive(false);

                    }
                    break;
               
            }
           
        }
    }
    public void equipitem(int playernum) {

        if (movement.MovInstance.Solo) {
            if (GenInv[0].player.iskeyboard && GenInv[1].player.iskeyboard) {
                selector[0].GetComponentInChildren<testanim>().anima[0].SetTrigger("StartK");
                selector[0].GetComponentInChildren<testanim>().anima[1].SetTrigger("StartK");
                selector[1].GetComponentInChildren<testanim>().anima[0].SetTrigger("StartK");
                selector[1].GetComponentInChildren<testanim>().anima[1].SetTrigger("StartK");
            } else {
                selector[0].GetComponentInChildren<testanim>().anima[0].SetTrigger("Start" + GenInv[0].player.Controller);
                selector[0].GetComponentInChildren<testanim>().anima[1].SetTrigger("Start" + GenInv[0].player.Controller);
                selector[1].GetComponentInChildren<testanim>().anima[0].SetTrigger("Start" + GenInv[0].player.Controller);
                selector[1].GetComponentInChildren<testanim>().anima[1].SetTrigger("Start" + GenInv[0].player.Controller);
            }


        } else {
            switch (playernum) {
                case 0:
                    if (GenInv[0].player.iskeyboard) {
                        selector[playernum].GetComponentInChildren<testanim>().anima[0].SetTrigger("StartK");
                        selector[playernum].GetComponentInChildren<testanim>().anima[1].SetTrigger("StartK");
                    } else {
                        selector[playernum].GetComponentInChildren<testanim>().anima[0].SetTrigger("Start" + GenInv[0].player.Controller);
                        selector[playernum].GetComponentInChildren<testanim>().anima[1].SetTrigger("Start" + GenInv[0].player.Controller);
                    }
                    break;
                case 1:
                    if (GenInv[1].player.iskeyboard) {
                        selector[playernum].GetComponentInChildren<testanim>().anima[0].SetTrigger("StartK");
                        selector[playernum].GetComponentInChildren<testanim>().anima[1].SetTrigger("StartK");
                    } else {
                        selector[playernum].GetComponentInChildren<testanim>().anima[0].SetTrigger("Start" + GenInv[0].player.Controller);
                        selector[playernum].GetComponentInChildren<testanim>().anima[1].SetTrigger("Start" + GenInv[0].player.Controller);
                    }
                    break;
                default:
                    break;
            }
        }

        if (Keyslots.Count >1) {
            if (itemselected[playernum] < 0) {
                if (Islots[playernum] != null) {

                   
                    Islots[playernum].isslected = false;
                    Islots[playernum].UpdateSlot();
                }
               

                    switch (playernum) {
                        case 0:
                            interactionareamovep1 = true;

                            break;
                        case 1:
                            interactionareamovep2 = true;
                            break;
                    }
               

                if (uimanager.UIinstance.playersready[playernum] == false) {
                  
                        switch (playernum) {
                            case 0:
                                interactionareamovep1 = false;

                                break;
                            case 1:
                                interactionareamovep2 = false;
                                break;
                        }
                    
                }
                //uimanager.UIinstance.OBJSelector[playernum].gameObject.SetActive(true);



            } else {

                switch (playernum) {
                    case 0:
                        interactionareamovep1 = false;

                        break;
                    case 1:
                        interactionareamovep2 = false;
                        break;
                }


                if (Islots[playernum] != null && Islots[playernum].isspawned ) {
                    if ( Islots[playernum].itemplace == itemselected[playernum] ) {
                        Islots[playernum].isslected = true;
                        Islots[playernum].UpdateSlot();
                    //    Islots[playernum].ReassignSlot(GenInv[playernum].player, GenInv[playernum].TriggerItem);


                    } else {
                        Islots[playernum].isslected = false;
                        Islots[playernum].UpdateSlot();                        
                        Islots[playernum].ReassignSlot(GenInv[playernum].player, GenInv[playernum].TriggerItem);

                    }


                }


                currentactiveitem[playernum] = Keyslots[itemselected[playernum]].item;
                Islots[playernum] = Keyslots[itemselected[playernum]];

               

                if (Islots[playernum] != null && Islots[playernum].isspawned) {
                    Islots[playernum].isslected = true;
                    
                    Islots[playernum].UpdateSlot();
                    Islots[playernum].ReassignSlot(GenInv[playernum].player, GenInv[playernum].TriggerItem);

                    switch (playernum) {
                        case 0:
                            GenInv[0].player.playercanvas.sortingOrder = Mathf.RoundToInt(currentactiveitem[0].layer.x);
                            if (currentactiveitem[1] != null && !currentactiveitem[1].keeplayer) {
                                GenInv[1].player.playercanvas.sortingOrder = Mathf.RoundToInt(currentactiveitem[0].layer.y);

                            }
                            break;
                        case 1:                            
                            GenInv[1].player.playercanvas.sortingOrder = Mathf.RoundToInt(currentactiveitem[1].layer.x);
                            if (currentactiveitem[0] != null && !currentactiveitem[0].keeplayer ) {
                                GenInv[0].player.playercanvas.sortingOrder = Mathf.RoundToInt(currentactiveitem[1].layer.y);

                            }
                            break;
                        
                    }
                 
                } else {
                    GenInv[playernum].AddKey(currentactiveitem[playernum], false);

                }
            }
        }
        
    }

    public void AddUIKey(Item item, int count)
    {
        GameObject KeyslotI;
        KeyslotI = Instantiate(slot, keyitemparent);
        //Keyslots = keyitemparent.GetComponentsInChildren<Inventoryslot>();
        KeyslotI.GetComponent<Inventoryslot>().itemcount += count;

        Keyslots.Add(KeyslotI.GetComponent<Inventoryslot>());

        Keyslots[Keyslots.Count - 1].Addtiem(item);
        // uimanager.UIinstance.Triggerupdate();
        if (Keyslots.Count > 0) {
            for (int i = 0; i < Keyslots.Count; i++) {
                Keyslots[i].itemplace = itemslot;
                itemslot++;

            }
        }
        itemslot = 0;


    }
    public void RemoveUIKey(int Playernum) {

        int itemnum;
        
        itemnum = itemselected[Playernum];
        objecttodestory = Keyslots[itemnum].gameObject;
        Keyslots.RemoveAt(itemnum);
        Destroy(objecttodestory);
        objecttodestory = null;
        
    }
    public void Resetitemselected() {
        itemselected[0] = 0;
        ItemDown(0);
        itemselected[1] = 0;
        ItemDown(1);
       
        equipitem(0);
        equipitem(1);

        foreach (var item in Keyslots) {

            if (item.OBJ != null) {
                item.isslected = false;
                item.UpdateSlot();
            }
            
        }
        Islots[0] = null;
        currentactiveitem[0] = null;
        Islots[1] = null;
        currentactiveitem[1] = null;
    

    }

    void UpdateSlotKey(Item item, int count)
    {
        foreach (var Item in Keyslots)
        {
            if (Item.itemname == item.name)
            {
                Item.itemcount += count;
              //  uimanager.UIinstance.Triggerupdate();

            }
        }
    }
}
