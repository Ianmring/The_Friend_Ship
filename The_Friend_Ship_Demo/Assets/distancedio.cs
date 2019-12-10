using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distancedio : MonoBehaviour
{
    // Start is called before the first frame update

    public Diolauge dio;
    DiolaugeManager dioman;
    public void Start() {
        dioman = FindObjectOfType<DiolaugeManager>();
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other) {
       
        if (other.gameObject.GetComponent<movement>()) {
       dioman.Startdio(dio);
            gameObject.SetActive(false);

        }
    }
}
