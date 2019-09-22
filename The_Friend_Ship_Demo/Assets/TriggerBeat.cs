using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBeat : MonoBehaviour
{
    // Start is called before the first frame update

    bool isready;
    bool p1;
    bool p2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<movement>())
        {
            isready = true;

        }
    }
    private void Update()
    {
        if (isready)
        {
            if (Input.GetButtonDown("Submit1"))
            {
                p1 = true;

            }
            if (Input.GetButtonDown("Submit2"))
            {
                p2 = true;
            }
            if (p1 && p2)
            {
                if (!GetComponent<MissionBeat>().isdone && !GetComponent<MissionBeat>().mana.collectprize)
                {
                    this.gameObject.GetComponent<MissionBeat>().Beat();
                    Destroy(this);
                }

                //Destroy(this);
            }
        }
       
        
    }

    private void OnTriggerExit(Collider other)
    {
        
            isready = false;

        
    }
}
