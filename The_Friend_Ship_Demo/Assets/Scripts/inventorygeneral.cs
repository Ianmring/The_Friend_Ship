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

  public  MainLauncher launch { get; set; }

    public launcher GLauncher { get; set; }
    public bool isyourturn;

    public KeyitemTrigger TriggerItem;

    GameObject currentitemobj;
    // Start is called before the first frame update
    void Start()
    {
        launch = FindObjectOfType<MainLauncher>();
        GLauncher = GetComponent<launcher>();
        player = GetComponent<Playergen>();
        INVNUM = player.direction;
      //  Container = GameObject.Find("D" + player.direction + "_Inv").GetComponent<Transform>();
        KIContainer = GameObject.Find("KeyItem" + player.direction).GetComponent<Transform>();
        TriggerItem = GameObject.Find("KeyItem" + player.direction).GetComponent<KeyitemTrigger>();
      //  Selector = GameObject.Find("SelectedD" + player.direction).GetComponent<Transform>();
        currentitem = 0;
        player.triggeritem = TriggerItem;
        //Update_Slots();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Personal_Slots.Count<= 0)
        //{
        //    currentitem = 0;

        //    return;
        //}
        //else
        //{
        //            if (currentitem > Personal_Slots.Count-1 )
        //    {
        //        currentitem = Personal_Slots.Count-1;
        //    }
        //    else if (currentitem < 0)
        //    {
        //        currentitem = 0;
        //    }

        //    Selector.transform.position = Personal_Slots[currentitem].transform.position;
            
        //}


        //if (Input.GetButtonUp("AddtoPslot"))
        //{
        //    FindObjectOfType<uimanager>().Triggerupdate();

        //}
    }

   

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
                TriggerItem.Additem(null, GLauncher, isitem);
                TriggerItem.Rend.Clear();

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
                
                TriggerItem.Additem(slot, GLauncher, isitem);
                currentitemobj = PSlot;
                TriggerItem.Rend.Clear();
                foreach (var item in PSlot.GetComponentsInChildren<CanvasRenderer>()) {
                    TriggerItem.Rend.Add(item);
                }
                // Personal_Slots.Add(PSlot.GetComponent<PersonalItemSlot>());


                //Update_Slots();
            }
        }
    }


  


}
