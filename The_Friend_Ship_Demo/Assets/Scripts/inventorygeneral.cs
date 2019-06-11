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

  // public List<Item> items = new List<Item>();
    public Transform Container;

    public Transform Selector;

    launcher launch;

    public bool isyourturn;

    // Start is called before the first frame update
    void Start()
    {
        launch = GetComponentInChildren<launcher>();
        player = GetComponent<Playergen>();
        INVNUM = player.direction;
        Container = GameObject.Find("D" + player.direction + "_Inv").GetComponent<Transform>();
        Selector = GameObject.Find("SelectedD" + player.direction).GetComponent<Transform>();
        Update_Slots();
    }

    // Update is called once per frame
    void Update()
    {

        if (Personal_Slots.Count== 0)
        {
            return;
        }
        else
        {
            Selector.transform.position = Personal_Slots[currentitem].transform.position;

        }


        if (Personal_Slots.Count < 1)
        {
            launch.isempty = true;
            
        }
        else
        {
            launch.isempty = false;
        }
        if (Input.GetButtonUp("AddtoPslot"))
        {
            Debug.Log("UpdateS");
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
                PSlot = Instantiate(currentslot, Container);

                PSlot.GetComponent<PersonalItemSlot>().Additem(item);
                PSlot.GetComponent<PersonalItemSlot>().Playernum = player.direction;
        PSlot.GetComponent<PersonalItemSlot>().invt = this;

        PSlot.GetComponent<PersonalItemSlot>().itemcount = count;
        PSlot.GetComponent<PersonalItemSlot>().isitem= isitem;

        Personal_Slots.Add(PSlot.GetComponent<PersonalItemSlot>());
 

                Update_Slots();
            

      
        
    }

  
    public void Update_Slots()
    {

   
        if (currentitem > Personal_Slots.Count - 1)
            {
                currentitem = Personal_Slots.Count - 1;
            }
            else if (currentitem < 0)
            {
                currentitem = 0;
            }



            if (Personal_Slots.Count == 0)
            {
            launch.rocketPrefab = null;
            launch.Slot = null;

            return;
            }
            else
            {
                Selector.transform.position = Personal_Slots[currentitem].transform.position;

                launch.rocketPrefab = Personal_Slots[currentitem].OBJ.GetComponent<Rigidbody>();
               launch.Slot = Personal_Slots[currentitem];
            }


        //}
       // Debug.Log("updatingslot");

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
