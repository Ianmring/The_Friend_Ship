using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PersonalItemSlot : MonoBehaviour
{
    // Start is called before the first frame update
   public bool iskeyitem;
    public int Playernum;
    public Item currentitem;
    public int itemcount;
    public Text Name;
    public GameObject OBJ;
    KeyItem Kitem;

  public  inventorygeneral invt;



    void Start()
    {
       
       // itemcount = 1;
    }

    public void Additem(Item item, bool isitemI)
    {
        currentitem = item;
        OBJ = item.OBJ;
        Name.text = item.name;


      


        if (currentitem.GetType() == typeof(KeyItem) && !isitemI)
        {
            Kitem = currentitem as KeyItem;

            iskeyitem = true;         

        }
        else
        {
            iskeyitem = false;


            this.gameObject.AddComponent<Throwable>();

        }
   

    }
    
 
  
}
