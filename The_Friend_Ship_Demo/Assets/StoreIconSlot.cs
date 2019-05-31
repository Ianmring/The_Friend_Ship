using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Shop Item")]

public class StoreIconSlot : MonoBehaviour
{

    public int quantity;


    int numitems;
    int numcosts;

    public Text Namee;
    public Text Quantity;

    public InventoryMenu Inv;

    // bool itemmatch;
    // bool countmatch;

    public StoreItemInfo info;
    public void Buy()
    {


        for (int i = 0; i < info.costItems.Length; i++)
        {
            for (int x = 0; x < Inv.slots.Count; x++)
            {
                if (info.costItems[i] == Inv.slots[x].item  && info.costAmmounts[i] <= Inv.slots[x].itemcount)
                {
                    Inv.slots[x].itemcount = Inv.slots[x].itemcount - info.costAmmounts[i];
                    Inv.slots[x].Checkitemcount();
                    numitems++;
                    numcosts++;
                   
                 
                }
        
            }
        }

        if (numitems == info.costItems.Length && numcosts == info.costAmmounts.Length)
        {
            Debug.Log("Items Match");

            switch (info.ItemTobuy.Type)
            {
                case Item.type.Disposeable:
                    Inventory.instance.Add(info.ItemTobuy, 1);
                    break;
                case Item.type.Oare:
                    Inventory.instance.AddOare(info.ItemTobuy, 1);
                    break;
                case Item.type.Hat:
                    Inventory.instance.AddHat(info.ItemTobuy, 1);
                    break;
                case Item.type.Keyitem:
                    Inventory.instance.AddKey(info.ItemTobuy, 1);
                    break;

            }
            numcosts = 0;
            numitems = 0;
            quantity--;
            Quantity.text = quantity.ToString();
            if (quantity < 1)
            {
                Destroy(this.gameObject);
            }
            //itemmatch = true;
        }
        else
        {
            Debug.Log("Items dont Match");
            numcosts = 0;
            numitems = 0;
            return;
        }
      

    }
    // Start is called before the first frame update
    void Start()
    {
        Inv = FindObjectOfType<InventoryMenu>();
        Quantity.text = quantity.ToString();
        Namee.text = info.ItemTobuy.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
