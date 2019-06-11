﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Map : MonoBehaviour
{

    PersonalItemSlot slot;

    Slider slide;

    launcher launch;

    LaunchArchRenderer launchrend;

    DiolaugeManager dio;

    movement mov;

    uiMap map;
    uiChecklist check;
    private void Start()
    {
        slot = GetComponent<PersonalItemSlot>();
        dio = DiolaugeManager.DioInstance;
        mov = movement.MovInstance;

        if (slot.Playernum == 0)
        {
            check = mov.Handels[0].GetComponentInChildren<uiChecklist>();
            check.gameObject.SetActive(false);

            map = mov.Handels[0].GetComponentInChildren<uiMap>();
            map.gameObject.SetActive(true);
            launch = uimanager.UIinstance.P1.GetComponentInChildren<launcher>();
            launchrend = uimanager.UIinstance.P1.GetComponent<LaunchArchRenderer>();
            slide = GameObject.Find("P1Equip").GetComponentInChildren<Slider>();
        }
        if (slot.Playernum == 1)
        {
            check = mov.Handels[1].GetComponentInChildren<uiChecklist>();
            check.gameObject.SetActive(false);

            map = mov.Handels[1].GetComponentInChildren<uiMap>();
            map.gameObject.SetActive(true);
            launch = uimanager.UIinstance.P2.GetComponentInChildren<launcher>();
            launchrend = uimanager.UIinstance.P2.GetComponent<LaunchArchRenderer>();
            slide = GameObject.Find("P2Equip").GetComponentInChildren<Slider>();
        }
    }
    public void Dothething()
    {
        //  launchrend.overide = true;

        slide.value = launch.Ready;

        //if (launch.Ready > 0)
        //{
        //    mov.move = false;

        //}



    }
    public void DoDo()
    {
        //  launchrend.overide = true;

        slide.value = launch.Ready;



    }
    private void Update()
    {
        if (!launchrend.overide || !slot.isbeingused || dio.indio)
        {

            slide.value = 0f;


        }
    }
    private void OnDestroy()
    {
        {
            check.gameObject.SetActive(true);

            map.gameObject.SetActive(true);
        }
    }
}
