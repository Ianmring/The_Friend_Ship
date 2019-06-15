using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Start_End : MissionBeat
{

    // Start is called before the first frame update
  public void MissionStart()
    {
        this.isdone = true;
        mana.NextBeat();
    }

    public void MissionEnd()
    {
        Debug.Log("MissionE");
        //missiondone = true;
        GetComponent<NPC>().currentdiolauge++;
        GetComponent<NPC>().missionDone = true ;

    }
}
