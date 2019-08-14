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

  

    bool isforward;
    bool isbackward;
    public float[] directions;

    public enum Moving { Forwad, Backwards, Not};

    public enum Turning { Clockwise, AniClockwise, Not };

    public enum Directions { up, upleft, left, downleft, down, downright, right, upright}

    public int direction;

    Moving moving;
    Turning turning;
   public Directions Dir;

    public Slider[] Slides;

    public RectTransform directC;

    public GameObject[] Handels;

    public Sprite[] imagedir;

    //public RectTransform directL;
    playerselect playa;

    public float zroto;

    public launcher P1F;
    public launcher P2F;

  public  MainLauncher ML;

  public  SpriteRenderer spit;
    float mag;

    public bool move= true;

    public bool PlayersSet;

    public bool altoveride;

    bool t1;
    void Start () {

        move = true;
        playa = FindObjectOfType<playerselect>();
        rig = GetComponent<Rigidbody>();
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

            mag = (Mathf.Abs(directions[0]) + Mathf.Abs(directions[1])) / 2;
            rig.mass = 1;
            directC.gameObject.SetActive(true);
            Move();
            Direction();
            Slides[0].value = directions[0];
            Slides[1].value = directions[1];
            zoom = rig.velocity.magnitude;


            if (zoom >= maxspeed - maxspeed / 5)
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
      
        

    }


    void Move()
    {
        if (directions[0] < 0 && directions[1] < 0)
        {
            moving = Moving.Forwad;
            isforward = true;

      
            // ismoving = true;
        }
        else if (directions[0] > 0 && directions[1] > 0)
        {
            moving = Moving.Backwards;
            isbackward = true;


            //ismoving = true;

        }
        else
        {
            moving = Moving.Not;

        }
    }
    void Direction()
    {
        if (directions[0] > 0 && directions[1] < 0)
        {
            turning = Turning.Clockwise;
            StartCoroutine("TurnClockwise");



        }
        else if (directions[0] < 0 && directions[1] > 0)
        {
            turning = Turning.AniClockwise;
            StartCoroutine("TurnAntiClockwise");


        }
        else
        {

            turning = Turning.Not;
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

                
                break;
            default:
                break;
        }

        switch (turning)
        {
            case Turning.Clockwise:

               // rig.AddTorque(Vector3.up, turnspeed * Time.deltaTime * mag);
                if (moving == Moving.Not && isforward)
                {
                    rig.AddForce(transform.forward.normalized * speed/5);
                }
                if (moving == Moving.Not && isbackward)
                {
                    rig.AddForce(-transform.forward.normalized * speed/5);

                }

                break;
            case Turning.AniClockwise:


                if (moving == Moving.Not && isforward)
                {
                    rig.AddForce(transform.forward.normalized * speed/5);

                }
                if (moving == Moving.Not && isbackward)
                {
                    rig.AddForce(-transform.forward.normalized * speed/5);

                }

                break;

            case Turning.Not:
                t1 = true;
                StopAllCoroutines();

                break;
            default:
         

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

   



