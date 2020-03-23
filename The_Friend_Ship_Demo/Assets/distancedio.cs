using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distancedio : MonoBehaviour
{
    // Start is called before the first frame update

    public Diolauge dio;
    DiolaugeManager dioman;
    public GameObject target;
    camscript cam;
    public void Start() {
        dioman = FindObjectOfType<DiolaugeManager>();
        cam = FindObjectOfType<camscript>();
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other) {
        
        if (other.gameObject.GetComponent<movement>()) {
            Debug.Log("OUT");
            FindObjectOfType<Tutorial_Manager>().Tutorialoff();
            dioman.Startdio(dio , this.gameObject, false, false);
            // gameObject.SetActive(false);
            cam.CamOver(target.transform, 8.5f, 1, false);
            //cam.targettrans = target.transform;
            //cam.isfollwoing = false;
        }
    }

    IEnumerator Wait() {

        yield return new WaitForSeconds(1);


    }
}
