using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Room : MonoBehaviour
{
    camscript cam;
 //   public List<GameObject> Objectsoutarea;

   // BoxCollider Colide;

  //  public GameObject Center;


    public GameObject room_2d;

    GameObject roomscene;
   // public GameObject Barrier;
    

    bool inroom;


    //public Vector3 EntrenceScale;


    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<camscript>();
        //Colide = this.GetComponent<BoxCollider>();
        
    }
  

    private void Update() {

      
    }
    private void OnTriggerEnter(Collider other) {
                   

        if (other.gameObject.GetComponent<movement>()) {
            if (!other.gameObject.GetComponent<movement>().in2droom) {
             
                StartCoroutine("ZoomStart");
          

            } else {
                StartCoroutine("ZoomExit");
            }
          
           
        }
       
    }
 
    public void Exitroom() {
        StartCoroutine("ZoomExit");

    }
    IEnumerator ZoomStart() {

        movement.MovInstance.currentroom = this;

        cam.FadeOut();

        yield return new WaitForSeconds(2);

      
            room_2d.SetActive(true);
        

     //   Center.SetActive(true);
        //if (Objectsoutarea != null) {
        //    foreach (var item in Objectsoutarea) {
        //        item.SetActive(false);
        //    }
        //}
      //  Barrier.SetActive(false);

        movement.MovInstance.in2droom = true;
      //  Colide.size = EntrenceScale;
     //   cam.CamOver(Center.transform, 10, 3, false);
       // cam.character.transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z+3);
        yield return new WaitForSeconds(2);

        cam.FadeIn();
    }

    IEnumerator ZoomExit() {

        movement.MovInstance.currentroom = null;

        cam.FadeOut();

        yield return new WaitForSeconds(2);

        room_2d.SetActive(false);

        //Center.SetActive(false);
        //if (Objectsoutarea != null) {
        //    foreach (var item in Objectsoutarea) {
        //        item.SetActive(true);
        //    }
        //}
        //// Barrier.SetActive(true);

        movement.MovInstance.in2droom = false;
       // Colide.size = Colide.size = new Vector3(0.1f, 1, 0.1f);
   //     cam.Normal();
       cam.character.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 3);
        yield return new WaitForSeconds(2);

        cam.FadeIn();
    }
}
