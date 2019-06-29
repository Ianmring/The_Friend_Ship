
using UnityEngine;

public class NPC : Interactable
{

    public Diolauge[] Diolaugeoptions;
   public  int currentdiolauge =0;

    public Mission_Start_End startmissionB;
    MissionOrgonizer missorgo;
    public enum NPCTYPE {NPC, Shop, Description};

    public NPCTYPE npctype;
    // Start is called before the first frame update
    public bool missionstated;
    public bool missionDone;
    public bool missionclosed;

    public override void Interact()
    {
        if (this.enabled)
        {
            NPCInteract(currentdiolauge); 

        }

        base.Interact();
    }

    public void Awake()
    {
        missorgo = FindObjectOfType<MissionOrgonizer>();
        startmissionB = GetComponent<Mission_Start_End>();
    }
    public void NPCInteract(int diotoload)
    {
        FindObjectOfType<DiolaugeManager>().Startdio(Diolaugeoptions[diotoload], this);

        // Debug.Log("Is NPC interact");
    }

    public virtual void Doathing()
    {

    }

    public void StartAMission()
    {
        missionstated = true;
        startmissionB.MissionStart();
        currentdiolauge = 1;

    }
    public void Endmission()
    {
        Debug.Log("MissionEnd");
        missorgo.ActiveMissions.Remove(startmissionB.mana);
        missorgo.CompletedMissions.Add(startmissionB.mana);
        missorgo.currentQuest = null;
        missorgo.UpdateMissionComp();
        currentdiolauge++;
        missionclosed = true;
    }
    // Update is called once per frame
   
}
