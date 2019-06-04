
using UnityEngine;

public class NPC : Interactable
{

    public Diolauge[] Diolaugeoptions;
     int currentdiolauge =0;
    public enum NPCTYPE {NPC, Shop, Description};

    public NPCTYPE npctype;
    // Start is called before the first frame update


    public override void Interact()
    {
        if (this.enabled)
        {
            NPCInteract(currentdiolauge); 

        }

        base.Interact();
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
        currentdiolauge = 1;

    }
    // Update is called once per frame
   
}
