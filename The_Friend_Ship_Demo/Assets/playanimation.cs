using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanimation : MonoBehaviour
{
    public bool ifkey;
    // Start is called before the first frame update
    void Start()
    {
        if (ifkey) {
            GetComponent<Animator>().SetTrigger("UpDownKey");

        } else {
            GetComponent<Animator>().SetTrigger("UpDown");
        }
    }

    // Update is called once per frame
   
}
