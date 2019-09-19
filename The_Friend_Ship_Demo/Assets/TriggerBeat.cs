using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBeat : MonoBehaviour
{
    // Start is called before the first frame update

    bool isready;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<movement>())
        {
            isready = true;

        }
    }
    private void Update()
    {
       
            if (Input.GetButtonDown("Submit") )
            {
                if (!GetComponent<MissionBeat>().isdone && isready && !GetComponent<MissionBeat>().mana.collectprize)
                {
                    this.gameObject.GetComponent<MissionBeat>().Beat();
                    Destroy(this);
                }
               
                //Destroy(this);
            }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
            isready = false;

        
    }
}
