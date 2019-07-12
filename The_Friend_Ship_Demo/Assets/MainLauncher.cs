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

   public  float Yvect1;
     public float Yvect2;

    public float delta;

    movement dirData;

    public bool sett;
    bool fire;
    bool update;
//    public bool isempty { get; set; }
   // public Transform Player;

   // public PersonalItemSlot Slot;
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


    public enum TurretDir { Up, Down, Left, Right, Upleft, UpRight, Downleft, DownRight ,not};

    public TurretDir turdir;
    public bool isready { get; set; }

    public float dirtotal;

  public  bool p1set;
    public bool p2set;

    // Start is called before the first frame update
    void Start()
    {
        dirData = GameObject.FindObjectOfType<movement>();
     //   Player = GetComponentInParent<Transform>();
        fire = true;
        //Slot = null;

        dirData.ML = this;

        //p1set = true;
        //p2set = true;
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

            dirtotal = Mathf.Atan2(Dir1V + Dir2V, Dir1H + Dir2H) / Mathf.PI;

            if (p1set && p2set && sett)
            {


                Debug.Log("hit");

            }
            if (Ready1 == 1 )
            {

                StartCoroutine("P1swing");
            }
           
            if (Ready2 == 1 )
            {
                StartCoroutine("P2swing");
            }
          
        
           if (!DiolaugeManager.DioInstance.indio)
        {

                if (Mathf.Abs(Yvect1 - Yvect2) < delta && Mathf.Abs(Yvect1) > 0 && Mathf.Abs(Yvect2) > 0)
                {
                    #region launchertrack

                    if ((Yvect1 < -0.375 && Yvect1 > -0.625) && (Yvect2 < -0.375 && Yvect2 > -0.625))
                    {
                        turdir = TurretDir.Up;
                    }
                    if ((Yvect1 < 0.625 && Yvect1 > 0.375) && (Yvect2 < 0.625 && Yvect2 > 0.375))
                    {
                        turdir = TurretDir.Down;
                    }
                    if ((Yvect1 < 0.125 && Yvect1 > -0.125) && (Yvect2 < 0.125 && Yvect2 > -0.125))
                    {
                        turdir = TurretDir.Right;
                    }
                    if ((Yvect1 < -0.125 && Yvect1 > -0.375) && (Yvect2 < 0.125 && Yvect2 > -0.375))
                    {
                        turdir = TurretDir.UpRight;
                    }
                    if ((Yvect1 < -0.625 && Yvect1 > -0.875) && (Yvect2 < -0.625 && Yvect2 > -0.875))
                    {
                        turdir = TurretDir.Upleft;
                    }
                    if ((Yvect1 > -0.875 && Yvect1 > 0.875) && (Yvect2 > -0.875 && Yvect2 > 0.875))
                    {
                        turdir = TurretDir.Left;
                    }
                    if ((Yvect1 < 0.875 && Yvect1 > 0.625) && (Yvect2 < 0.875 && Yvect2 > 0.625))
                    {
                        turdir = TurretDir.Downleft;
                    }
                    if ((Yvect1 < 0.875 && Yvect1 > 0.625) && (Yvect2 < 0.875 && Yvect2 > 0.625))
                    {
                        turdir = TurretDir.Downleft;
                    }
                    if ((Yvect1 < 0.375 && Yvect1 > 0.125) && (Yvect2 < 0.375 && Yvect2 > 0.125))
                    {
                        turdir = TurretDir.DownRight;
                    }


                    switch (turdir)
                    {
                        case TurretDir.Up:
                            transform.eulerAngles = new Vector3(0f, -90, 0f);

                            break;
                        case TurretDir.Down:
                            transform.eulerAngles = new Vector3(0f, 90, 0f);

                            break;
                        case TurretDir.Left:
                            transform.eulerAngles = new Vector3(0f, -180, 0f);

                            break;
                        case TurretDir.Right:
                            transform.eulerAngles = new Vector3(0f, 0, 0f);

                            break;
                        case TurretDir.Upleft:
                            transform.eulerAngles = new Vector3(0f, -132, 0f);

                            break;
                        case TurretDir.UpRight:
                            transform.eulerAngles = new Vector3(0f, -45, 0f);

                            break;
                        case TurretDir.Downleft:
                            transform.eulerAngles = new Vector3(0f, 132, 0f);

                            break;
                        case TurretDir.DownRight:
                            transform.eulerAngles = new Vector3(0f, 45, 0f);

                            break;
                        case TurretDir.not:
                            break;
                        default:
                            break;
                    }

                    #endregion

                    //transform.eulerAngles = new Vector3(0f, (Mathf.Atan2(Dir1V + Dir2V, Dir1H + Dir2H) * 180 / Mathf.PI), 0f);
                    sett = true;
                }
                else
                {

                  //  transform.localEulerAngles = transform.localEulerAngles;
                    turdir = TurretDir.not;
                    sett = false;
                }
                



            }
        }
        }
    IEnumerator P1swing()
    {
        //p1set = true;
        p1set = true;

        yield return new WaitForSeconds(.1f);
        Debug.Log("done");
        p1set = false;

    }
    IEnumerator P2swing()
    {
        p2set = true;

        yield return new WaitForSeconds(.1f);
        //    p2set = true;
        Debug.Log("done");
        p2set = false;
    }

}



