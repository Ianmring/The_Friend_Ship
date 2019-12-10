using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiolaugeTrigger : MonoBehaviour
{

   public Diolauge Dio;

    DiolaugeManager dioman;
    public void Start() {
        dioman = FindObjectOfType<DiolaugeManager>();
    }
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<movement>()) {
            dioman.Startdio(Dio);
            gameObject.SetActive(false);

        }
    }
}
