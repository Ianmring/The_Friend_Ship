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


      

        if (numitems == info.costItems.Length && numcosts == info.costAmmounts.Length)
        {
            Debug.Log("Items Match");

   
                    Inventory.instance.AddKey(info.ItemTobuy, 1);

            
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
  
}
