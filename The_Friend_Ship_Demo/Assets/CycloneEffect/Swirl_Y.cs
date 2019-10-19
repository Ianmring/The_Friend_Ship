using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swirl_Y : MonoBehaviour {
    public float Speed = 5.0f;
	
	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(Vector3.forward * Speed);
	}
}
