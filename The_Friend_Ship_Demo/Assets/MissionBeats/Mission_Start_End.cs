using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Start_End : MissionBeat
{
    MissionOrgonizer MissO;


    // Start is called before the first frame update
  public void MissionStart()
    {
        MissO = FindObjectOfType<MissionOrgonizer>();
        MissO.ActiveMissions.Add(mana);
        MissO.currentQuest = mana;
        this.isdone = true;
        mana.NextBeat();
    }

    public void MissionEnd()
    {
  
        GetComponent<NPC>().currentdiolauge++;
        GetComponent<NPC>().missionDone = true ;

    }
}
