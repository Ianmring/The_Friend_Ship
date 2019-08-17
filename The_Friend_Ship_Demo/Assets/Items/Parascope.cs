using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parascope : MonoBehaviour
{
    // Start is called before the first frame update

    PersonalItemSlot slot;

    launcher launch;
    camscript cam;

    Vector3 direction;

    DiolaugeManager dio;

    movement mov;

    bool overide;
    void Start()
    {
        slot = GetComponent<PersonalItemSlot>();
        dio = DiolaugeManager.DioInstance;
        mov = movement.MovInstance;

        if (slot.Playernum == 0)
        {
            launch = uimanager.UIinstance.P1.GetComponent<launcher>();
        }
        else if (slot.Playernum == 1)
        {
            launch = uimanager.UIinstance.P2.GetComponent<launcher>();
        }
        cam = FindObjectOfType<camscript>();
     //   GetComponentInParent<KeyitemTrigger>().isactive = true;

    }

    // Update is called once per frame

    public void Dothething()
    {
        overide = true;
    }
    public void DoDo()
    {
        overide = false;

    }
    public void FixedUpdate()
    {

        //if (slot.isbeingused == false)
        //{
        //    //  mov.move = true;
        //    mov.altoveride = false;

        //    cam.Overide = false;

        //}
        //else
        //{
            if (overide == true)
            {
            //  mov.move = false;

            //   mov.altoveride = true;




            if (launch.DirH > 0)
            {
                cam.transform.Rotate(0, -40 * Time.deltaTime, 0, Space.World);
            }
            if (launch.DirH < 0)
            {
                cam.transform.Rotate(0, 40 * Time.deltaTime, 0, Space.World);
            }



        }
        else if (overide == false)
            {
                //  mov.move = true;
             //   mov.altoveride = false;

            }
   //     }

        //if (!mov.move)
        //{

        //}


    }


}
