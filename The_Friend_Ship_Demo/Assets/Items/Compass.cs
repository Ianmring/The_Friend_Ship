using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    PersonalItemSlot slot;

    launcher launch;

    LaunchArchRenderer launchrend;

    Renderer mat;

    private void Start()
    {

        mat = GameObject.Find("Comp").GetComponent<Renderer>();

        slot = GetComponent<PersonalItemSlot>();

        if (slot.Playernum == 0)
        {
            launch = uimanager.UIinstance.P1.GetComponentInChildren<launcher>();
            launchrend = uimanager.UIinstance.P1.GetComponent<LaunchArchRenderer>();
        }
        else if (slot.Playernum == 1)
        {
            launch = uimanager.UIinstance.P2.GetComponentInChildren<launcher>();
            launchrend = uimanager.UIinstance.P2.GetComponent<LaunchArchRenderer>();
        }
    }
    public void Dothething()
    {
        launchrend.overide = true;
        mat.material.color = new Color(0.8f,0.5f,0.1f, Mathf.Clamp(launch.dirTotal * 2, 0,1)  );
    }
    public void DoDo()
    {
        launchrend.overide = true;
        mat.material.color = new Color(0.8f, 0.5f, 0.1f, Mathf.Clamp(launch.dirTotal * 2, 0, 1));

    }
}
