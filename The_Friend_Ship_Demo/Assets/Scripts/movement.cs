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

    float zoom;
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

    public RectTransform directC;

    public GameObject[] Handels;

    public Sprite[] imagedir;

    //public RectTransform directL;
    playerselect playa;

     float zroto;

    public launcher P1F;
    public launcher P2F;

  public  MainLauncher ML;

  public  SpriteRenderer spit;
    public float mag;

    public bool move= true;

    public bool isturning;
    public bool PlayersSet;

    public bool altoveride;
    int steerint;
    int dirint;

    bool t1;
    void Start () {

        move = true;
        playa = FindObjectOfType<playerselect>();
        rig = GetComponent<Rigidbody>();
        steer = PlayerSteering.P2;
        Switchplayerpos();
        moving = Moving.Not;
        turning = Turning.Not;
        checkDirection();
        spit = GetComponentInChildren<SpriteRenderer>();
            
    }

    // Update is called once per frame
    void Update () {

        if (PlayersSet)
        {
            if ((P1F.IReady > 0 && ML.p1I.TriggerItem.KeyItem != null && !ML.p1I.TriggerItem.Isitem) || (P2F.IReady > 0 && ML.p2I.TriggerItem.KeyItem != null && !ML.p2I.TriggerItem.Isitem) || altoveride)
            {
                move = false;
            }

            //else if (P1F.Slot == null || P2F.Slot == null)
            //{
            //    move = true;
            //}
            else if (!altoveride)
            {
                move = true;
            }

         
        }

      
        if (move)
        {

           
            rig.mass = 1;
            directC.gameObject.SetActive(true);
            Currentang = GetComponent<Transform>().eulerAngles;
            Move();
            Direction();
            //Slides[0].value = directions[0];
            //Slides[1].value = directions[1];
            zoom = rig.velocity.magnitude;
            

            if (zoom >= 1)
            {
                turnspeed = minturnspeed;
            }
            else
            {
                turnspeed = maxturnspeed;
            }

            zroto = transform.localEulerAngles.y;
            directC.eulerAngles = new Vector3(0, 0, -zroto);
        }
        else
        {
            rig.mass = 10;
            turning = Turning.Not;
            directC.gameObject.SetActive(false);
        }


        //if (turning == Turning.Not && moving == Moving.Not)
        //{
        //    isforward = false;
        //    isbackward = false;

        //}

    }

    public void Switchplayerpos() {

        switch (steer) {
            case PlayerSteering.P1:
                steerint = 1;
                dirint = 0;
                steer = PlayerSteering.P2;
                break;
            case PlayerSteering.P2:
                steerint = 0;
                dirint = 1;
                steer = PlayerSteering.P1;

                break;

        }
    }
    void Move()
    {
        if (!isturning) {
            switch (Dir) {
                case Directions.up:
                    mag = Mathf.Abs(directions[dirint]);
                    if (directions[dirint] < 0) {
                        moving = Moving.Forwad;
                        isbackward = false;


                        // ismoving = true;
                    } else if (directions[dirint] > 0 ) {
                        moving = Moving.Backwards;
                        isbackward = true;


                        //ismoving = true;

                    } else {
                        moving = Moving.Not;

                    }
                    break;
                case Directions.upleft:
                    mag = Mathf.Clamp((Mathf.Abs(directions[dirint]) + Mathf.Abs(directionsx[dirint])), 0, 1);
                    if (directionsx[dirint] < 0  && directions[dirint] < 0 ) {
                        moving = Moving.Forwad;
                        isbackward = false;


                        // ismoving = true;
                    } else if (directionsx[dirint] > 0  && directions[dirint] > 0 ) {
                        moving = Moving.Backwards;
                        isbackward = true;


                        //ismoving = true;

                    } else {
                        moving = Moving.Not;

                    }
                    break;
                case Directions.left:
                    mag = Mathf.Abs(directionsx[dirint]);
                    if (directionsx[dirint] < 0 ) {
                        moving = Moving.Forwad;
                        isbackward = false;


                        // ismoving = true;
                    } else if (directionsx[dirint] > 0 ) {
                        moving = Moving.Backwards;
                        isbackward = true;


                        //ismoving = true;

                    } else {
                        moving = Moving.Not;

                    }
                    break;
                case Directions.downleft:
                    mag = Mathf.Clamp((Mathf.Abs(directions[dirint]) + Mathf.Abs(directionsx[dirint])), 0, 1);
                    if (directionsx[dirint] < 0  && directions[dirint] > 0) {
                        moving = Moving.Forwad;
                        isbackward = false;


                        // ismoving = true;
                    } else if (directionsx[dirint] > 0  && directions[dirint] < 0) {
                        moving = Moving.Backwards;
                        isbackward = true;


                        //ismoving = true;

                    } else {
                        moving = Moving.Not;

                    }
                    break;
                case Directions.down:
                    mag = Mathf.Abs(directions[dirint]);
                    if (directions[dirint] > 0 ) {
                        moving = Moving.Forwad;
                        isbackward = false;


                        // ismoving = true;
                    } else if (directions[dirint] < 0) {
                        moving = Moving.Backwards;
                        isbackward = true;


                        //ismoving = true;

                    } else {
                        moving = Moving.Not;

                    }
                    break;
                    
                case Directions.downright:
                    mag = Mathf.Clamp((Mathf.Abs(directions[dirint]) + Mathf.Abs(directionsx[dirint])), 0, 1);
                    if (directionsx[dirint] > 0  && directions[dirint] > 0) {
                        moving = Moving.Forwad;
                        isbackward = false;


                        // ismoving = true;
                    } else if (directionsx[dirint] < 0 && directions[dirint] < 0) {
                        moving = Moving.Backwards;
                        isbackward = true;


                        //ismoving = true;

                    } else {
                        moving = Moving.Not;

                    }
                    break;
                case Directions.right:
                    mag = (Mathf.Abs(directionsx[dirint]));

                    if (directionsx[dirint] > 0) {
                        moving = Moving.Forwad;
                        isbackward = false;


                        // ismoving = true;
                    } else if (directionsx[dirint] < 0 ) {
                        moving = Moving.Backwards;
                        isbackward = true;


                        //ismoving = true;

                    } else {
                        moving = Moving.Not;

                    }
                    break;
                case Directions.upright:
                    mag = Mathf.Clamp((Mathf.Abs(directions[dirint])  + Mathf.Abs(directionsx[dirint])),0,1) ;

                    if (directionsx[dirint] > 0  && directions[dirint] < 0 ) {
                        moving = Moving.Forwad;
                        isbackward = false;


                        // ismoving = true;
                    } else if (directionsx[dirint] < 0  && directions[dirint] > 0 ) {
                        moving = Moving.Backwards;
                        isbackward = true;


                        //ismoving = true;

                    } else {
                        moving = Moving.Not;

                    }
                    break;

           
            }

        }
    }
    void Direction() {
        if (moving == Moving.Not) {
            if (Turnx[steerint] > 0) {
                turning = Turning.Clockwise;

                StartCoroutine("TurnClockwise");



            } else if (Turnx[steerint] < 0) {
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
                if (moving == Moving.Not && !isbackward && zoom > 1)
                {
                    rig.AddForce(transform.forward.normalized * speed);
                }
                else if (moving == Moving.Not && isbackward && zoom > 1)
                {
                    rig.AddForce(-transform.forward.normalized * speed);

                }
                break;
            case Turning.AniClockwise:


                if (moving == Moving.Not && !isbackward && zoom > 1)
                {

                    rig.AddForce(transform.forward.normalized * speed);

                }
                else if (moving == Moving.Not && isbackward && zoom > 1)
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

   



