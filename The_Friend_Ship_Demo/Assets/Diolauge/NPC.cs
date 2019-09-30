using System.Collections;
using System.Collections.Generic;
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


    bool p1;
    bool p2;

    public SpriteRenderer Button1;
    public SpriteRenderer Button2;

    int p1I;
    int p2I;
    public override void Interact()
    {
        if (this.enabled)
        {
            NPCInteract(currentdiolauge);
            base.Interact();

        }

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
    private new void Update()
    {
        if (diointoer)
        {
            Button1.gameObject.SetActive(true);
            Button2.gameObject.SetActive(true);
            if (Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p1I.ToString())&& dio)
            {
                p1 = true;
                Button1.color = Color.green;
            }
            if (Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p2I.ToString()) && dio)
            {
                p2 = true;
                Button2.color = Color.green;

            }

            if (p1 && p2)
            {

                if (dio)
                {
              
              

                    dio = false;
                    p1 = false;
                    p2 = false;

                    Interact();
                }
            }
        }
        else
        {
            Button1.color = Color.yellow;
            Button2.color = Color.yellow;
            Button1.gameObject.SetActive(false);
            Button2.gameObject.SetActive(false);
        }
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
