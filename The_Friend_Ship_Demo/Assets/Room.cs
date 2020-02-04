using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Room : MonoBehaviour
{
    camscript cam;
    public List<GameObject> Objectsoutarea;

    BoxCollider Colide;

    public GameObject Center;

    public GameObject Barrier;
    

    bool inroom;

    public Vector3 EntrenceScale;


    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<camscript>();
        Colide = this.GetComponent<BoxCollider>();
        
    }
  

    private void Update() {

      
    }
    private void OnTriggerEnter(Collider other) {
                   

        if (other.gameObject.GetComponent<movement>()) {
            if (!inroom) {
             
                StartCoroutine("ZoomStart");
          

            } else {
                StartCoroutine("ZoomExit");
            }
          
           
        }
       
    }
 
    IEnumerator ZoomStart() {

     

        cam.FadeOut();

        yield return new WaitForSeconds(2);

        Center.SetActive(true);
        if (Objectsoutarea != null) {
            foreach (var item in Objectsoutarea) {
                item.SetActive(false);
            }
        }
        Barrier.SetActive(false);

        inroom = true;
        Colide.size = EntrenceScale;
        cam.CamOver(Center.transform, 7, 3, false);
        cam.character.transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z+3);
        yield return new WaitForSeconds(2);

        cam.FadeIn();
    }

    IEnumerator ZoomExit() {
        cam.FadeOut();

        yield return new WaitForSeconds(2);

        Center.SetActive(false);
        if (Objectsoutarea != null) {
            foreach (var item in Objectsoutarea) {
                item.SetActive(true);
            }
        }
        Barrier.SetActive(true);

        inroom = false;
        Colide.size = Colide.size = new Vector3(2, 4, 2);
        cam.Normal();
        cam.character.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
        yield return new WaitForSeconds(2);

        cam.FadeIn();
    }
}
