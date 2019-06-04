using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArchRenderer : MonoBehaviour
{

    LineRenderer LR;
    launcher Lan;

    public float Velocitymulti;
    public float angelmulti;
    public float maxang;


    float Velocity;
     float angle;
    public int resolution = 10;

    float g;
    float radiantangel;

    public bool overide;
    public float Y { get; set; }
    private void Awake()
    {
       
        LR = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics.gravity.y);
        Lan = GetComponentInChildren<launcher>();
        //Velocity = Lan.dirTotal * Velocitymulti;
        //angle = Lan.dirTotal * angelmulti;
    }

     void OnValidate()
    {
        if (LR != null && Application.isPlaying)
        {

            RenderArc();

        }
    }
  
    // Start is called before the first frame update
    void Update()
    {

        if (!GetComponent<Playergen>().isdemo || Lan.Slot != null)
        {

            if (!overide)
            {
                RenderArc();

            }
            Velocity = Lan.dirTotal * Velocitymulti;
            angle = Lan.dirTotal * angelmulti;
            if (Velocity < 1)
            {
                Velocity = 1;
            }
            else if (angle < 1)
            {
                angle = 1;
            }
            if (Velocity > 15)
            {
                Velocity = 15;

            }
            if (angle > maxang)
            {
                angle = maxang;

            }

            transform.eulerAngles = new Vector3(0f, Mathf.Atan2(Lan.Dir1V, Lan.Dir1H) * 180 / Mathf.PI, 0f); // this does the actual rotaion according to inputs
            Y = transform.eulerAngles.y;
        }
        else
        {
            return;
        }

    }


    // Update is called once per frame
    void RenderArc()
    {

        LR.SetVertexCount(resolution + 1);
        LR.SetPositions(CalcArcArray());

    }


    Vector3[] CalcArcArray()
    {

       
        Vector3[] arcarray = new Vector3[resolution + 1];

        radiantangel = Mathf.Deg2Rad * angle;
        float maxdistance = (Velocity * Velocity * Mathf.Sin(2 * radiantangel)) / g;

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcarray[i] = CalculateArcpoint(t, maxdistance);
        }

        return arcarray;
        }
     Vector3 CalculateArcpoint(float t, float maxdistance)
    {
        float x = t * maxdistance;
     //  float z = t * maxdistance;

        float y = x * Mathf.Tan(radiantangel) - ((g * x * x) / (2 * Velocity * Velocity * Mathf.Cos(radiantangel) * Mathf.Cos(radiantangel)));
        return new Vector3(x, y);
    }
    
}
