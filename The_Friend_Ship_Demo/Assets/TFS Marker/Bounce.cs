using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {
    private float Bouncefactor = 0.005f;
	private float Speed = 3.0f;
	private float ChangeScale = 1.0f;
	private float GraphOne = 1.0f;
	private float GraphTwo = 1.0f;
	private float pi = Mathf.PI;
	private float initX = 0.0f;
	public float MarkerInitY = 0.0f;
	public float MarkerCurrentY = 0.0f;
	private float initZ = 0.0f;
	
	void Start () {
		initX = transform.position.x;
		MarkerInitY = transform.position.y;
		initZ = transform.position.z;
	}
	
	void Update () {
		GraphOne = (Mathf.Sin(Speed * Time.time)+ 1.5f) *  Bouncefactor + 1;
		GraphTwo = (2 * (Mathf.Sin(Speed * Time.time + pi)) + 3.5f) * Bouncefactor + 1;
		if (GraphOne < GraphTwo){
			ChangeScale = GraphOne;
		} else {
			ChangeScale = GraphTwo;
		}
		transform.position = new Vector3(initX, MarkerInitY - (50 * ChangeScale) + 50.6f, initZ);
		MarkerCurrentY = transform.position.y;
		
	}
}
