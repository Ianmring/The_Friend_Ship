using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misson_Manager : MonoBehaviour
{

    public NPC StartNPC;

   public MissionBeat[] Beat;

    public int currentbeat;
    // Start is called before the first frame update
    public MissionBeat Current_Beat;

    public MissionBeat Next_Beat;

    bool collectprize;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        foreach (var beat in Beat)
        {
            beat.mana = this;
        }

        Current_Beat = Beat[0];
    }

    public void NextBeat()
    {
        if (Beat[currentbeat].isdone == true && StartNPC.missionstated && !collectprize)
        {
            Current_Beat = Beat[currentbeat];
            currentbeat++;

            if (currentbeat >= Beat.Length - 1)
            {
                Next_Beat = Beat[currentbeat];
                collectprize = true;
                MissionDone();
            }
            else
            {
                Next_Beat = Beat[currentbeat];

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
