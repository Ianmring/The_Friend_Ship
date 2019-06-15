using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmission : MonoBehaviour {

    // Use this for initialization

   // MissionMan missh;

    public bool Beathit;
	void Start () {
       // missh = GetComponentInParent<MissionMan>();
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        Beathit = true;

    }
}
