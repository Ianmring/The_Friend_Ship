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

 

    Moving moving;
    Turning turning;
 

    public Slider[] Slides;

    public RectTransform directC;
    //public RectTransform directL;
    playerselect playa;

     float zroto;

    public launcher P1F;
    public launcher P2F;


    float mag;

    public bool move= true;

    public bool PlayersSet;

    public bool altoveride;
    void Start () {

        move = true;
        playa = FindObjectOfType<playerselect>();
        rig = GetComponent<Rigidbody>();
        moving = Moving.Not;
        turning = Turning.Not;
     
  
    }

    // Update is called once per frame
    void Update () {

      

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
            directC.gameObject.SetActive(false);
        }
        
        if (PlayersSet)
        {
            if ((P1F.Ready > 0 || altoveride && P1F.Slot.iskeyitem) || (P2F.Ready > 0  || altoveride && P2F.Slot.iskeyitem))
            {
                move = false;
            }
            else if(P1F.Slot == null || P2F.Slot == null)
            {
                move = true;
            }
            else
            {
                move = true;
            }
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

       


        }
        else if (directions[0] < 0 && directions[1] > 0)
        {
            turning = Turning.AniClockwise;
         

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

                transform.Rotate(Vector3.up, turnspeed * Time.deltaTime *mag);
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

                transform.Rotate(Vector3.up, -turnspeed * Time.deltaTime * mag);

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
                
                break;
            default:
                break;
        }


    }




}

   



