
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

    public bool isspawned;

    public bool isslected;

    public UIMovement OBJ;

    public int itemplace;

    public void Awake()
    {

    }
    public void Start()
    {
        mana = FindObjectOfType<uimanager>();
        isslected = true;
        //icon.GetComponent<RectTransform>().sizeDelta = new Vector2(item.spritedimension.x , item.spritedimension.y);
        //icon.GetComponent<RectTransform>().localPosition = new Vector2(item.spritelocation.x, item.spritelocation.y);


    }
    public void Addtiem(Item newitem)
    {

            item = newitem;
          //  icon.sprite = item.icon;
            itemname = item.name;
        Itype = newitem.Type;

        //icon.enabled = true;
        namee.text = item.name;

    }
 
    
  public void UpdateSlot() {

        if (ontable || isslected) { 

           OBJ.gameObject.SetActive(true);

        } else {
          OBJ.gameObject.SetActive(false);

        }
    }
    private void LateUpdate() {

        if (OBJ != null) {
            if (ontable || isslected) {

                OBJ.gameObject.SetActive(true);

            } else {
                OBJ.gameObject.SetActive(false);

            }
        }
    }

    public void clearslot()
    {
        item = null;
        //icon.sprite = null;
        //icon.enabled = false;

    }
    
    public void ReassignSlot(Playergen Play, KeyitemTrigger Trigg) {
        OBJ.Assignplayer(Play, Trigg , Play.iskeyboard);
        Vector3 position;
        position = OBJ.transform.position;
        if ((!ontable) ||  ontable && isslected) {
            OBJ.transform.SetParent(Trigg.Itemslide.handleRect);
            if (ontable) {
                OBJ.trans.position = position;
            } else {
                OBJ.trans.position = Trigg.Itemslide.handleRect.position;

            }
            //   Play.playercanvas.sortingOrder = Trigg.KI.layer;

        } else if (ontable && !isslected) {

        
            OBJ.transform.SetParent(InventoryMenu.invmeninstance.interactionarea.transform);
           
        }

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
