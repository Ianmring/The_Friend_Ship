using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    // public int contdir;
    public float DirH;

    public float DirV;

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
    public float IReady;


    public float launchMulti;
    public float uplaunchMulti;
public    inventorygeneral invt;

    public Vector3 Dir;
    Playergen playa;
    public float Yvect;

    MainLauncher mainL;
    // Start is called before the first frame update
    void Start()
    {


        playa = GetComponent<Playergen>();
        dirData = GameObject.FindObjectOfType<movement>();
        Player = GetComponent<Transform>();
        fire = true;
        playernumref = playa.playernum;
        invt = GetComponent<inventorygeneral>();
        Slot = null;

        mainL = FindObjectOfType<MainLauncher>();
        mainL.isready = false;
     //   mainL.Addlauncher(this);

        if (playa.direction == 0)
        {
            dirData.P1F = this;
            mainL.P1 = this;
            mainL.p1I = invt;
        }
        if (playa.direction == 1)
        {
            dirData.P2F = this;
            mainL.P2 = this;
            mainL.p2I = invt;
        }
        mainL.isready = true;
    }


    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0f, Mathf.Atan2(DirV, DirH) * 180 / Mathf.PI, 0f); // this does the actual rotaion according to inputs

        if (!GetComponentInParent<Playergen>().isdemo)
        {
            DirH = Input.GetAxis("Horizontal_P" + playa.playernum.ToString() + "_Launch");
            //    Dir2H = Input.GetAxis("Horizontal_P" + dirData.p2.ToString() + "_Launch");
            DirV = Input.GetAxis("Vertical_P" + playa.playernum.ToString() + "_Launch");
            Ready = Input.GetAxis("Player_" + playa.playernum.ToString() + "_Aim");
            IReady = Input.GetAxis("Player_" + playa.playernum.ToString() + "_Key");
            DirHTotal = Mathf.Abs(DirH);
            DirVTotal = Mathf.Abs(DirV);

           // dirTotal = (DirHTotal + DirVTotal) / 2;



            Yvect = transform.eulerAngles.y;


          //  Dir = new Vector3(0f, Yvect, 0);

                }
            }
        }
//    }
//}
