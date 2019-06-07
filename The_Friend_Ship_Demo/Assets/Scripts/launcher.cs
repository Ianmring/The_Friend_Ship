using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    // public int contdir;
    public float Dir1H;

    public float Dir1V;

    public int playernumref;

    movement dirData;

    bool sett;
    bool fire;
    bool update;
    public bool isempty { get; set; }
    public Transform Player;

    public Rigidbody rocketPrefab;
    public PersonalItemSlot Slot;
    float DirVTotal;
    float DirHTotal;

    public float dirTotal;


    public float Ready;

    public float launchMulti;
    public float uplaunchMulti;
    inventorygeneral invt;

    public Vector3 Dir;
    Playergen playa;
    public float Yvect;
    // Start is called before the first frame update
    void Start()
    {
        playa = GetComponentInParent<Playergen>();
        dirData = GameObject.FindObjectOfType<movement>();
        Player = GetComponentInParent<Transform>();
        fire = true;
        playernumref = playa.playernum;
        invt = GetComponentInParent<inventorygeneral>();
        Slot = null;

        if (playa.direction == 0)
        {
            dirData.P1F = this;
        }
        if (playa.direction == 1)
        {
            dirData.P2F = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!GetComponentInParent<Playergen>().isdemo)
        {
            Dir1H = Input.GetAxis("Horizontal_P" + playa.playernum.ToString() + "_Launch");
            //    Dir2H = Input.GetAxis("Horizontal_P" + dirData.p2.ToString() + "_Launch");
            Dir1V = Input.GetAxis("Vertical_P" + playa.playernum.ToString() + "_Launch");
            Ready = Input.GetAxis("Player_" + playa.playernum.ToString() + "_Aim");


            //Mathf.Abs(Dir1H);
            //Mathf.Abs(Dir1V);
            DirHTotal = Mathf.Abs(Dir1H);
            DirVTotal = Mathf.Abs(Dir1V);

            dirTotal = (DirHTotal + DirVTotal) / 2;



            Yvect = (Mathf.Atan2(Dir1V, Dir1H) / Mathf.PI);




            //   Dir2V = Input.GetAxis("Vertical_P" + dirData.p2.ToString() + "_Launch");




            Dir = new Vector3(0f, Yvect, 0);


            if (Slot == null)
            {
                return;
            }
            else if (!DiolaugeManager.DioInstance.indio)
            {

                if (DirHTotal > 0.15 && DirVTotal > 0.15 || DirHTotal > 0.15 || DirVTotal > 0.15)
                {
                    if (!uimanager.UIinstance.isopen && Slot.iskeyitem && Slot != null)
                    {
                        Slot.dosomething();

                    }


                    Player.localEulerAngles = Dir; // this does the actual rotaion according to inputs
                    sett = true;


                }
                else
                {
                    if (!uimanager.UIinstance.isopen && Slot.iskeyitem && Slot != null)
                    {
                        Slot.DontDoSomething();

                    }
                    Player.localEulerAngles = Player.localEulerAngles;
                    sett = false;
                }

                if (dirData.move)
                {
                    if (Ready == 1 && sett && !fire && !isempty)
                    {


                        if (rocketPrefab == null)
                        {
                            return;
                        }
                        else
                        {
                            if (Slot.iskeyitem == false)
                            {
                                Rigidbody rocketInstance;
                                rocketInstance = Instantiate(rocketPrefab, transform.position, transform.rotation) as Rigidbody;
                                rocketInstance.AddForce(transform.right * dirTotal * launchMulti);
                                invt.Update_Slots();
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

                    else if (Ready == 0)
                    {

                        fire = false;
                        if (update == true)
                        {
                            if (Slot.iskeyitem == false)
                            {

                                invt.Subinvt();


                                //Bring back if not working anymore (5/29/19)
                                // invt.Update_Slots();
                                update = false;
                            }



                        }


                    }



                }
            }
        }
    }
}
