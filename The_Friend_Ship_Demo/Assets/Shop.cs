using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Shop : Interactable
{
    // Start is called before the first frame update
    public Diolauge StoreDio;

    // Update is called once per frame
    public override void Interact()
    {
        uimanager mana;
        mana = uimanager.UIinstance;
       // Debug.Log("did");
        if (this.enabled)
        {
            mana.Shopupdate();
        }

        base.Interact();
    }

}
