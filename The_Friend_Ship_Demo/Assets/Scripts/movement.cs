using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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
    Rigidbody rig;

   public Vector3 Currentang;

    bool isbackward;
    public float[] directions;
    public float[] directionsx;
    public float[] Turnx;
    public enum Moving { Forwad, Backwards, Not};

    public enum Turning { Clockwise, AniClockwise, Not };

     enum Directions { up, upleft, left, downleft, down, downright, right, upright}

   public enum PlayerSteering { P1,P2}

  public  PlayerSteering steer;

    public int direction;

    public Moving moving;
    public Turning turning;
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
    int steerint;
    int dirint;

    bool t1;

    public Text P1st;
    public Text P2st;

    public bool canswitch;

    public bool go ;
    void Start () {

        move = true;
        go = true;
        canswitch = true;

        playa = FindObjectOfType<playerselect>();
        rig = GetComponent<Rigidbody>();
        steer = PlayerSteering.P1;
        Switchplayerpos();
        moving = Moving.Not;
        turning = Turning.Not;
        spit = GetComponentInChildren<SpriteRenderer>();
        direction = 2;
        checkDirection();
    }

    // Update is called once per frame
    void Update () {

     

      
        if (move)
        {

           
            rig.mass = 1;
            Currentang = GetComponent<Transform>().eulerAngles;
            Move();
            Direction();
     
            rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxspeed);
            zoom = rig.velocity.magnitude;
            turnspeed = zoom >= 1 ? minturnspeed : maxturnspeed;
            zroto = transform.localEulerAngles.y;
        }
        else
        {
            rig.mass = 10;
            turning = Turning.Not;
        }


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
                    P1st.text = "Moving";
                    P2st.text = "Steering";
                    break;
                case PlayerSteering.P2:
                    steerint = 0;
                    dirint = 1;
                    steer = PlayerSteering.P1;
                    P1st.text = "Steering";
                    P2st.text = "Moving";
                    break;

            }
            FindObjectOfType<Tutorial_Manager>().MoveTutorial();
            canswitch = false;
        }
    }
    void Move()
    {
        if (go) {
            mag = Mathf.Abs(directions[dirint]);
            if (directions[dirint] < -0.3) {
                moving = Moving.Forwad;
                isbackward = false;


                // ismoving = true;
            } else if (directions[dirint] > 0.3) {
                moving = Moving.Backwards;
                isbackward = true;


                //ismoving = true;

            } else {
                moving = Moving.Not;

            }
        }
    }
    void Direction() {
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
   

    private void FixedUpdate()
    {
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

                Dir = Directions.upright;
                break;
            case 2:

                Dir = Directions.right;
                break;
            case 3:

                Dir = Directions.downright;
                break;
            case 4:

                Dir = Directions.down;
                break;
            case 5:

                Dir = Directions.downleft;
                break;
            case 6:

                Dir = Directions.left;
                break;
            case 7:

                Dir = Directions.upleft;
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

}

   



