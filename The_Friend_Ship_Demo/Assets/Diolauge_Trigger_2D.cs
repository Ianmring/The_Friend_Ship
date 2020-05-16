using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Diolauge_Trigger_2D : MonoBehaviour
{
    public string Name;

    public Diolauge NotMentionDio;
    public Diolauge MentionDio;
    public Diolauge IntermDio;
    public Diolauge PostDio;

    DiolaugeManager dioman;
    [SerializeField]

    bool caninteract;
    [SerializeField]
   
    public Diolauge[] diooptions;
    [SerializeField]

    bool there;
    //public SpriteRenderer Button1;
    //public SpriteRenderer Button2;

    //public GameObject And;
    //public GameObject Or;

    public bool p1;
    public bool p2;

    public Image P1;
    public Image P2;

    public enum meetstates2d { notmentioned, mentioned, interm, post }

    public meetstates2d meet;

    string ToDo;

    public Diolauge_Trigger_2D[] peoplemeet;
    public DiolaugeTrigger[] peoplemeet3d;
    [SerializeField]
    public bool minordeciss;

    public PlayersSelector select;

    public bool Item;

    public bool indoors;


    public Diolauge[] newreferenceinterm;
    public Diolauge[] newreferenceMention;
    public void Start() {
        dioman = FindObjectOfType<DiolaugeManager>();
        //   meet = meetstates.notmentioned;

    }
    private void OnEnable() {

        caninteract = false;
        // GetComponent<SphereCollider>().enabled = false;

        StartCoroutine("Abletointeract");
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayersSelector>()) {
            there = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<PlayersSelector>()) {


            there = false;

        }
    }
   
    public void newdiolauge() {
        meet = meetstates2d.mentioned;
       
            MentionDio = newreferenceMention[dioman.currentstorymoment];       
     
            IntermDio = newreferenceinterm[dioman.currentstorymoment];
        
    }
    public void newintermdio() {
        IntermDio = newreferenceinterm[dioman.currentstorymoment];

    }
    public void LateUpdate() {

        if (there) {
            P1.gameObject.SetActive(true);
            P2.gameObject.SetActive(true);

            if (Input.GetButtonDown(DiolaugeManager.DioInstance.p1C + "Submit" + DiolaugeManager.DioInstance.p1I.ToString())) {
                p1 = true;
                P1.color = Color.green;
                if (movement.MovInstance.Solo) {
                    p2 = true;
                    P2.color = Color.green;

                }

            }

            if (Input.GetButtonDown(DiolaugeManager.DioInstance.p2C + "Submit" + DiolaugeManager.DioInstance.p2I.ToString())) {
                p2 = true;
                P2.color = Color.green;
                if (movement.MovInstance.Solo) {
                    p1 = true;
                    P1.color = Color.green;

                }
            }
        } else {
            P1.gameObject.SetActive(false);
            P2.gameObject.SetActive(false);

            P1.color = uimanager.UIinstance.P1C;
            P2.color = uimanager.UIinstance.P2C;
        }

        if (p1 && p2 && !minordeciss) {
          
            // movement.MovInstance.age.destination = transform.localPosition;
          
                StartCoroutine("TriggerdioWait");
            
        }
        if ((p1 || p2) && minordeciss) {
          
           
                StartCoroutine("TriggerdioWait");
            
        }




    }
    IEnumerator TriggerdioWait() {
        yield return new WaitForSeconds(.1f);

        switch (meet) {
            case meetstates2d.notmentioned:
                minordeciss = true;

                dioman.Startdio(NotMentionDio, this.gameObject, true, indoors);

                ToDo = MentionDio.thingtodo;

                break;
            case meetstates2d.mentioned:
                minordeciss = true;

                dioman.Startdio(MentionDio, this.gameObject, true, indoors);

                meet = meetstates2d.interm;
                if (peoplemeet.Length != 0) {
                    foreach (var people in peoplemeet) {
                        people.meet = meetstates2d.mentioned;
                        people.minordeciss = false;
                    }
                }
                if (peoplemeet3d.Length != 0) {
                    foreach (var people in peoplemeet3d) {
                        people.meet = DiolaugeTrigger.meetstates.mentioned;
                        people.minordeciss = false;
                    }
                }
                ToDo = MentionDio.thingtodo;

                break;
            case meetstates2d.interm:
                minordeciss = true;

                dioman.Startdio(IntermDio, this.gameObject, true, indoors);

                ToDo = IntermDio.thingtodo;

                break;

            case meetstates2d.post:
                minordeciss = true;

                dioman.Startdio(PostDio, this.gameObject, true, indoors);

                ToDo = PostDio.thingtodo;

                break;

        }

        p1 = false;
        p2 = false;

      
       // select.goingS = false;

    }
    IEnumerator Abletointeract() {
        if (ToDo != null) {
            gameObject.SendMessage(ToDo, SendMessageOptions.DontRequireReceiver);
        }
        //Button1.color = Color.yellow;
        //Button2.color = Color.yellow;
        yield return new WaitForSeconds(.5f);
        // GetComponent<SphereCollider>().enabled = true;

        caninteract = true;
        // cantrigger = false;

    }

    public void Tstartdio(string dio, string Messagetosend) {

        if (Messagetosend != "N/A" || Messagetosend != null) {
            ToDo = Messagetosend;
        }


        for (int i = 0; i < diooptions.Length; i++) {
            if (diooptions[i].situation == dio) {
                Debug.Log("doneI");
                if (caninteract) {
                    if (Item) {
                        dioman.Startdio(diooptions[i], this.gameObject, true, indoors);
                      //  return;
                    } else {
                        dioman.Startdio(diooptions[i], this.gameObject, true, indoors);
                       // return;
                        //gameObject.SetActive(false);
                    }
                }
            }
        }




    }
}
