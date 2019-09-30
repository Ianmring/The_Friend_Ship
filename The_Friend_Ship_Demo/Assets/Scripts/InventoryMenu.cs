using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public Transform itemsparent;
    public Transform keyitemparent;
    public Transform Oareitemparent;
    public Transform Hatitemparent;


    //  public GameObject inventoryUI;

    Inventory inventory;

    public GameObject slot;

    // int dissolts;
    //int keyslots;
    //int oareslots;
    //int hatslots;
   public List<Inventoryslot> slots { get; set; } = new List<Inventoryslot>();
   public List<Inventoryslot> Keyslots { get; set; } = new List<Inventoryslot>();
  public   List<Inventoryslot> Oareslots { get; set; } = new List<Inventoryslot>();
  public  List<Inventoryslot> Hatlots { get; set; } = new List<Inventoryslot>();


    public GameObject inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);
        inventory = Inventory.instance;

        inventory.onitemchangedcallback += AddUI;

        inventory.onkeyitemchangedcallback += AddUIKey;

        inventory.onOareitemchangedcallback += AddUIOare;

        inventory.onHatitemchangedcallback += AddUIHat;



        inventory.onitemSamecallback += UpdateSlotitem;

        inventory.OnOareitemsamecallback += UpdateSlotOare;

        inventory.onHatitemsamecallback += UpdateSlotHat;

        inventory.onKeyitemSamecallback += UpdateSlotKey;



    }

    // Update is called once per frame
    void Update()
    {
        
     
    }
 public void AddUI(Item item , int count)
    {
        // Debug.Log(item.name);
        GameObject disslot;
       disslot = Instantiate(slot, itemsparent);
        disslot.GetComponent<Inventoryslot>().itemcount += count;
      //  slots = itemsparent.GetComponentsInChildren<Inventoryslot>();

        slots.Add(disslot.GetComponent<Inventoryslot>());

        slots[slots.Count-1].Addtiem(item);

     //   uimanager.UIinstance.Triggerupdate();



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

  public void AddUIOare(Item item, int count)
    {
        GameObject Oareslot;
       Oareslot = Instantiate(slot, Oareitemparent);
      //  Oareslots = Oareitemparent.GetComponentsInChildren<Inventoryslot>();
        Oareslot.GetComponent<Inventoryslot>().itemcount += count;

        Oareslots.Add(Oareslot.GetComponent<Inventoryslot>());

        Oareslots[Oareslots.Count - 1].Addtiem(item);
       // uimanager.UIinstance.Triggerupdate();

      

    }
 public void AddUIHat(Item item, int count)
    {
        GameObject Hatslot;

        Hatslot =Instantiate(slot, Hatitemparent);
   //     Hatlots = Hatitemparent.GetComponentsInChildren<Inventoryslot>();
        Hatslot.GetComponent<Inventoryslot>().itemcount += count;

        Hatlots.Add(Hatslot.GetComponent<Inventoryslot>());

        Hatlots[Hatlots.Count - 1].Addtiem(item);
       // uimanager.UIinstance.Triggerupdate();

       
    }



    void UpdateSlotitem(Item item, int count)
    {
        foreach (var Item in slots)
        {
            if (Item.itemname == item.name)
            {
                Item.itemcount += count;
              //  uimanager.UIinstance.Triggerupdate();

            }
        }
    }

    void UpdateSlotOare(Item item, int count)
    {
        foreach (var Item in Oareslots)
        {
            if (Item.itemname == item.name)
            {
                Item.itemcount += count;
               // uimanager.UIinstance.Triggerupdate();

            }
        }
    }

    void UpdateSlotHat(Item item, int count)
    {
        foreach (var Item in Hatlots)
        {
            if (Item.itemname == item.name)
            {
                Item.itemcount += count;
             //   uimanager.UIinstance.Triggerupdate();

            }
        }
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
