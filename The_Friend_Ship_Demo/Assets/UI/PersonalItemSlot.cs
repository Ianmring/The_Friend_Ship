﻿using System.Collections;
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

        if (item.Type == Item.type.Keyitem)
        {
            iskeyitem = true;
            Kitem = currentitem as KeyItem;

        }
        else
        {
            Kitem = null;
        }
        if (currentitem.GetType() == typeof(KeyItem))
        {

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
        Debug.Log(currentitem.GetType());

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

    public void dosomething()
    {

        switch (Kitem.KeyItemType)
        {

            case KeyItem.KeyitemType.ParaScope:
                this.gameObject.GetComponent<Parascope>().Dothething();
                break;
            case KeyItem.KeyitemType.Map:
                this.gameObject.GetComponent<Map>().Dothething();

                break;
            case KeyItem.KeyitemType.Compass:
                this.gameObject.GetComponent<Compass>().Dothething();

                break;
            case KeyItem.KeyitemType.ClipBoard:
                this.gameObject.GetComponent<CheckList>().Dothething();

                break;

        }
    }

    public void DontDoSomething()
    {
       

        switch (Kitem.KeyItemType)
        {

            case KeyItem.KeyitemType.ParaScope:
                this.gameObject.GetComponent<Parascope>().DoDo();
                break;
            case KeyItem.KeyitemType.Map:
                this.gameObject.GetComponent<Map>().DoDo();

                break;
            case KeyItem.KeyitemType.Compass:
                this.gameObject.GetComponent<Compass>().DoDo();

                break;
            case KeyItem.KeyitemType.ClipBoard:
                this.gameObject.GetComponent<CheckList>().DoDo();

                break;

        }
    }
  
}
