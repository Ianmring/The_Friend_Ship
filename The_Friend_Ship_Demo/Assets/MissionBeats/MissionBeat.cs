using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissionBeat : MonoBehaviour
{
    public bool isdone;
    public GameObject ObjThis;
    public Misson_Manager mana;

    private void Awake()
    {
        ObjThis = this.gameObject;
        isdone = false;
    }

    public void FinishBeat()
    {
        isdone = true;
        mana.NextBeat();
    }
}
