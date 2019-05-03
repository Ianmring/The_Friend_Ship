using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

    // Use this for initialization

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


    float mag;

  
    void Start () {

        playa = FindObjectOfType<playerselect>();
        rig = GetComponent<Rigidbody>();
        moving = Moving.Not;
        turning = Turning.Not;
     
     
        // Debug.Log(names);

      

        
    }

    // Update is called once per frame
    void Update () {




        mag = (Mathf.Abs(directions[0]) + Mathf.Abs(directions[1])) / 2;

        Move();
        Direction();

        Slides[0].value = directions[0];
        Slides[1].value = directions[1];



      //  rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxspeed);

        zoom = rig.velocity.magnitude;


        if (zoom >= maxspeed - maxspeed / 5)
        {
            turnspeed = minturnspeed;
        }
        else
        {
            turnspeed = maxturnspeed;
        }

        zroto = transform.eulerAngles.y;
        directC.eulerAngles = new Vector3(0, 0, -zroto);

       
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

   



