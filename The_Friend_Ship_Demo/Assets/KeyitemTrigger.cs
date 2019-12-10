using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class KeyitemTrigger : MonoBehaviour
{

    public PersonalItemSlot KeyItem;

    public Playergen PL;


    public KeyItem KI;

    [SerializeField]
   public GameObject currentobj;

    [SerializeField]
    Slider Itemslide;

   public bool Isitem { get; set; }

    public bool isusing;

    public bool isaway;
    // Start is called before the first frame update
    public void Additem(PersonalItemSlot Kitem, Playergen L, bool isitem)
    {
        if (Kitem == null) {
            Destroy(currentobj);
            currentobj = null;
            KeyItem = null;
            KI = null;
            Itemslide = null;
            return;
        }
       Destroy(currentobj);
        currentobj = null;

        Isitem = isitem;
        KeyItem = Kitem;
        KI = Kitem.currentitem as KeyItem;
        Itemslide = GetComponentInParent<Slider>();
        GameObject Item;
        UIMovement UIgo;
        Item = Instantiate(Kitem.currentitem.UIOBJ, Itemslide.handleRect);
        currentobj = Item;
        
        UIgo = Item.GetComponent<UIMovement>();
        UIgo.Trig = this;
        UIgo.player = L;
        // mainl = ML;
        PL = L;



    }
  
    // Update is called once per frame
    void LateUpdate() {

        if (PL == null || Itemslide == null) {
            return;
        }
        else if (PL.isselectingitem) {
            Itemslide.value = 1;
            isaway = false;
            isusing = true;

        }
        else {
            Itemslide.value = 0;

            isaway = true;
            isusing = false;

        }


    }

  
}

