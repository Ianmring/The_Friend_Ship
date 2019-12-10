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


      


        if (currentitem.GetType() == typeof(KeyItem) && !isitemI)
        {
            Kitem = currentitem as KeyItem;
            imag.color = Color.green;

            iskeyitem = true;
            count.text = "I";
          

        }
        else
        {
            iskeyitem = false;


            this.gameObject.AddComponent<Throwable>();

        }
   

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
   

  
 
  
}
