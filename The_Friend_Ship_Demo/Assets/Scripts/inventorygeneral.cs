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
    public List<PersonalItemSlot> Personal_Slots = new List<PersonalItemSlot>();
    public Item Keyitem;
  // public List<Item> items = new List<Item>();
    public Transform Container;
    public Transform KIContainer;

    public Transform Selector;

  public  MainLauncher launch { get; set; }

    public launcher GLauncher { get; set; }
    public bool isyourturn;

    public KeyitemTrigger TriggerItem;
    // Start is called before the first frame update
    void Start()
    {
        launch = FindObjectOfType<MainLauncher>();
        GLauncher = GetComponent<launcher>();
        player = GetComponent<Playergen>();
        INVNUM = player.direction;
        Container = GameObject.Find("D" + player.direction + "_Inv").GetComponent<Transform>();
        KIContainer = GameObject.Find("KeyItem" + player.direction).GetComponent<Transform>();
        TriggerItem = GameObject.Find("KeyItem" + player.direction).GetComponent<KeyitemTrigger>();
        Selector = GameObject.Find("SelectedD" + player.direction).GetComponent<Transform>();
        currentitem = 0;

        Update_Slots();
    }

    // Update is called once per frame
    void Update()
    {

        if (Personal_Slots.Count<= 0)
        {
            currentitem = 0;

            return;
        }
        else
        {
                    if (currentitem > Personal_Slots.Count-1 )
            {
                currentitem = Personal_Slots.Count-1;
            }
            else if (currentitem < 0)
            {
                currentitem = 0;
            }

            Selector.transform.position = Personal_Slots[currentitem].transform.position;
            
        }


        if (Input.GetButtonUp("AddtoPslot"))
        {
            FindObjectOfType<uimanager>().Triggerupdate();

        }
    }

    public void Addslot(Item item, int count, bool isitem)
    {


        for (int i = 0; i < Personal_Slots.Count; i++)
        {
            if (Personal_Slots[i].currentitem == item)
            {
                Personal_Slots[i].itemcount += count;
                return;
            }

           
            
           
        }
        // Debug.Log(item + "has been added to " + player.playernum + "'s inventory");
        //if (Personal_Slots.Count < 5)
        //{
            
                GameObject PSlot;
        PersonalItemSlot slot;

        PSlot = Instantiate(currentslot, Container);
        slot = PSlot.GetComponent<PersonalItemSlot>();

        slot.Additem(item , isitem);
       // slot.isitem = isitem;

        slot.Playernum = player.direction;
        slot.invt = this;

        slot.itemcount = count;

        Personal_Slots.Add(PSlot.GetComponent<PersonalItemSlot>());
 

                Update_Slots();
            

      
        
    }

    public void AddKey(Item Kitem, bool isitem)
    {
        if (Kitem == Keyitem)
        {
            return;
        }
        else
        {
            GameObject PSlot;
            PersonalItemSlot slot;
            PSlot = Instantiate(currentslot, KIContainer);
            slot = PSlot.GetComponent<PersonalItemSlot>();

            slot.Additem(Kitem, isitem);
            Keyitem = Kitem;

            slot.Playernum = player.direction;
            slot.invt = this;


          //  slot.isitem = isitem;
            TriggerItem.Additem(slot, GLauncher);

            // Personal_Slots.Add(PSlot.GetComponent<PersonalItemSlot>());


            Update_Slots();
        }
    }


    public void Update_Slots()
    {


        launch.updateLauncher();




    }

    public void removeOBJ(PersonalItemSlot slot)
    {
        Personal_Slots.Remove(slot);


    }
    public void Handoff()
    {
      Update_Slots();
      
            if (player.UIMana.isopen && isyourturn)
            {

            foreach (var slot in Personal_Slots)
            {
                if (slot.Button.gameObject == EventSystem.current.currentSelectedGameObject)
                {
                    EventSystem.current.SetSelectedGameObject(uimanager.UIinstance.buttons[uimanager.UIinstance.currentselected]);
                }
                // Container.GetComponentInParent<GameObject>().SetActive(true);
                slot.isinteract = true;
                slot.ChangeActive();
            }


            }


            else
            {
            foreach (var slot in Personal_Slots)
            {
                // Container.GetComponentInParent<GameObject>().SetActive(false);
                if (slot.Button.gameObject == EventSystem.current.currentSelectedGameObject)
                {
                    EventSystem.current.SetSelectedGameObject(uimanager.UIinstance.buttons[uimanager.UIinstance.currentselected]);
                }
                slot.isinteract = false;
                slot.ChangeActive();
            }

        }


        
    }
 
    public void Subinvt()
    {
        Update_Slots();


        if (Personal_Slots[currentitem].itemcount < 2)
        {
            //  items.Remove(Personal_Slots[currentitem].currentitem);

            GameObject obj;
            obj = Personal_Slots[currentitem].gameObject;
            Personal_Slots.Remove(Personal_Slots[currentitem]);

            Destroy(obj);
            obj = null;


        }
        else
        {
            Personal_Slots[currentitem].itemcount--;

        }
      Update_Slots();
        //   Update_Slots();

    }
   


}
