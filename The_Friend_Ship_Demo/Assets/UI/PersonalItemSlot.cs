using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PersonalItemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public int Playernum;
    public Item currentitem;
    public int itemcount;
    public Text Name;
    public Text count;
    public Image icon;
    public GameObject OBJ;
   public Button Button;
    public bool isinteract { get; set; }
    void Start()
    {
        Button = GetComponentInChildren<Button>();
       // itemcount = 1;
    }

    public void Additem(Item item)
    {
        currentitem = item;
        icon.sprite = currentitem.icon;
        icon.enabled = true;
        OBJ = item.OBJ;
        Name.text = item.name;

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
    void Update()
    {
        count.text = itemcount.ToString();
       
    }

    public void Transferall()
    {
      //  FindObjectOfType<uimanager>().Updateslotsgen();

        switch (currentitem.Type)
        {
            case Item.type.Disposeable:
                Inventory.instance.Add(currentitem, itemcount);
                break;
            case Item.type.Oare:
                Inventory.instance.AddOare(currentitem, itemcount);

                break;
            case Item.type.Hat:
                Inventory.instance.AddHat(currentitem, itemcount);

                break;
            case Item.type.Keyitem:
                Inventory.instance.AddKey(currentitem, itemcount);

                break;
      
        }

      // FindObjectOfType<uimanager>().Updateslotsgen();
            EventSystem.current.SetSelectedGameObject(uimanager.UIinstance.buttons[uimanager.UIinstance.currentselected]);
        //itemcount = 0;

        FindObjectOfType<uimanager>().Updateslotsgen(this.GetComponent<PersonalItemSlot>());

        
        //return;

        Destroy(this.gameObject);

    }
    //private void OnDestroy()
    //{
    //    if (Playernum == 0)
    //    {

    //        mana.P1.GetComponent<inventorygeneral>().currentitem = -1;
    //        //    mana.P1.GetComponent<inventorygeneral>().Update_Slots();

    //        // Debug.Log("updatingp1slot");

    //    }
    //    if (Playernum == 1)
    //    {

    //        mana.P2.GetComponent<inventorygeneral>().currentitem = -1;
    //        //   mana.P2.GetComponent<inventorygeneral>().Update_Slots();

    //        //   Debug.Log("updatingp2slot");


    //    }
    //}
}
