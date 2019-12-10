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

   public List<Inventoryslot> Keyslots  = new List<Inventoryslot>();

    public Transform[] selector;

    public GameObject inventoryUI;

    public int[] itemselected;

    public Item[] currentactiveitem;

    Vector3 unequp;

    // Start is called before the first frame update
    void Start()
    {
    
        itemselected = new int[2];
        currentactiveitem = new Item[2];
        itemselected[0] = -1;
        itemselected[1] = -1;
        unequp = selector[0].transform.position;

     

        inventoryUI.SetActive(false);
        inventory = Inventory.instance;


        inventory.onkeyitemchangedcallback += AddUIKey;

        inventory.onKeyitemSamecallback += UpdateSlotKey;



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
            //if (itemselected[0] == 0 && itemselected[1] == -1) {
            //    itemselected[0] = 0;
            //}
            //else if (itemselected[1] == 0 && itemselected[0] == -1) {
            //    itemselected[1] = 0;
            //} else {
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
        if (itemselected[playernum] < 0) {
            currentactiveitem[playernum] = null;
        } else {
            currentactiveitem[playernum] = Keyslots[itemselected[playernum]].item;

        }
    }

    public void AddUIKey(Item item, int count)
    {
        GameObject Keyslot;
        Keyslot = Instantiate(slot, keyitemparent);
        //Keyslots = keyitemparent.GetComponentsInChildren<Inventoryslot>();
        Keyslot.GetComponent<Inventoryslot>().itemcount += count;

        Keyslots.Add(Keyslot.GetComponent<Inventoryslot>());

        Keyslots[Keyslots.Count - 1].Addtiem(item);
       // uimanager.UIinstance.Triggerupdate();

       
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
