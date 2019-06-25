﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    PersonalItemSlot slot;

     launcher launch;

     LaunchArchRenderer launchrend;

    Renderer mat;

    DiolaugeManager dio;

    movement mov;

    private void Start()
    {

        mat = GameObject.Find("Comp").GetComponent<Renderer>();
        dio = DiolaugeManager.DioInstance;
        mov = movement.MovInstance;

        slot = GetComponent<PersonalItemSlot>();

        if (slot.Playernum == 0)
        {
            launch = uimanager.UIinstance.P1.GetComponent<launcher>();
        }
        if (slot.Playernum == 1)
        {
            launch = uimanager.UIinstance.P2.GetComponent<launcher>();
        }
        GetComponentInParent<KeyitemTrigger>().isactive = true;

    }
    public void Dothething()
    {

        mat.material.color = new Color(0.8f, 0.5f, 0.1f, Mathf.Clamp(launch.IReady * 2, 0, 1));

       

    }
    public void DoDo()
    {
        mat.material.color = new Color(0.8f, 0.5f, 0.1f, Mathf.Clamp(launch.IReady * 2, 0, 1));

        
       
    }
    private void Update()
    {
        if ( dio.indio)
        {
            mat.material.color = new Color(0.8f, 0.5f, 0.1f, 0);

        }
    }
}
