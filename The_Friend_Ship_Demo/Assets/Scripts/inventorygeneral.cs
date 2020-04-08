using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class inventorygeneral : MonoBehaviour
{
    public int INVNUM;

    public Playergen player;

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


    GameObject PSlot;
    PersonalItemSlot slot;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Playergen>();
        INVNUM = player.direction;

        if (INVNUM == 0) {
            movement.MovInstance.p1I = this;
            movement.MovInstance.P1G = player;
          //  movement.MovInstance.SwapPlayers();
        } else {
            movement.MovInstance.p2I = this;
            movement.MovInstance.P2G = player;
         //   movement.MovInstance.SwapPlayers();

        }
        //  Container = GameObject.Find("D" + player.direction + "_Inv").GetComponent<Transform>();
        KIContainer = GameObject.Find("KeyItem" + player.direction).GetComponent<Transform>();
        TriggerItem = GameObject.Find("KeyItem" + player.direction).GetComponent<KeyitemTrigger>();
      //  Selector = GameObject.Find("SelectedD" + player.direction).GetComponent<Transform>();
        currentitem = 0;
        player.triggeritem = TriggerItem;
        TriggerItem.PL = player;
        //Update_Slots();

        //uimanager.UIinstance.OBJSelector[player.direction].PointAssignplayer(player, TriggerItem);

        PSlot = Instantiate(currentslot, KIContainer);
        slot = PSlot.GetComponent<PersonalItemSlot>();
        slot.invt = this;
        slot.Playernum = player.direction;

       
    }

    // Update is called once per frame




    public void AddKey(Item Kitem, bool isitem)
    {
         

        
            if (Kitem == null) {
        
                Keyitem = null;
                slot.Additem(null, isitem);
                TriggerItem.Additem(null, player, isitem);

                return;
            } else {

                slot.Additem(Kitem, isitem);
                Keyitem = Kitem;         
                
                TriggerItem.Additem(slot, player, isitem);
              //  currentitemobj = PSlot;
            
            }
        
    }


  


}
