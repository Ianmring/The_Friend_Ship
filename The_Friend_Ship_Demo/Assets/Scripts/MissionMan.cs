using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMan : MonoBehaviour {

    // Use this for initialization

   public int missonnum;

    public gameman man;
    public bool isstartingmission;

    public GameObject target;

    int targettile;
	void Start () {
        man = FindObjectOfType<gameman>();
    }
   
	
	// Update is called once per frame

    public  void Mission1()
    {

        if (isstartingmission)
        {
            Debug.Log("Startmission 1");
        }
        


    }
    public void Mission2()
    {

        if (isstartingmission)
        {

            Debug.Log("Startmission 2");
            generatenumber();

            GameObject objective;
//objective = Instantiate(target, new Vector3(man.Platesco[targettile].x ,man.Platesco[targettile].y, man.Platesco[targettile].z), transform.rotation);
            isstartingmission = false;
                }


    }
    void Update () {
        switch (missonnum)
        {
            case 1:
                Mission1();
                break;
            case 2:
                Mission2();
                break;
            default:
                break;
        }
    }

    public void generatenumber()
    {
    //    targettile = Random.Range(0, man.Platesco.Count);
    }
}
