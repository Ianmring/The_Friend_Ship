using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiolaugeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Diolauge diolauge;

 //   public Diolauge[] diolauges;


    public void TriggerDio()
    {
        FindObjectOfType<DiolaugeManager>().Startdio(diolauge);
    }
}
