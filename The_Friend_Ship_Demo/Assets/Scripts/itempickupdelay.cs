using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itempickupdelay : MonoBehaviour
{
    // Start is called before the first frame update

    itempickup pick;
    void Start()
    {
        pick = GetComponent<itempickup>();
        //pick.enabled = false;
        StartCoroutine("Delaypickup");
    }
    IEnumerator Delaypickup(){

        yield return new WaitForSeconds(.3f);

        pick.enabled = true;

        Destroy(this);

        }
    // Update is called once per frame
}
