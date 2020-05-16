using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class movement : MonoBehaviour {



    // Use this for initialization
    #region Singelton
    public static movement MovInstance;

    private void Awake()
    {
        MovInstance = this;
    }

    #endregion


    //public float speed;

   // public float maxspeed;
   // public float minturnspeed;
   // public float maxturnspeed;
   //float turnspeed;

   //public float zoom;
  //  Rigidbody rig;

   public Vector3 Currentang;

    bool isbackward;
    public float[] directions;
    public float[] directionsx;
    public float[] Turnx;

    public float[] DirxM;
    public float[] DiryM;

     enum Moving { Forwad, Backwards, Not};

     enum Turning { Clockwise, AniClockwise, Not };

     enum Directions { up,  left,  down,  right}

   public enum PlayerSteering { P1,P2}

  public  PlayerSteering steer;

   // public int direction;

     Moving moving;
     Turning turning;
     Directions Dir;

   // public Slider[] Slides;

 //   public RectTransform directC;

    //public GameObject[] Handels;

    public Sprite[] imagedir;

    //public RectTransform directL;
    playerselect playa;

     float zroto;

    public inventorygeneral p1I;
   public inventorygeneral p2I;

    public Playergen P1G;
    public Playergen P2G;

  public  Animator spit;
    public float mag;

    public bool move= true;

    public bool isturning;
    public bool Solo;

    public enum playingas { Cont1, Cont2, NA}

  public  playingas playas;

    public enum controllertype { Xbox, XboxHyb, Playstation, PlaystationHyb, Keypad};

   public controllertype conttype;

    public bool altoveride;
   public int steerint;
   public int dirint;

    bool t1;

    public TextMeshProUGUI P1st;
    public TextMeshProUGUI P2st;

    public bool canswitch;

    public bool go ;

   public NavMeshAgent age;

    public bool going;

    public float currentang;

    public PlayersSelector Pointer;

    public GameObject X;

    public Image sideindie1;
    public Image sideindie2;

    public bool keyboard;

    [SerializeField]
    public bool in2droom;



    public Room currentroom;

    public string controllerL;
    void Start () {

        go = true;
        canswitch = true;
        age = GetComponent<NavMeshAgent>();
        playa = FindObjectOfType<playerselect>();
   //     rig = GetComponent<Rigidbody>();
        steer = PlayerSteering.P1;
        Switchplayerpos();

        moving = Moving.Not;
        turning = Turning.Not;
        spit = GetComponentInChildren<Animator>();
        
       // X.SetActive(false);


        //   direction = 2;

        //checkDirection();
    }

    // Update is called once per frame
    void Update () {
        spit.GetComponent<Transform>().eulerAngles = new Vector3(40, 0, 0);




            if (move && !uimanager.UIinstance.isopen) {


                //  rig.mass = 1;
                Currentang = GetComponent<Transform>().eulerAngles;
                Move();
                //Direction();

                //   rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxspeed);
                //   zoom = rig.velocity.magnitude;
               // turnspeed = zoom >= 1 ? minturnspeed : maxturnspeed;
                zroto = transform.localEulerAngles.y;
                Pointer.gameObject.SetActive(true);
            } else {

                age.destination = transform.localPosition;

                turning = Turning.Not;
                Pointer.gameObject.SetActive(false);
            spit.SetTrigger("Stop");

        }


        if (Solo && (Input.GetButtonDown(controllerL+"Swap1"))) {
            SwapPlayers();
        }
        //   spit.GetComponent<Transform>().eulerAngles = new Vector3(40, 0, 0);

        //if (turning == Turning.Not && moving == Moving.Not)
        //{
        //    isforward = false;
        //    isbackward = false;

        //}

    }

    public void SwapPlayers() {
        Debug.Log("Swap");
       
       
        switch (playas) {
            case playingas.Cont1:
                if (P1G.playernum == 2) {
                    //  playas = playingas.Player2;
                    P1G.playernum = 1;
                    P2G.playernum = 2;
                    steer = PlayerSteering.P1;
                    sideindie1.color = new Color32(255, 223, 203, 255);
                    sideindie2.color = new Color32(171, 150, 138, 255);

                } else if (P1G.playernum == 1) {
                    //  playas = playingas.Player1;
                    P1G.playernum = 2;
                    P2G.playernum = 1;
                    steer = PlayerSteering.P2;
                    sideindie2.color = new Color32(255, 223, 203, 255);
                    sideindie1.color = new Color32(171, 150, 138, 255);

                }
                break;
            case playingas.Cont2:               

                if (P2G.playernum == 2) {
                    //  playas = playingas.Player2;
                    P1G.playernum = 2;
                    P2G.playernum = 1;
                    steer = PlayerSteering.P1;
                    sideindie1.color = new Color32(255, 223, 203, 255);
                    sideindie2.color = new Color32(171, 150, 138, 255);

                } else if (P2G.playernum == 1) {
                    //  playas = playingas.Player1;
                    P1G.playernum = 1;
                    P2G.playernum = 2;
                    steer = PlayerSteering.P2;
                    sideindie2.color = new Color32(255, 223, 203, 255);
                    sideindie1.color = new Color32(171, 150, 138, 255);

                }
                break;
            
        }


    }
   
    public void Switchplayerpos() {
        if(canswitch && !uimanager.UIinstance.isopen){
           
            switch (steer) {
                case PlayerSteering.P1:
                    steerint = 1;
                    dirint = 0;
                    steer = PlayerSteering.P2;
                    //P1st.text = "Moving";
                    //P2st.text = "Steering";
                    break;
                case PlayerSteering.P2:
                    steerint = 0;
                    dirint = 1;
                    steer = PlayerSteering.P1;
                    //P1st.text = "Steering";
                    //P2st.text = "Moving";
                    break;

            }
            FindObjectOfType<Tutorial_Manager>().MoveTutorial();
            canswitch = false;
        } 
    }
    void Move()
    {

        if (going) {
            if (Currentang.y > 45 && Currentang.y < 135) {
                Dir =  Directions.left;

                spit.SetTrigger("Left");
            } else if (Currentang.y > 135 && Currentang.y < 225) {
                Dir = Directions.down;

                spit.SetTrigger("Down");
            } else if (Currentang.y > 225 && Currentang.y < 315) {
                Dir = Directions.right;

                spit.SetTrigger("Right");
            } else if (Currentang.y > 315 || Currentang.y < 45) {
                Dir = Directions.up;

                spit.SetTrigger("Up");
            }
        } 
        if (age.remainingDistance <= age.stoppingDistance) {
            going = false;
            X.SetActive(false);
            spit.SetTrigger("Stop");


        } else {
            going = true;

            if (Pointer.onmark || Pointer.goingS) {

                X.SetActive(false);
            } else {
                X.SetActive(true);
                X.transform.position = age.destination;
            }

           


        }
        
  
    }



    private void FixedUpdate()
    {
        /*
        switch (moving)
        {
            case Moving.Forwad:
                rig.AddForce(transform.forward.normalized * speed * mag);

                break;
            case Moving.Backwards:

                rig.AddForce(-transform.forward.normalized * speed *mag);

                break;
            case Moving.Not:

                isturning = true;

                break;
            default:
                break;
        }

        switch (turning)
        {
            case Turning.Clockwise:

               // rig.AddTorque(Vector3.up, turnspeed * Time.deltaTime * mag);
                if ( !isbackward && zoom > 1)
                {
                    rig.AddForce(transform.forward.normalized * speed);
                }
                else if ( isbackward && zoom > 1)
                {
                    rig.AddForce(-transform.forward.normalized * speed);

                }
                break;
            case Turning.AniClockwise:


                if ( !isbackward && zoom > 1)
                {

                    rig.AddForce(transform.forward.normalized * speed);

                }
                else if ( isbackward && zoom > 1)
                {

                    rig.AddForce(-transform.forward.normalized * speed);

                }

                break;

            case Turning.Not:
                t1 = true;
                isturning = false;

                StopAllCoroutines();

                break;
            
        }
        */

    }
  
}





