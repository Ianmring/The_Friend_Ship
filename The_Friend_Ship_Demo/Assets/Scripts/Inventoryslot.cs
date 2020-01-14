
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Inventoryslot : MonoBehaviour
{
    public Image icon;

    public Text count;

  //  public bool istaken;
   // public Button removebutton;

   public Item item;

    public Item.type Itype;
    public string itemname;

    public int itemcount;

    public TextMeshProUGUI namee;

    Text Description_Name;


    uimanager mana;

    public bool ontable;

    public GameObject OBJ;

    public void Awake()
    {

    }
    public void Start()
    {
        mana = FindObjectOfType<uimanager>();

    }
    public void Addtiem(Item newitem)
    {

            item = newitem;
            icon.sprite = item.icon;
            itemname = item.name;
        Itype = newitem.Type;

        icon.enabled = true;
        namee.text = item.name;

    }
 
    
  
    public void clearslot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

    }
    

  
    public void Checkitemcount()
    {
        if (itemcount < 1)
        {
          
            FindObjectOfType<InventoryMenu>().Keyslots.Remove(this);                  
            Inventory.instance.Remove(item);
            Destroy(this.gameObject);

        }
        else
        {
            return;
        }


    }
}
