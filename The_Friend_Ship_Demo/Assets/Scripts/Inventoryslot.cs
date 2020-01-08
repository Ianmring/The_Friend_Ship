
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    public TextMeshProUGUI namee;

    Text Description_Name;

    Button button;

    uimanager mana;


    public void Awake()
    {

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
 
    
  
    public void clearslot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

       // removebutton.interactable = false;
    }
    

  
    public void Checkitemcount()
    {
      //  itemcount--;
        if (itemcount < 1)
        {
          
                    FindObjectOfType<InventoryMenu>().Keyslots.Remove(this);
                  
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
