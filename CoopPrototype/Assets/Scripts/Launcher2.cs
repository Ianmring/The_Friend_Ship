using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher2 : MonoBehaviour
{
    // public int contdir;
    public float Dir1H;

    public float Dir1V;

    movement dirData;

    bool sett;
    bool fire;

    public Transform Player;

    public Rigidbody rocketPrefab;

    float DirVTotal;
    float DirHTotal;

    public float dirTotal;


    float Ready;

    public float launchMulti;


    Vector3 Dir;

    playerselect playa;

    //public Vector3 Dir;
    // Start is called before the first frame update
    void Start()
    {
        playa = FindObjectOfType<playerselect>();
        dirData = GameObject.FindObjectOfType<movement>();
        Player = GetComponentInParent<Transform>();
        fire = true;
    }

    // Update is called once per frame
    void Update()
    {
        Dir1H = Input.GetAxis("Horizontal_P" + playa.p2.ToString() + "_Launch");
        //    Dir2H = Input.GetAxis("Horizontal_P" + dirData.p2.ToString() + "_Launch");
        Dir1V = Input.GetAxis("Vertical_P" + playa.p2.ToString() + "_Launch");
        Ready = Input.GetAxis("Player_" + playa.p2.ToString() + "_Aim");
        //Mathf.Abs(Dir1H);
        //Mathf.Abs(Dir1V);
        DirHTotal = Mathf.Abs(Dir1H);
        DirVTotal = Mathf.Abs(Dir1V);




        //   Dir2V = Input.GetAxis("Vertical_P" + dirData.p2.ToString() + "_Launch");

        dirTotal = (DirHTotal + DirVTotal) / 2;

        float Yvect;

        Yvect = (Mathf.Atan2(Dir1V, Dir1H) / Mathf.PI);




        //   Dir2V = Input.GetAxis("Vertical_P" + dirData.p2.ToString() + "_Launch");




        Dir = new Vector3(0f, Yvect, 0);




        if (DirHTotal > 0.15 && DirVTotal > 0.15 || DirHTotal > 0.15 || DirVTotal > 0.15)
        {
            Player.localEulerAngles = Dir; // this does the actual rotaion according to inputs
            sett = true;
        }
        else
        {

            Player.localEulerAngles = Player.localEulerAngles;
            sett = false;
 
        }


        if (Ready == 1 && sett && !fire)
        {


            Rigidbody rocketInstance;
            rocketInstance = Instantiate(rocketPrefab, transform.position, transform.rotation) as Rigidbody;
            rocketInstance.AddForce(transform.right * dirTotal * launchMulti);
            fire = true;



        }
        else if (Ready == 0)
        {
            fire = false;

        }

    }
}
