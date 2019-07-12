using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyitemTrigger : MonoBehaviour
{

    public PersonalItemSlot KeyItem;

    MainLauncher mainl;
    public launcher PL;

    public bool isactive;

    public KeyItem KI;

   public bool Isitem { get; set; }
    // Start is called before the first frame update
    public void Additem(PersonalItemSlot Kitem, launcher L, bool isitem)
    {
        Isitem = isitem;
        KeyItem = Kitem;
        KI = Kitem.currentitem as KeyItem;
        // mainl = ML;
        PL = L;
        isactive = true;

    }
    public void ClearItem()
    {
        KeyItem.gameObject.SendMessage("Turnoff", SendMessageOptions.DontRequireReceiver);
        KeyItem.invt.Keyitem = null;
        KeyItem = null;
        KI = null;
        isactive = false;


    }

    // Update is called once per frame
    void Update()
    {
        //if (KeyItem==null)
        //{
        //    isactive = false;
        //}

        if (isactive)
        {
            if (PL.IReady > 0)
            {
                //   movement.MovInstance.altoveride = true;

                dosomething();
            }
            else
            {
                //   movement.MovInstance.altoveride = false;

                DontDoSomething();

            }
        }
        else
        {
            // Debug.Log("NO");
            return;
        }



    }

    public void dosomething()
    {
        if (Isitem )
        {
            this.gameObject.GetComponentInChildren<Throwable>().Dothething();

        }
        else
        {
            switch (KI.KeyItemType)
            {

                case global::KeyItem.KeyitemType.ParaScope:
                    this.gameObject.GetComponentInChildren<Parascope>().Dothething();

                    break;
                case global::KeyItem.KeyitemType.Map:
                    this.gameObject.GetComponentInChildren<Map>().Dothething();

                    break;
                case global::KeyItem.KeyitemType.Compass:
                    this.gameObject.GetComponentInChildren<Compass>().Dothething();

                    break;
                case global::KeyItem.KeyitemType.ClipBoard:
                    this.gameObject.GetComponentInChildren<CheckList>().Dothething();


                    break;
            }
        }
    }

    public void DontDoSomething()
    {
        if (Isitem )
        {
            this.gameObject.GetComponentInChildren<Throwable>().DoDo();

        }
        else
        {
            switch (KI.KeyItemType)
            {

                case global::KeyItem.KeyitemType.ParaScope:
                    this.gameObject.GetComponentInChildren<Parascope>().DoDo();

                    break;
                case global::KeyItem.KeyitemType.Map:
                    this.gameObject.GetComponentInChildren<Map>().DoDo();

                    break;
                case global::KeyItem.KeyitemType.Compass:
                    this.gameObject.GetComponentInChildren<Compass>().DoDo();

                    break;
                case global::KeyItem.KeyitemType.ClipBoard:
                    this.gameObject.GetComponentInChildren<CheckList>().DoDo();

                    break;


            }

        }
    }
}

