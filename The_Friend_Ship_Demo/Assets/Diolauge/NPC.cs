using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPC : Interactable
{
    public int[] storytriggers;
    public Diolauge[] Diolaugeoptions;
   public  int currentdiolauge =0;

  
    bool p1;
    bool p2;

    public SpriteRenderer Button1;
    public SpriteRenderer Button2;

    public DiolaugeManager diomana;
    int p1I;
    int p2I;

   
    public override void Interact()
    {
        if (this.enabled)
        {
            diomana = FindObjectOfType<DiolaugeManager>();
            NPCInteract(currentdiolauge);
            base.Interact();

        }

    }

  
    public void NPCInteract(int diotoload)
    {

        if (diomana.currentstorymoment == storytriggers[diotoload]) {
            currentdiolauge++;
            FindObjectOfType<DiolaugeManager>().Startdio(Diolaugeoptions[diotoload], this.gameObject);
            currentdiolauge++;

        } else {
            FindObjectOfType<DiolaugeManager>().Startdio(Diolaugeoptions[diotoload] , this.gameObject);

        }

        // Debug.Log("Is NPC interact");
    }

    public virtual void Doathing()
    {

    }
    private void Update()
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
   
    // Update is called once per frame
   
}
