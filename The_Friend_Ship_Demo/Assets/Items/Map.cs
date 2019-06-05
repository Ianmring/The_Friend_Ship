using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Map : MonoBehaviour
{

    PersonalItemSlot slot;

    Slider slide;

    launcher launch;

    LaunchArchRenderer launchrend;

    private void Start()
    {
        slot = GetComponent<PersonalItemSlot>();

        if (slot.Playernum == 0)
        {
            launch = uimanager.UIinstance.P1.GetComponentInChildren<launcher>();
            launchrend = uimanager.UIinstance.P1.GetComponent<LaunchArchRenderer>();
            slide = GameObject.Find("P1Equip").GetComponentInChildren<Slider>();
        }
        else if (slot.Playernum == 1)
        {
            launch = uimanager.UIinstance.P2.GetComponentInChildren<launcher>();
            launchrend = uimanager.UIinstance.P2.GetComponent<LaunchArchRenderer>();
            slide = GameObject.Find("P2Equip").GetComponentInChildren<Slider>();
        }
    }
    public void Dothething()
    {
        launchrend.overide = true;
        slide.value = launch.dirTotal * 2;
    }
    public void DoDo()
    {
        launchrend.overide = true;
        slide.value = launch.dirTotal * 2;

    }
}
