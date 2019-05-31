using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camscript : MonoBehaviour {

    // Use this for initialization

   Transform character;
    Camera cam;
    public Vector3 offset;
    public Vector3 Angle;

    public Vector3 offsetI;
    public Vector3 AngleI;

    public bool iso; 
    //public Quaternion offsetangel;
    void Start () {
        cam = GetComponent<Camera>();
        character = FindObjectOfType<movement>().GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (iso)
        {
            cam.orthographic = true;
            cam.nearClipPlane = -100;
            transform.position = character.transform.position + offsetI;

            transform.eulerAngles = AngleI;

        }
        else
        {
            cam.orthographic = false;
            cam.nearClipPlane = 0.01f;
            transform.position = character.transform.position + offset;

            transform.eulerAngles = Angle;
            //transform.rotation = offsetangel;
        }

	}
}
