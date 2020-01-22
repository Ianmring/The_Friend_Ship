using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class camscript : MonoBehaviour {

    // Use this for initialization

  public Transform character;
  public  Camera cam;

   public Transform targettrans = null;
    public float TargetZoom;

    public Vector3 offsetI;
    public Vector3 AngleI;

    public bool isfollwoing;

    public float smoothspeed = 0.125f;

    public float size;

    public Image Transition;
    
    
    //public Quaternion offsetangel;
    void Start () {
        cam = GetComponent<Camera>();
        cam.nearClipPlane = -100;
        character = FindObjectOfType<movement>().GetComponent<Transform>();
        transform.position = character.transform.position + offsetI;
    }
	
	// Update is called once per frame
	void FixedUpdate () {


       
        transform.eulerAngles = AngleI;
      
        if (isfollwoing) {
            Vector3 desiredpos = character.transform.position + offsetI;
            Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothspeed);
            float smoothzoom = Mathf.Lerp(cam.orthographicSize, TargetZoom, .2f);
            cam.orthographicSize = smoothzoom;
            transform.position = smoothedpos;
        } else if (targettrans != null){
            Vector3 smoothtrans = Vector3.Lerp(transform.position, targettrans.position + offsetI, .1f);
            transform.position = smoothtrans;
            float smoothzoom = Mathf.Lerp(cam.orthographicSize, TargetZoom, .2f);
            cam.orthographicSize = smoothzoom;
        } 
       
       




    }

    public void CamOver(Transform trans, float Zoom, int rend, bool follow) {
        isfollwoing = follow;
        targettrans = trans;
        TargetZoom = Zoom;

        if (rend == 3) {
            cam.cullingMask = 1 << 9 | 1 << 8 | 1 << 10 | 1<<11 ;
        } else if (rend == 2) {
            cam.cullingMask = 1 << 9 | 1 << 10 | 1 << 11;

        } else {
            cam.cullingMask = -1;
        }


    }
    public void Normal() {
        targettrans = null;
        TargetZoom = 8;
        isfollwoing = true;
        cam.cullingMask = -1;

    }
    
    public void FadeIn() {
        StartCoroutine("FadeIN");
    }
    public void FadeOut() {
        movement.MovInstance.move = false;
        Transition.GetComponent<Animator>().SetTrigger("OUT");

    }

    IEnumerator FadeIN() {
        Transition.GetComponent<Animator>().SetTrigger("IN");
        yield return new WaitForSeconds(1.5f);
        if (!DiolaugeManager.DioInstance.indio) {
            movement.MovInstance.move = true;

        }

    }
}
