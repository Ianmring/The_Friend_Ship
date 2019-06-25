using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLauncher : MonoBehaviour
{
    // Start is called before the first frame update
     float Dir1H;

     float Dir1V;

     float Dir2H;

     float Dir2V;

     float Yvect1;
     float Yvect2;

    public float delta;

    movement dirData;

    public bool sett;
    bool fire;
    bool update;
    public bool isempty { get; set; }
   // public Transform Player;

    public Rigidbody rocketPrefab { get; set; }
    public PersonalItemSlot Slot;
    float DirVTotal;
    float DirHTotal;
    float DirVTotal2;
    float DirHTotal2;
    public float dirTotal;


    public float Ready1;
    public float Ready2;

    public float launchMulti;
    public float uplaunchMulti;
   // public inventorygeneral invt;

    public Vector3 Dir;
    public float Yvect;

    public launcher P1 { get; set; }
    public launcher P2 { get; set; }

    public inventorygeneral p1I;
    public inventorygeneral p2I;


    public enum Playerturn { p1,p2};

   public Playerturn Turn;

    public bool isready { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        dirData = GameObject.FindObjectOfType<movement>();
     //   Player = GetComponentInParent<Transform>();
        fire = true;
        Slot = null;

        dirData.ML = this;

        
        Turn = Playerturn.p1;
       // updateLauncher();
        // switchPlayers();
        //invt = p1I;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.MovInstance.PlayersSet)
        {
             Dir1H = P1.DirH;
        //    Dir2H = Input.GetAxis("Horizontal_P" + dirData.p2.ToString() + "_Launch");
        Dir1V = P1.DirV;
        Dir2H = P2.DirH;
        //    Dir2H = Input.GetAxis("Horizontal_P" + dirData.p2.ToString() + "_Launch");
        Dir2V = P2.DirV;
        Ready1 = P1.Ready;
        Ready2 = P2.Ready;


        Yvect1 = (Mathf.Atan2(Dir1V, Dir1H) / Mathf.PI);
        Yvect2 = (Mathf.Atan2(Dir2V, Dir2H) / Mathf.PI);

        DirHTotal = Mathf.Abs(Dir1H);
        DirVTotal = Mathf.Abs(Dir1V);
        DirHTotal2 = Mathf.Abs(Dir2H);
        DirVTotal2 = Mathf.Abs(Dir2V);

        dirTotal = (DirHTotal + DirVTotal + DirHTotal2 + DirVTotal2) / 4;


        if (Slot == null)
        {
            return;
        }
        else if (!DiolaugeManager.DioInstance.indio)
        {

            if (Mathf.Abs(Yvect1 - Yvect2) < delta && Mathf.Abs(Yvect1) > 0 && Mathf.Abs(Yvect2) > 0)
            {



                transform.eulerAngles = new Vector3(0f, (Mathf.Atan2(Dir1V + Dir2V, Dir1H + Dir2H) * 180 / Mathf.PI), 0f);
                sett = true;


            }
            else
            {
                
                transform.localEulerAngles = transform.localEulerAngles;
                sett = false;
            }



            if (dirData.move)
            {
                switch (Turn)
                {
                    case Playerturn.p1:

                        if (Ready1 == 1 && sett && !fire && !isempty)
                        {


                            if ( rocketPrefab == null)
                            {
                                return;
                            }
                            else
                            {
                                if (Slot.iskeyitem == false || Slot.isitem)
                                {
                                    Rigidbody rocketInstance;
                                    rocketInstance = Instantiate(rocketPrefab, transform.position, transform.rotation) as Rigidbody;
                                    rocketInstance.AddForce(transform.right * dirTotal * launchMulti);
                                        updateLauncher();
                                        fire = true;
                                    update = true;

                                }
                                //else
                                //{
                                //    Slot.dosomething();

                                //    fire = true;
                                //    update = true;
                                //}

                            }

                        }

                        else if (Ready1 == 0)
                        {

                            fire = false;
                            if (update == true)
                            {
                                
                                    p1I.Subinvt();


                                    //Bring back if not working anymore (5/29/19)
                                    // invt.Update_Slots();
                                    switchPlayers();

                                    update = false;
                                



                            }


                        }
                        break;


                    case Playerturn.p2:
                     //   invt = P2.invt;

                        if (Ready2 == 1 && sett && !fire && !isempty)
                        {


                            if (rocketPrefab == null)
                            {
                                return;
                            }
                            else
                            {
                                if (Slot.iskeyitem == false || Slot.isitem)
                                {
                                    Rigidbody rocketInstance;
                                    rocketInstance = Instantiate(rocketPrefab, transform.position, transform.rotation) as Rigidbody;
                                    rocketInstance.AddForce(transform.right * dirTotal * launchMulti);
                                        updateLauncher();
                                        fire = true;
                                    update = true;

                                }


                            }

                        }

                        else if (Ready2 == 0)
                        {

                            fire = false;
                            if (update == true)
                            {
                              
                                    p2I.Subinvt();


                                    //Bring back if not working anymore (5/29/19)
                                    // invt.Update_Slots();
                                    switchPlayers();

                                    update = false;
                                



                            }

                        }
                        break;
                   
                }
               



            }
        }
        }
       
    }

   
    void switchPlayers()
    {
        switch (Turn)
        {
            case Playerturn.p1:
                Turn = Playerturn.p2;
                updateLauncher();
                break;
            case Playerturn.p2:
                Turn = Playerturn.p1;
                updateLauncher();
                break;
        }
    }
    public void updateLauncher()
    {
        if (isready)
        {
            if (p1I.Personal_Slots.Count <= 0 && Turn == Playerturn.p1)
            {
                rocketPrefab = null;
                Slot = null;
                return;
            }
            else if (p2I.Personal_Slots.Count <= 0 && Turn == Playerturn.p2)
            {
                rocketPrefab = null;
                Slot = null;
                return;
            }
            else
            {
                switch (Turn)
                {
                    case Playerturn.p1:
                        //Turn = Playerturn.p2;
                        rocketPrefab = p1I.Personal_Slots[p1I.currentitem].OBJ.GetComponent<Rigidbody>();
                        Slot = p1I.Personal_Slots[p1I.currentitem];
                        break;
                    case Playerturn.p2:
                        //  Turn = Playerturn.p1;
                        rocketPrefab = p2I.Personal_Slots[p2I.currentitem].OBJ.GetComponent<Rigidbody>();
                        Slot = p2I.Personal_Slots[p2I.currentitem];
                        break;
                }
            }
        }
      //  Debug.Log("LauncherUpdated");
    }
}
