using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class KeyitemTrigger : MonoBehaviour
{

    public PersonalItemSlot KeyItem;

    MainLauncher mainl;
    public launcher PL;


    public KeyItem KI;

    [SerializeField]
   public GameObject currentobj;

    [SerializeField]
    Slider Itemslide;

    [SerializeField]
  public List<CanvasRenderer> Rend ;
   public bool Isitem { get; set; }

    public bool isusing;

    public bool isaway;
    // Start is called before the first frame update
    public void Additem(PersonalItemSlot Kitem, launcher L, bool isitem)
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
        UIgo.player = L.playa;
        // mainl = ML;
        PL = L;



    }
    //public void ClearItem()
    //{


    //    KeyItem = null;
    //    KI = null;
    //    isactive = false;


    //    Destroy(currentobj);
    //}

    // Update is called once per frame
    void Update() {

        if (PL == null || Itemslide == null) {
            return;
        } else {
            Itemslide.value = PL.IReady;

        }



        if (PL.IReady > 0) {
            isaway = false;
            GetComponent<CanvasRenderer>().SetAlpha(.5f + (-Itemslide.value));
            foreach (var item in Rend) {
                item.SetAlpha(1 + (-Itemslide.value));
            }
            if (PL.IReady > .8f) {
                isusing = true;
            } else {
                isusing = false;

            }
        } else {
            isaway = true;
            GetComponent<CanvasRenderer>().SetAlpha(.5f);
            foreach (var item in Rend) {
                item.SetAlpha(1);
            }

        } 
        
        



    }

    public void dosomething()
    {
        if (Isitem )
        {
          //  this.gameObject.GetComponentInChildren<Throwable>().Dothething();

        }
        else
        {
           
        }
    }

    public void DontDoSomething()
    {
        if (Isitem )
        {
          //  this.gameObject.GetComponentInChildren<Throwable>().DoDo();

        }
        else
        {
           

        }
    }
}

