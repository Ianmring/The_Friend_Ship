
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Inventoryslot : MonoBehaviour
{
    public Image icon;

    public Text count;

    public bool istaken;
   // public Button removebutton;

   public Item item;

    public Item.type Itype;
    public string itemname;

    public int itemcount;

    public Text namee;

    Text Description_Name;

    Button button;

    uimanager mana;


    public void Awake()
    {
        Description_Name = GameObject.Find("name").GetComponentInParent<Text>();
        button = GetComponentInChildren<Button>();
    }
    public void Start()
    {
        mana = FindObjectOfType<uimanager>();

    }
    public void Addtiem(Item newitem)
    {

   //     namee = GetComponentInChildren<Text>();
               // itemcount++;
            istaken = true;
            item = newitem;
            icon.sprite = item.icon;
            itemname = item.name;
        Itype = newitem.Type;

        icon.enabled = true;
        namee.text = item.name;

        Image imag;

        button = GetComponentInChildren<Button>();

         imag = button.gameObject.GetComponent<Image>();
        switch (newitem.Type)
        {
            case Item.type.Disposeable:
                imag.color = Color.green;
                    break;
            case Item.type.Oare:
                imag.color = Color.yellow;

                break;
            case Item.type.Hat:
                imag.color = Color.magenta;

                break;
            case Item.type.Keyitem:

                imag.color = Color.cyan;
                break;
        }
         // removebutton.interactable = true;
    }
 
    
    private void Update()
    {
        if (button.gameObject == EventSystem.current.currentSelectedGameObject)
        {
            Description_Name.text = item.name;

            if (Input.GetButtonDown("AddtoPslot"))
            {
                inventorygeneral invt0;
                invt0 = mana.P1.GetComponent<inventorygeneral>();
                inventorygeneral invt1;
                invt1 = mana.P2.GetComponent<inventorygeneral>();


                switch (mana.playernums)
                {
                    case uimanager.Players.player1:
                        if (invt0.Personal_Slots.Count < 4)
                        {
                            if (item.Type == Item.type.Hat || item.Type == Item.type.Oare)
                            {
                                invt0.Addslot(item, 1, true);
                                itemcount--;

                            }
                            else
                            {
                                if(item.Type == Item.type.Keyitem)
                                {
                                    for (int i = 0; i < invt0.Personal_Slots.Count; i++)
                                    {
                                        if (invt0.Personal_Slots[i].currentitem.Type == Item.type.Keyitem)
                                        {
                                            return;
                                        }
                                    }

                                }


                                invt0.Addslot(item, itemcount, true);
                                itemcount = 0;
                            }

                        }
                        
                        break;
                    case uimanager.Players.player2:

                        if (invt1.Personal_Slots.Count < 4)
                        {
                            if (item.Type == Item.type.Hat || item.Type == Item.type.Oare)
                            {
                                invt1.Addslot(item, 1 , true);
                                itemcount--;

                            }
                            else
                            {
                                if (item.Type == Item.type.Keyitem)
                                {
                                    for (int i = 0; i < invt1.Personal_Slots.Count; i++)
                                    {
                                        if (invt1.Personal_Slots[i].currentitem.Type == Item.type.Keyitem)
                                        {
                                            return;
                                        }
                                    }

                                }

                                invt1.Addslot(item, itemcount, true);
                                itemcount = 0;
                            }

                        }
                        break;
            
                }
                Checkitemcount();



            }
            
        }
       
        count.text = itemcount.ToString();


    }
    public void clearslot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

       // removebutton.interactable = false;
    }
    

    public void UseItem()
    {
        if (item != null)
        {
            inventorygeneral invt0;
            invt0 = mana.P1.GetComponent<inventorygeneral>();
            inventorygeneral invt1;
            invt1 = mana.P2.GetComponent<inventorygeneral>();

            switch (mana.playernums)
            {
                case uimanager.Players.player1:
                    if (invt0.Personal_Slots.Count < 4 || item.Type == Item.type.Hat || item.Type == Item.type.Oare)
                    {
                        if (item.Type == Item.type.Disposeable)
                        {

                            
                            invt0.Addslot(item, 1,true);
                            itemcount--;

                        }
                       else if (item.Type == Item.type.Keyitem)
                        {
                            for (int i = 0; i < invt0.Personal_Slots.Count; i++)
                            {
                                if (invt0.Personal_Slots[i].currentitem.Type == Item.type.Keyitem)
                                {
                                    return;
                                }
                            }
                            invt0.AddKey(item, false);
                            itemcount--;
                         //   return;
                        }
                        else
                        {
                            item.Use();
                            itemcount--;

                        }
                    }
                    break;
                case uimanager.Players.player2:

                    if (invt1.Personal_Slots.Count < 4 || item.Type == Item.type.Hat || item.Type == Item.type.Oare)
                    {
                        if (item.Type == Item.type.Disposeable)
                        {


                            invt1.Addslot(item, 1, true);
                            itemcount--;

                        }
                        else if (item.Type == Item.type.Keyitem)
                        {
                            for (int i = 0; i < invt1.Personal_Slots.Count; i++)
                            {
                                if (invt1.Personal_Slots[i].currentitem.Type == Item.type.Keyitem)
                                {
                                    return;
                                }
                            }
                            invt1.AddKey(item, false);
                            itemcount--;
                           // return;
                        }
                        else
                        {
                            item.Use();
                            itemcount--;

                        }
                    }
                    break;

            }
           // itemcount--;
            Checkitemcount();
               

        }
    }

    public void Checkitemcount()
    {
      //  itemcount--;
        if (itemcount < 1)
        {
            EventSystem.current.SetSelectedGameObject(uimanager.UIinstance.buttons[ uimanager.UIinstance.currentselected]);
            switch (item.Type)
            {
                case Item.type.Disposeable:
                    FindObjectOfType<InventoryMenu>().slots.Remove(this);
                    break;
                case Item.type.Oare:
                    FindObjectOfType<InventoryMenu>().Oareslots.Remove(this);

                    break;
                case Item.type.Hat:
                    FindObjectOfType<InventoryMenu>().Hatlots.Remove(this);

                    break;
                case Item.type.Keyitem:
                    FindObjectOfType<InventoryMenu>().Keyslots.Remove(this);
                    break;
                default:
                    break;
            }
            Inventory.instance.Remove(item);
            Destroy(this.gameObject);

            //   istaken = false;
        }
        else
        {
            return;
        }


    }
}
