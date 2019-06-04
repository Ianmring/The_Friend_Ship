using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parascope : MonoBehaviour
{
    // Start is called before the first frame update

    PersonalItemSlot slot;

  public  LaunchArchRenderer launch;
   public camscript cam;

  public  Vector3 direction;

    bool overide;
    void Start()
    {
        slot = GetComponent<PersonalItemSlot>();

        if (slot.Playernum == 0)
        {
            launch = uimanager.UIinstance.P1.GetComponent<LaunchArchRenderer>();
        }
        else if (slot.Playernum == 1)
        {
            launch = uimanager.UIinstance.P2.GetComponent<LaunchArchRenderer>();
        }
        cam = FindObjectOfType<camscript>();

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
        if (overide == true)
        {
            launch.overide = true;
            cam.Overide = true;
            cam.transform.eulerAngles = new Vector3(cam.AngleI.x, launch.Y + 90f, cam.AngleI.z);

        }
        else if(overide == false)
        {
            launch.overide = false;
            cam.Overide = false;
          //  cam.AngleI = new Vector3(cam.AngleI.x, 0, cam.AngleI.z);

        }
    }


}
