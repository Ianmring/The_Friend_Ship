
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

   public Inventoryslot[] slots;
    Inventoryslot[] Keyslots;
    Inventoryslot[] Oareslots;
    Inventoryslot[] Hatlots;


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
    void AddUI(Item item , int count)
    {
        // Debug.Log(item.name);
        GameObject disslot;
       disslot = Instantiate(slot, itemsparent);
        disslot.GetComponent<Inventoryslot>().itemcount += count;
        slots = itemsparent.GetComponentsInChildren<Inventoryslot>();
      

        slots[slots.Length-1].Addtiem(item);

        uimanager.UIinstance.Triggerupdate();
        //for (int i = 0; i < slots.Length; i++)
        //{
        //    if (i < inventory.items.Count)
        //    {
        //        slots[i].Addtiem(inventory.items[i]);


        //    }
        //    else
        //    {
        //        slots[i].clearslot();
        //    }
        //}
    }
    void AddUIKey(Item item, int count)
    {
        GameObject Keyslot;
        Keyslot = Instantiate(slot, keyitemparent);
        Keyslots = keyitemparent.GetComponentsInChildren<Inventoryslot>();
        Keyslot.GetComponent<Inventoryslot>().itemcount += count;


        Keyslots[Keyslots.Length - 1].Addtiem(item);
        uimanager.UIinstance.Triggerupdate();

        //for (int i = 0; i < Keyslots.Length; i++)
        //{
        //    if (i < inventory.KeyItems.Count)
        //    {
        //        Keyslots[i].Addtiem(inventory.KeyItems[i]);

        //    }
        //    else
        //    {
        //        Keyslots[i].clearslot();
        //    }
        //}
    }

    void AddUIOare(Item item, int count)
    {
        GameObject Oareslot;
       Oareslot = Instantiate(slot, Oareitemparent);
        Oareslots = Oareitemparent.GetComponentsInChildren<Inventoryslot>();
        Oareslot.GetComponent<Inventoryslot>().itemcount += count;

        Oareslots[Oareslots.Length - 1].Addtiem(item);
        uimanager.UIinstance.Triggerupdate();

        //for (int i = 0; i < Oareslots.Length; i++)
        //{
        //    if (i < inventory.Oare.Count)
        //    {

        //        Oareslots[i].Addtiem(inventory.Oare[i]);


        //    }
        //    else
        //    {
        //        Oareslots[i].clearslot();
        //    }
        //}



    }
    void AddUIHat(Item item, int count)
    {
        GameObject Hatslot;

        Hatslot =Instantiate(slot, Hatitemparent);
        Hatlots = Hatitemparent.GetComponentsInChildren<Inventoryslot>();
        Hatslot.GetComponent<Inventoryslot>().itemcount += count;

        Hatlots[Hatlots.Length - 1].Addtiem(item);
        uimanager.UIinstance.Triggerupdate();

        //for (int i = 0; i < Hatlots.Length; i++)
        //{
        //    if (i < inventory.KeyItems.Count)
        //    {
        //        Hatlots[i].Addtiem(inventory.Hat[i]);

        //    }
        //    else
        //    {
        //        Hatlots[i].clearslot();
        //    }
        //}
    }



    void UpdateSlotitem(Item item, int count)
    {
        foreach (var Item in slots)
        {
            if (Item.itemname == item.name)
            {
                Item.itemcount += count;
                uimanager.UIinstance.Triggerupdate();

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
                uimanager.UIinstance.Triggerupdate();

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
                uimanager.UIinstance.Triggerupdate();

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
                uimanager.UIinstance.Triggerupdate();

            }
        }
    }
}
