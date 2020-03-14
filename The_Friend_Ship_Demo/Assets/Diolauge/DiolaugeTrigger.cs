using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiolaugeTrigger : MonoBehaviour {

   // public string Name;

    public Diolauge NotMentionDio;
    public Diolauge MentionDio;
    public Diolauge IntermDio;
    public Diolauge PostDio;

    DiolaugeManager dioman;
    [SerializeField]

    bool caninteract;
    [SerializeField]
  public  bool cantrigger;
    public bool going;
  public  bool there;
    public Diolauge[] diooptions;
    [SerializeField]

    //public SpriteRenderer Button1;
    //public SpriteRenderer Button2;

    //public GameObject And;
    //public GameObject Or;

 public   bool p1;
public    bool p2;

    public enum meetstates { notmentioned, mentioned, interm , post}

   public meetstates meet;
  
    string ToDo;

   public DiolaugeTrigger[] peoplemeet;
    [SerializeField]
   public bool minordeciss;

    public PlayersSelector select;

    public bool Item;

    public void Start() {
        dioman = FindObjectOfType<DiolaugeManager>();
     //   meet = meetstates.notmentioned;

    }
    private void OnEnable() {

        caninteract = false;
        
      
        StartCoroutine("Abletointeract");
    }
    private void OnTriggerEnter(Collider other) {


        if (other.GetComponent<movement>()) {
            there = true;

        }



    }
    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<movement>() ) {


            there = false;

        }
    }
    public void LateUpdate() {

        //if (cantrigger) {

            //Button1.gameObject.SetActive(true);
            //Button2.gameObject.SetActive(true);
            //if (Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p1I.ToString())) {
            //    p1 = true;
            //    Button1.color = Color.green;
            //}
            //if (Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p2I.ToString())) {
            //    p2 = true;
            //    Button2.color = Color.green;

            //}
            if (p1 && p2 && !minordeciss ) {
                select.goingS = true;
               // movement.MovInstance.age.destination = transform.localPosition;
                going = true;
                if (there && going) {
                    StartCoroutine("TriggerdioWait");
                }

            }
            if ((p1 || p2) && minordeciss) {
                select.goingS = true;

              //  movement.MovInstance.age.destination = transform.localPosition;
                going = true;
                if (there && going) {
                    StartCoroutine("TriggerdioWait");
                }
            }

            //if (minordeciss) {
            //    Or.SetActive(true);
            //    And.SetActive(false);

            //} else if (!minordeciss) {
            //    Or.SetActive(false);
            //    And.SetActive(true);
            //}

        //} else {
        //    Button1.gameObject.SetActive(false);
        //    Button2.gameObject.SetActive(false);
        //    Or.SetActive(false);
        //    And.SetActive(false);
        //    //Button1.color = Color.red;
        //    //Button2.color = Color.blue;
        //}

   

    }
    IEnumerator TriggerdioWait() {
        yield return new WaitForSeconds(.1f);

        switch (meet) {
            case meetstates.notmentioned:
                minordeciss = true;

                dioman.Startdio(NotMentionDio, this.gameObject , true);

                ToDo = MentionDio.thingtodo;
                
                break;
            case meetstates.mentioned:
                minordeciss = true;

                dioman.Startdio(MentionDio, this.gameObject , true);

                meet = meetstates.interm;

                foreach (var people in peoplemeet) {
                    people.meet = meetstates.mentioned;
                    people.minordeciss = false;
                }
                              
                ToDo = MentionDio.thingtodo;
                
                break;
            case meetstates.interm:
                minordeciss = true;

                dioman.Startdio(IntermDio, this.gameObject, true);

                ToDo = IntermDio.thingtodo;
                
                break;

            case meetstates.post:
                minordeciss = true;

                dioman.Startdio(PostDio, this.gameObject, true);

                ToDo = PostDio.thingtodo;

                break;
           
        }
            
        p1 = false;
        p2 = false;
       
        cantrigger = false;
        going = false;
        select.goingS = false;

    }
    IEnumerator Abletointeract()
    {
        if (ToDo != null) {
            gameObject.SendMessage(ToDo, SendMessageOptions.DontRequireReceiver);
        }
        //Button1.color = Color.yellow;
        //Button2.color = Color.yellow;
        yield return new WaitForSeconds(.5f);
        caninteract = true;
       // cantrigger = false;
        
    }

    public void Tstartdio(string dio, string Messagetosend) {

        if (Messagetosend != "N/A" || Messagetosend != null) {
            ToDo = Messagetosend;
        }

       
            for (int i = 0; i < diooptions.Length; i++) {
                if (diooptions[i].situation == dio) {
                    if (caninteract) {
                    if (Item) {
                        dioman.Startdio(diooptions[i], this.gameObject, true);
                        return;
                    } else {
                        dioman.Startdio(diooptions[i], this.gameObject, true);
                        return;
                        //gameObject.SetActive(false);
                    }
                    }
                }
            }           

                
     

    }
}
