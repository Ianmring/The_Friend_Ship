using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class inventorygeneral : MonoBehaviour
{
    public int INVNUM;

    Playergen player;

    public int currentitem;

    public int slotnums_P;
    public GameObject currentslot;
   // public List<PersonalItemSlot> Personal_Slots = new List<PersonalItemSlot>();
    public Item Keyitem;
  // public List<Item> items = new List<Item>();
  //  public Transform Container;
    public Transform KIContainer;

    //public Transform Selector;


    public bool isyourturn;

    public KeyitemTrigger TriggerItem;

    GameObject currentitemobj;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Playergen>();
        INVNUM = player.direction;

        if (INVNUM == 0) {
            movement.MovInstance.p1I = this;
        } else {
            movement.MovInstance.p2I = this;

        }
        //  Container = GameObject.Find("D" + player.direction + "_Inv").GetComponent<Transform>();
        KIContainer = GameObject.Find("KeyItem" + player.direction).GetComponent<Transform>();
        TriggerItem = GameObject.Find("KeyItem" + player.direction).GetComponent<KeyitemTrigger>();
      //  Selector = GameObject.Find("SelectedD" + player.direction).GetComponent<Transform>();
        currentitem = 0;
        player.triggeritem = TriggerItem;
        //Update_Slots();
    }

    // Update is called once per frame


   

    public void AddKey(Item Kitem, bool isitem)
    {
         

        if (Kitem == Keyitem)
        {
            return;
        }
        else
        {
            if (Kitem == null) {
                Destroy(currentitemobj);
                currentitemobj = null;
                Keyitem = null;
                TriggerItem.Additem(null, player, isitem);

                return;
            } else {



                Destroy(currentitemobj);
                currentitemobj = null;
                GameObject PSlot;
                PersonalItemSlot slot;
                PSlot = Instantiate(currentslot, KIContainer);
                slot = PSlot.GetComponent<PersonalItemSlot>();

                slot.Additem(Kitem, isitem);
                Keyitem = Kitem;

                slot.Playernum = player.direction;
                slot.invt = this;


                //  slot.isitem = isitem;
                //TriggerItem.ClearItem();
               // Destroy(TriggerItem.currentobj);                 
                
                TriggerItem.Additem(slot, player, isitem);
                currentitemobj = PSlot;
            
            }
        }
    }


  


}
