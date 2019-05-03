using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipmana : MonoBehaviour
{

    // Start is called before the first frame update

    #region Singelton
    int slotindex;


    public static Equipmana instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnEquipmentChange(Equipment old, Equipment newe);
    public OnEquipmentChange onEqupmentchange;
       

    Inventory inventory;
 // public  Equipslots EquipSlotss;
   public Equipment[] currentEquip;

     void Start()
    {
        inventory = Inventory.instance;

      int numslots =  System.Enum.GetNames(typeof(Equipslots)).Length;

        currentEquip = new Equipment[numslots];
    }

    public void Equip(Equipment newitem)
    {
  
      
        switch (uimanager.UIinstance.playernums)
        {
            case uimanager.Players.player1:

                if (newitem.equipslot == EquipmentType.Hat)
                {
                    slotindex = (int)Equipslots.HatP1;
                }
                else if(newitem.equipslot == EquipmentType.Oare)
                {
                    slotindex = (int)Equipslots.OareP1;
                }
                break;
            case uimanager.Players.player2:
                if (newitem.equipslot == EquipmentType.Hat)
                {
                    slotindex = (int)Equipslots.HatP2;
                }
                else if (newitem.equipslot == EquipmentType.Oare)
                {
                    slotindex = (int)Equipslots.Oarep2;
                }

                break;
            case uimanager.Players.noone:
                break;
            default:
                break;
        }
        

        Equipment olditem = null;

       if( currentEquip[slotindex]!= null)
        {
            olditem = currentEquip[slotindex];

            switch (olditem.Type)
            {
                case Item.type.Disposeable:
                    inventory.Add(olditem, 1);
                    break;
                case Item.type.Oare:
                    inventory.AddOare(olditem,1);
                    break;
                case Item.type.Hat:
                    inventory.AddHat(olditem,1);
                    break;
                case Item.type.Keyitem:
                    inventory.AddKey(olditem,1);
                    break;
                default:
                    break;
            }
        }



       if(onEqupmentchange != null)
        {
            onEqupmentchange.Invoke(newitem, olditem);
        }




        currentEquip[slotindex] = newitem;
    }

    public void Unequip( int slotindex)
    {
        if (currentEquip[slotindex] != null)
        {
            Equipment olditem = currentEquip[slotindex];
            inventory.Add(olditem,1);

            currentEquip[slotindex] = null;




            if (onEqupmentchange != null)
            {
                onEqupmentchange.Invoke(null, olditem);
            }
        }
    }

    public void Unequipall()
    {
        for (int i = 0; i < currentEquip.Length; i++)
        {
            Unequip(i);
        }
    }

    public enum Equipslots { OareP1, Oarep2, HatP1, HatP2}
}
