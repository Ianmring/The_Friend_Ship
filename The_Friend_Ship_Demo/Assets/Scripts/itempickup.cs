﻿
using UnityEngine;

public class itempickup : Interactable
{
    // Start is called before the first frame update

    public Item item;
    public override void Interact()
    {
        if (this.enabled)
        {
            Pickup();

        }



        base.Interact();

    }

    public void Pickup()
    {
        Inventory invt;
        inventorygeneral p1;
        inventorygeneral p2;

        p1 = movement.MovInstance.p1I;
        p2 = movement.MovInstance.p2I;
        invt = Inventory.instance;


       
          

                #region keyitemcheck
              
                if (p1.Keyitem == item)
                {
                    //for (int i = 0; i < p1.Personal_Slots.Count; i++)
                    //{
                    //    if (item == p1.Personal_Slots[i].currentitem)
                    //    {
                    //        return;
                    //    }

                    //}

                    return;
                }
                else if (p2.Keyitem == item)
                {
                    //for (int i = 0; i < p2.Personal_Slots.Count; i++)
                    //{
                    //    if (item == p2.Personal_Slots[i].currentitem)
                    //    {
                    //        return;
                    //    }
                    //}
                    return;
                  
                }
                else
                {
                    for (int i = 0; i < invt.KeyItems.Count; i++)
                    {
                        if (item == invt.KeyItems[i])
                        {
                            return;
                        }
                    }
                    bool waspickedupK = Inventory.instance.AddKey(item, 1);
                    if (waspickedupK)
                    {
                gameObject.SetActive(false);
                        return;
                    }
                }
                

                #endregion


          
        }


    }

