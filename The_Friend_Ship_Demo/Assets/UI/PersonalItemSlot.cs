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
    public Text count;
    public Image icon;
    public GameObject OBJ;
   public Button Button;
    KeyItem Kitem;

  public  inventorygeneral invt;

    public bool isbeingused;
    public bool isinteract { get; set; }
    public bool isitem;


    void Start()
    {
        Button = GetComponentInChildren<Button>();
       
       // itemcount = 1;
    }

    public void Additem(Item item, bool isitemI)
    {
        currentitem = item;
        icon.sprite = currentitem.icon;
        icon.enabled = true;
        OBJ = item.OBJ;
        Name.text = item.name;

        Image imag;

        Button = GetComponentInChildren<Button>();

        imag = Button.gameObject.GetComponent<Image>();


        //if (item.Type == Item.type.Keyitem)
        //{
        //    iskeyitem = true;
        //    Kitem = currentitem as KeyItem;

        //}
        //else
        //{
        //    Kitem = null;
        //}


        if (currentitem.GetType() == typeof(KeyItem) && !isitemI)
        {
            Kitem = currentitem as KeyItem;
            imag.color = Color.green;

            iskeyitem = true;
            count.text = "I";
            switch (Kitem.KeyItemType)
            {
               
                case KeyItem.KeyitemType.ParaScope:
                    this.gameObject.AddComponent<Parascope>();
                    break;
                case KeyItem.KeyitemType.Map:
                    this.gameObject.AddComponent<Map>();

                    break;
                case KeyItem.KeyitemType.Compass:
                    this.gameObject.AddComponent<Compass>();

                    break;
                case KeyItem.KeyitemType.ClipBoard:
                    this.gameObject.AddComponent<CheckList>();

                    break;
              
            }

        }
        else
        {
            iskeyitem = false;


            this.gameObject.AddComponent<Throwable>();

        }
        //invt.Update_Slots(); 

        //  Debug.Log(currentitem.GetType());

    }
    public void ChangeActive()
    {
        if (isinteract)
        {
            Button.interactable = true;
        }
        else
        {
            Button.interactable = false;
        }
    }
    // Update is called once per frame
   

    public void Transferall()
    {
      //  FindObjectOfType<uimanager>().Updateslotsgen();

        invt.TriggerItem.ClearItem();
        itemcount = 1;

       
            
          
                Inventory.instance.AddKey(currentitem, itemcount);



        // FindObjectOfType<uimanager>().Updateslotsgen();
        //itemcount = 0;


      //  invt.Update_Slots();
        //return;

        Destroy(this.gameObject);

    }

 
  
}
