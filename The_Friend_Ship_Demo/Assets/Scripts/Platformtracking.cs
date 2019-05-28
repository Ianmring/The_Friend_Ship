using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformtracking : MonoBehaviour {

   // public endlessworld currplat;

    public Vector3 playerv3;
    public Vector3 planev3;

    public float disx;
    public float disz;


    gameman man;
    // Use this for initialization
    void Start () {
        man = FindObjectOfType<gameman>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
       // currplat = other.GetComponent<endlessworld>();

        planev3 = other.transform.position;
        playerv3 = transform.position;

        //man.distnacex =  playerv3.x-planev3.x;
        //man.distancez =   playerv3.z-planev3.z;
    }
}
