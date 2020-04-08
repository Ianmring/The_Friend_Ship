using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void equipitem(int playernum) {

        switch (playernum) {
            case 0:
                if (GenInv[0].player.iskeyboard) {
                    selector[playernum].GetComponentInChildren<testanim>().anima[0].SetTrigger("StartK");
                    selector[playernum].GetComponentInChildren<testanim>().anima[1].SetTrigger("StartK");
                } else {
                    selector[playernum].GetComponentInChildren<testanim>().anima[0].SetTrigger("Start");
                    selector[playernum].GetComponentInChildren<testanim>().anima[1].SetTrigger("Start");
                }
                break;
            case 1:
                if (GenInv[1].player.iskeyboard) {
                    selector[playernum].GetComponentInChildren<testanim>().anima[0].SetTrigger("StartK");
                    selector[playernum].GetComponentInChildren<testanim>().anima[1].SetTrigger("StartK");
                } else {
                    selector[playernum].GetComponentInChildren<testanim>().anima[0].SetTrigger("Start");
                    selector[playernum].GetComponentInChildren<testanim>().anima[1].SetTrigger("Start");
                }
                break;
            default:
                break;
        }
       

        if (Keyslots.Count >1) {
            if (itemselected[playernum] < 0) {
                if (Islots[playernum] != null) {
                    Islots[playernum].isslected = false;
                    Islots[playernum].UpdateSlot();
                }
                //uimanager.UIinstance.OBJSelector[playernum].gameObject.SetActive(true);



            } else {

            
              

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
