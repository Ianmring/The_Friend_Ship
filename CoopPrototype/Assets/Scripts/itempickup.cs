
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
        Debug.Log("Pick up that " + item.name + " shit son, its " + item);

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
