
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
                imag.color = Color.cyan;
                    break;
            case Item.type.Oare:
                imag.color = Color.yellow;

                break;
            case Item.type.Hat:
                imag.color = Color.magenta;

                break;
            case Item.type.Keyitem:

                imag.color = Color.green;
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

                        if (invt0.TriggerItem.KeyItem == null)
                        {
                            invt0.AddKey(item, true);
                            itemcount--;
                        }
                        break;
                    case uimanager.Players.player2:
                        if (invt1.TriggerItem.KeyItem == null)
                        {
                            invt1.AddKey(item, true);
                            itemcount--;
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

                    if (invt0.TriggerItem.KeyItem == null)
                    {
                        if (item.Type == Item.type.Hat || item.Type == Item.type.Oare)
                        {



                            item.Use();
                            itemcount--;


                        }
                        else if (item.Type == Item.type.Keyitem)
                        {
                            if (invt0.Keyitem == item)
                            {
                                return;
                            }
                            invt0.AddKey(item, false);
                            itemcount--;
                            //   return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case uimanager.Players.player2:
                    if (invt1.TriggerItem.KeyItem == null)
                    {
                        {

                        }
                        if (item.Type == Item.type.Hat || item.Type == Item.type.Oare)
                        {



                            item.Use();
                            itemcount--;


                        }
                        else if (item.Type == Item.type.Keyitem)
                        {
                            if (invt1.Keyitem == item)
                            {
                                return;
                            }
                            invt1.AddKey(item, false);
                            itemcount--;
                            //   return;
                        }
                        else
                        {
                            return;
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
