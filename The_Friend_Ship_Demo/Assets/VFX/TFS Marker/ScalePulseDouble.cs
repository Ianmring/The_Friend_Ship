using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePulseDouble : MonoBehaviour {
	public float ChangeScale = 1.0f;
	private float MarkerStart = 0.0f;
	private float MarkerCurrent = 0.0f;
	public GameObject MarkerTarget;
	public float currentTime = 0.0f;
	private float pi = Mathf.PI;
	private float bounceInterval = 0.0f;
	
	void Start () {
		currentTime = Time.time;
		bounceInterval = (2 * pi) / 3;
		//MarkerStart = MarkerTarget.GetComponent<Bounce>().MarkerInitY;
    }
	
	void Update () {
		currentTime = Time.time;
		MarkerCurrent = MarkerTarget.GetComponent<Bounce>().MarkerCurrentY;
		ChangeScale = 15f / (MarkerCurrent - MarkerStart);
        if (currentTime % bounceInterval > 0.15f && currentTime % bounceInterval < 1.1f) {
            transform.localScale = new Vector3(ChangeScale, ChangeScale, ChangeScale);
        }
    }
}
