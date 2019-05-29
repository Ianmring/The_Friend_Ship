using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    #region Singelton

    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of inv found");
            return;
        }
        instance = this;
    }
    #endregion

    #region Callbacks

    public delegate void OnitemChanged(Item disitem, int count);
    public OnitemChanged onitemchangedcallback;

    public delegate void OnitemSame(Item disitemS, int count);
    public OnitemSame onitemSamecallback;

    public delegate void OnKeyitemChanged(Item keyyitem, int count);
    public OnKeyitemChanged onkeyitemchangedcallback;


    public delegate void OnKeyitemSame(Item disitemS, int count);
    public OnKeyitemSame onKeyitemSamecallback;


    public delegate void OnOareitemChanged(Item OareItem, int count);
    public OnKeyitemChanged onOareitemchangedcallback;


    public delegate void OnOareitemsame(Item disitemS, int count);
    public OnOareitemsame OnOareitemsamecallback;

    public delegate void OnHatitemChanged(Item Hatitem, int count);
    public OnKeyitemChanged onHatitemchangedcallback;

    public delegate void OnHatitemsame(Item disitemS, int count);
    public OnHatitemsame onHatitemsamecallback;

    #endregion

    public int[] space;
    public List<Item> items = new List<Item>();
    public List<Item> Oare = new List<Item>();
    public List<Item> Hat = new List<Item>();
    public List<Item> KeyItems = new List<Item>();

    public bool Add (Item item, int count)
    {
        uimanager.UIinstance.Updateslotsgen();
        if (!item.isdefault)
        {
            if (items.Count >= space[0])
            {
                Debug.Log("Inventory full");
                return false;
            }

            if (items.Contains(item))
            {
                if (onitemSamecallback != null)
                {
                    onitemSamecallback.Invoke(item, count);
                }
            }
            else
            {
                items.Add(item);

                if (onitemchangedcallback != null)
                {
                    onitemchangedcallback.Invoke(item, count);

                }
            }

        }
        return true;
    }
    public bool AddOare(Item item , int count)
    {
        uimanager.UIinstance.Updateslotsgen();

        if (!item.isdefault)
        {
            if (Oare.Count >= space[1])
            {
                Debug.Log("Inventory full");
                return false;
            }

            if (Oare.Contains(item))
            {
                if(OnOareitemsamecallback != null)
                {
                    OnOareitemsamecallback.Invoke(item, count);
                }
            }
            else
            {
                Oare.Add(item);

                if (onOareitemchangedcallback != null)
                {
                    onOareitemchangedcallback.Invoke(item, count);

                }
            }

           

        }
        return true;
    }

  
    public bool AddHat(Item item, int count)
    {
        uimanager.UIinstance.Updateslotsgen();

        if (!item.isdefault)
        {
            if (Hat.Count >= space[2])
            {
                Debug.Log("Inventory full");
                return false;
            }

            if (Hat.Contains(item))
            {
                if (onHatitemsamecallback != null)
                {
                    onHatitemsamecallback.Invoke(item, count);
                }
            }
            else
            {
                Hat.Add(item);

                if (onHatitemchangedcallback != null)
                {
                    onHatitemchangedcallback.Invoke(item, count);

                }
            }

        }
        return true;
    }

    public bool AddKey(Item item, int count)
    {
        uimanager.UIinstance.Updateslotsgen();

        if (!item.isdefault)
        {
            if (KeyItems.Count >= space[3])
            {
                Debug.Log("Inventory full");
                return false;
            }

            if (KeyItems.Contains(item))
            {
                if (onKeyitemSamecallback != null)
                {
                    onKeyitemSamecallback.Invoke(item, count);
                }
            }
            else
            {
                KeyItems.Add(item);

                if (onkeyitemchangedcallback != null)
                {
                    onkeyitemchangedcallback.Invoke(item, count);

                }
            }

        }
        return true;
    }
    public void Remove(Item item)
    {
        switch (item.Type)
        {
            case Item.type.Disposeable:
                items.Remove(item);

                break;
            case Item.type.Oare:
                Oare.Remove(item);
                break;
            case Item.type.Hat:
                Hat.Remove(item);
                break;
            case Item.type.Keyitem:
                KeyItems.Remove(item);
                break;
          
        }

        //if (onitemchangedcallback != null)
        //{
        //    onitemchangedcallback.Invoke(item);

        //}
    }


}
