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


    public PersonalItemSlot[] Personal_Slots;

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
        if (Personal_Slots.Length < 1)
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
            FindObjectOfType<uimanager>().Updateslotsgen();

        }
    }

    public void Addslot(Item item , int count)
    {

        for (int i = 0; i < Personal_Slots.Length; i++)
        {
            if (Personal_Slots[i].currentitem == item)
            {
                Personal_Slots[i].itemcount += count;
                return;
            }

           
            
           
        }
        // Debug.Log(item + "has been added to " + player.playernum + "'s inventory");
        if (Personal_Slots.Length < 5)
        {
           
                GameObject PSlot;
                PSlot = Instantiate(currentslot, Container);
                PSlot.GetComponent<PersonalItemSlot>().Additem(item);
                PSlot.GetComponent<PersonalItemSlot>().Playernum = player.direction;
            PSlot.GetComponent<PersonalItemSlot>().itemcount = count;
                //items.Add(item);
                //Personal_Slots = GetComponentsInChildren<PersonalItemSlot>();
                //Personal_Slots[Personal_Slots.Length].Additem(item);

                Update_Slots();
            
           
        }
      
        
    }

    //public void Updateslotsspecial()
    //{
    //    slotnums_P = Container.transform.childCount;

    //    Personal_Slots = new PersonalItemSlot[slotnums_P];
    //}
    public void Update_Slots()
    {
       
        //else
        //{
        slotnums_P = Container.transform.childCount;

            Personal_Slots = new PersonalItemSlot[slotnums_P];
      //  Debug.Log("istriggerd");
            for (int i = 0; i < Personal_Slots.Length; i++)
            {
                Personal_Slots[i] = Container.transform.GetChild(i).GetComponent<PersonalItemSlot>();




            }

            if (currentitem > Personal_Slots.Length - 1)
            {
                currentitem = Personal_Slots.Length - 1;
            }
            else if (currentitem < 0)
            {
                currentitem = 0;
            }



            if (Container.transform.childCount == 0)
            {
                return;
            }
            else
            {
                Selector.transform.position = Personal_Slots[currentitem].transform.position;

                launch.rocketPrefab = Personal_Slots[currentitem].OBJ.GetComponent<Rigidbody>();
            }


        //}
       // Debug.Log("updatingslot");

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
        // Update_Slots();


        if (Personal_Slots[currentitem].itemcount < 2)
        {
          //  items.Remove(Personal_Slots[currentitem].currentitem);
          Destroy(Personal_Slots[currentitem].gameObject);

        }
        else
        {
            Personal_Slots[currentitem].itemcount--;

        }

        //   Update_Slots();

    }
   


}
