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


    public float speed;

    public float maxspeed;
    public float minturnspeed;
    public float maxturnspeed;
   float turnspeed;

   public float zoom;
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

     enum Directions { up, upleft, left, downleft, down, downright, right, upright}

   public enum PlayerSteering { P1,P2}

  public  PlayerSteering steer;

   // public int direction;

     Moving moving;
     Turning turning;
     Directions Dir;

   // public Slider[] Slides;

 //   public RectTransform directC;

    public GameObject[] Handels;

    public Sprite[] imagedir;

    //public RectTransform directL;
    playerselect playa;

     float zroto;

    public inventorygeneral p1I;
   public inventorygeneral p2I;


  public  SpriteRenderer spit;
    public float mag;

    public bool move= true;

    public bool isturning;
    public bool PlayersSet;

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
        spit = GetComponentInChildren<SpriteRenderer>();
       // X.SetActive(false);


        //   direction = 2;

        //checkDirection();
    }

    // Update is called once per frame
    void Update () {


        spit.GetComponent<Transform>().eulerAngles = new Vector3(40, 0, 0);


        if (move && !uimanager.UIinstance.isopen)
        {

           
          //  rig.mass = 1;
            Currentang = GetComponent<Transform>().eulerAngles;
            Move();
            //Direction();
     
         //   rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxspeed);
         //   zoom = rig.velocity.magnitude;
            turnspeed = zoom >= 1 ? minturnspeed : maxturnspeed;
            zroto = transform.localEulerAngles.y;
            Pointer.gameObject.SetActive(true);
        }
        else {

            age.destination = transform.localPosition;

            turning = Turning.Not;
            Pointer.gameObject.SetActive(false);

        }



        //   spit.GetComponent<Transform>().eulerAngles = new Vector3(40, 0, 0);

        //if (turning == Turning.Not && moving == Moving.Not)
        //{
        //    isforward = false;
        //    isbackward = false;

        //}

    }

    public void Switchplayerpos() {
        if(canswitch){
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
                spit.sprite = imagedir[2];
            } else if (Currentang.y > 135 && Currentang.y < 225) {
                spit.sprite = imagedir[4];
            } else if (Currentang.y > 225 && Currentang.y < 315) {
                spit.sprite = imagedir[6];
            } else if (Currentang.y > 315 || Currentang.y < 45) {
                spit.sprite = imagedir[0];
            }
        }
        if (age.remainingDistance <= age.stoppingDistance) {
            going = false;
            X.SetActive(false);
        } else {
            going = true;

            if (Pointer.onmark || Pointer.goingS) {
                X.SetActive(false);
            } else {
                X.SetActive(true);
                X.transform.position = age.destination;
            }

           


        }
        
        #region OldMov
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //RaycastHit hit;
        //if (Input.GetMouseButtonDown(0)) {
        //    if (Physics.Raycast(ray, out hit)) {
        //        age.destination = hit.point;
        //    }

        //}




        //if (go) {
        //    mag = Mathf.Abs(directions[dirint]);
        //    if (directions[dirint] < -0.3) {
        //        moving = Moving.Forwad;
        //        isbackward = false;


        //        // ismoving = true;
        //    } else if (directions[dirint] > 0.3) {
        //        moving = Moving.Backwards;
        //        isbackward = true;


        //        //ismoving = true;

        //    } else {
        //        moving = Moving.Not;

        //    }
        //}
        #endregion
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
    #region oldmov 
    /*
     * 
     *  void Direction() {
        if (go) {
            if (Turnx[steerint] > 0.3) {
                turning = Turning.Clockwise;

                StartCoroutine("TurnClockwise");



            } else if (Turnx[steerint] < -0.3) {
                turning = Turning.AniClockwise;

                StartCoroutine("TurnAntiClockwise");


            } else {

                turning = Turning.Not;
            }
        }
           
    }
    public void checkDirection()
    {
        if (direction < 0)
        {
            direction = 7;
        }
        else if (direction > 7)
        {
            direction = 0;
        }

        spit.GetComponent<Transform>().eulerAngles = new Vector3(40,0,0);
        spit.sprite = imagedir[direction];

        switch (direction)
        {
            case 0:
                Dir = Directions.up;

                break;
            case 1:

                Dir = Directions.right;
                break;
            case 2:

                Dir = Directions.right;
                break;
            case 3:

                Dir = Directions.right;
                break;
            case 4:

                Dir = Directions.down;
                break;
            case 5:

                Dir = Directions.left;
                break;
            case 6:

                Dir = Directions.left;
                break;
            case 7:

                Dir = Directions.left;
                break;
          
        }
    }
    IEnumerator TurnClockwise()
    {
        if (t1)
        {
            transform.Rotate(Vector3.up, 45);
            direction++;
            checkDirection();
            t1 = false;
        }
        yield return new WaitForSeconds(turnspeed);

        transform.Rotate(Vector3.up, 45);
        direction++;
        checkDirection();

        StopCoroutine("TurnClockwise");
    }
    IEnumerator TurnAntiClockwise()
    {
        if (t1)
        {
            transform.Rotate(Vector3.up, -45);
            direction--;
            checkDirection();

            t1 = false;
        }
        yield return new WaitForSeconds(turnspeed);

        transform.Rotate(Vector3.up, -45);
        direction--;
        checkDirection();

        StopCoroutine("TurnAntiClockwise");
    }
    */
    #endregion
}





