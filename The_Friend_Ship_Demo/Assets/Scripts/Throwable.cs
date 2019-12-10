using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    float Launchmulit;
    // Start is called before the first frame update
    void Start()
    {
        Launchmulit = 1000;
    }

    // Update is called once per frame
 

    public void Dothething()
    {

        if (GetComponentInParent<KeyitemTrigger>().PL.IReady == 1 )
        {
            PersonalItemSlot slot;
            GameObject obj;
            Rigidbody rid;
            slot = GetComponent<PersonalItemSlot>();
            obj = slot.currentitem.OBJ;
            rid = obj.GetComponent<Rigidbody>();
            

            Rigidbody rig;
            //rig = Instantiate(rid, FindObjectOfType<MainLauncher>().transform.position, FindObjectOfType<MainLauncher>().transform.rotation) as Rigidbody;
            //rig.AddForce(FindObjectOfType<MainLauncher>().transform.right * Launchmulit);
          //  slot.invt.TriggerItem.ClearItem();
            Destroy(this.gameObject);
        } 

    }
    
}
