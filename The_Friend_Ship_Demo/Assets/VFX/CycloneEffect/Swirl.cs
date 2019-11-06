using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swirl : MonoBehaviour {
    public float Speed = 5.0f;
	
	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(Vector3.up * Speed);
	}
}
