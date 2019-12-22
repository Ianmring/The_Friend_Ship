﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiolaugeTrigger : MonoBehaviour {

    public Diolauge NotMentionDio;
    public Diolauge MentionDio;
    public Diolauge IntermDio;
    public Diolauge PostDio;

    DiolaugeManager dioman;

    bool caninteract;
    [SerializeField]
    bool cantrigger;
    public Diolauge[] diooptions;
    [SerializeField]

    public SpriteRenderer Button1;
    public SpriteRenderer Button2;

    public GameObject And;
    public GameObject Or;

    bool p1;
    bool p2;

    public enum meetstates { notmentioned, mentioned, interm , post}

   public meetstates meet;
  
    string ToDo;

   public DiolaugeTrigger[] peoplemeet;

    bool minordeciss;

    public void Start() {
        dioman = FindObjectOfType<DiolaugeManager>();
     //   meet = meetstates.notmentioned;

    }
    private void OnEnable() {

        caninteract = false;
        
      
        StartCoroutine("Abletointeract");
    }
    private void OnTriggerEnter(Collider other) {
        
        
            if (other.GetComponent<movement>() && !cantrigger) {
            Button1.gameObject.SetActive(true);
            Button2.gameObject.SetActive(true);
            cantrigger = true;

            } 

        

    }
    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<movement>()) {
         
          
            Button1.gameObject.SetActive(false);
            Button2.gameObject.SetActive(false);
           cantrigger = false;

        }
    }
    public void LateUpdate() {

        if (cantrigger) {
            if (Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p1I.ToString())) {
                p1 = true;
                Button1.color = Color.green;
            }
            if (Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p2I.ToString())) {
                p2 = true;
                Button2.color = Color.green;

            }

            if (p1 && p2 && !minordeciss) {
                StartCoroutine("TriggerdioWait");

            } else if((p1 || p2) && minordeciss) {
                StartCoroutine("TriggerdioWait");

            }

            if (minordeciss) {
                Or.SetActive(true);
                And.SetActive(false);

            } else if (!minordeciss) {
                Or.SetActive(false);
                And.SetActive(true);
            }

        } else {
            Or.SetActive(false);
            And.SetActive(false);
        }

   

    }
    IEnumerator TriggerdioWait() {
        yield return new WaitForSeconds(.1f);

        switch (meet) {
            case meetstates.notmentioned:
                minordeciss = true;

                dioman.Startdio(NotMentionDio, this.gameObject);

                ToDo = MentionDio.thingtodo;
                
                break;
            case meetstates.mentioned:
                minordeciss = true;

                dioman.Startdio(MentionDio, this.gameObject);

                meet = meetstates.interm;

                foreach (var people in peoplemeet) {
                    people.meet = meetstates.mentioned;
                    people.minordeciss = false;
                }
                              
                ToDo = MentionDio.thingtodo;
                
                break;
            case meetstates.interm:
                minordeciss = true;

                dioman.Startdio(IntermDio, this.gameObject);

                ToDo = IntermDio.thingtodo;
                
                break;

            case meetstates.post:
                minordeciss = true;

                dioman.Startdio(PostDio, this.gameObject);

                ToDo = PostDio.thingtodo;

                break;
           
        }
            
        p1 = false;
        p2 = false;
       
        cantrigger = false;

    }
    IEnumerator Abletointeract()
    {
        if (ToDo != null) {
            gameObject.SendMessage(ToDo, SendMessageOptions.DontRequireReceiver);
        }
        Button1.color = Color.yellow;
        Button2.color = Color.yellow;
        yield return new WaitForSeconds(.5f);
        caninteract = true;
       // cantrigger = false;
        
    }

    public void Tstartdio(string dio, string Messagetosend) {

        if (Messagetosend != "N/A" || Messagetosend != null) {
            ToDo = Messagetosend;
        } 

        if (meet == meetstates.interm) {
            for (int i = 0; i < diooptions.Length; i++) {
                if (diooptions[i].situation == dio) {
                    if (caninteract) {
                        dioman.Startdio(diooptions[i], this.gameObject);
                        return;
                        //gameObject.SetActive(false);
                    }
                }
            }           

        }         
     

    }
}
