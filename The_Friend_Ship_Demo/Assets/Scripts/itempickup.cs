
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

        p1 = movement.MovInstance.P1F.invt;
        p2 = movement.MovInstance.P2F.invt;
        invt = Inventory.instance;


        switch (item.Type)
        {
            case Item.type.Disposeable:
                bool waspickedup = Inventory.instance.Add(item, 1);
                if (waspickedup)
                {
                    Destroy(this.gameObject);

                }
                break;
            case Item.type.Oare:
                bool waspickedupO = Inventory.instance.AddOare(item, 1);
                if (waspickedupO)
                {
                    Destroy(this.gameObject);

                }
                break;
            case Item.type.Hat:
                bool waspickedupH = Inventory.instance.AddHat(item, 1);
                if (waspickedupH)
                {
                    Destroy(this.gameObject);

                }

                break;
            case Item.type.Keyitem:

                #region keyitemcheck
                for (int i = 0; i < p1.Personal_Slots.Count; i++)
                {
                    if (item == p1.Personal_Slots[i].currentitem)
                    {
                        return;
                    }

                }
                for (int i = 0; i < p2.Personal_Slots.Count; i++)
                {
                    if (item == p2.Personal_Slots[i].currentitem)
                    {
                        return;
                    }
                }
                for (int i = 0; i < invt.KeyItems.Count; i++)
                {
                    if (item == invt.KeyItems[i])
                    {
                        return;
                    }
                }
                #endregion

                bool waspickedupK = Inventory.instance.AddKey(item, 1);
                if (waspickedupK)
                {
                    Destroy(this.gameObject);

                }
                break;
            default:
                break;
        }


    }
}
