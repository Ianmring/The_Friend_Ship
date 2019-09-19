using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mission_Start_End))]

public class Misson_Manager : MonoBehaviour
{

    public NPC StartNPC;

   public MissionBeat[] Beat;

    public int currentbeat;
    // Start is called before the first frame update
    public MissionBeat Current_Beat;

 //   public MissionBeat Next_Beat;

  public  bool collectprize { get; set; }

    public string endobj;
    // Update is called once per frame
  
    private void Awake()
    {
        foreach (var beat in Beat)
        {
            beat.mana = this;
        }

      //  Current_Beat = Beat[0];
        StartNPC = GetComponent<NPC>();
    }

    public void NextBeat()
    {
        if ( StartNPC.missionstated && !collectprize)
        {
          //  Current_Beat = Beat[currentbeat];
            currentbeat++;

            if (currentbeat >= Beat.Length - 1)
            {
                //Next_Beat = Beat[currentbeat];
                collectprize = true;
                Beat[currentbeat].Task = endobj;
                FindObjectOfType<MissionOrgonizer>().UpdateMissionComp();
                MissionDone();
            }
            else
            {
                FindObjectOfType<MissionOrgonizer>().UpdateMissionComp();

              //  Next_Beat = Beat[currentbeat];

                return;
            }
        }




    }

    public void MissionDone()
    {
        Mission_Start_End end;
        end = StartNPC.GetComponent<Mission_Start_End>();

        end.MissionEnd();
    }
}
