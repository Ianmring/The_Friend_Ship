using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camscript : MonoBehaviour {

    // Use this for initialization

   Transform character;
    Camera cam;

   public Transform targettrans = null;
    public Vector3 offsetI;
    public Vector3 AngleI;

    public bool isfollwoing;

    public float smoothspeed = 0.125f;

    public float size;
    
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
            float smoothzoom = Mathf.Lerp(cam.orthographicSize, 8, .2f);
            cam.orthographicSize = smoothzoom;
            transform.position = smoothedpos;
        } else if (targettrans != null){
            Vector3 smoothtrans = Vector3.Lerp(transform.position, targettrans.position + offsetI, .1f);
            transform.position = smoothtrans;

        } else {
            return;
        }
      
       
            

   

    }
}
