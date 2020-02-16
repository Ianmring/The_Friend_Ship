using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selector : MonoBehaviour
{

    float movmag;
    float xmax;
    float xmin;
    Vector3 finalpo;
    public RectTransform trans;
    public Playergen player;
    InventoryMenu Inventmen;


   public Sprite Grab;
    public Sprite Select;
    Vector3 Center;

    Animator anim;
  //  RaycastHit hitt;
    // Start is called before the first frame update
    void Start()
    {
        Inventmen = FindObjectOfType<InventoryMenu>();
        trans = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        Center = trans.position;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null ) {
          
            transform.position = new Vector3(Mathf.Clamp(trans.position.x, xmin, xmax), Mathf.Clamp(trans.position.y, 0, Screen.height));
            finalpo = new Vector3(trans.position.x + (player.MovH * movmag), trans.position.y + (player.MovV * movmag));
            transform.position = Vector3.Lerp(trans.position, finalpo, .25f);
        }


        if (Input.GetButtonDown("Submit" + player.playernum)) {
            anim.SetTrigger("Pointt");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(trans.position);
            if (Physics.Raycast(ray, out hit)) {
             //   hitt = hit;
                  Debug.Log(hit.collider.gameObject);
               
            }

        } else {
        }
       // Debug.DrawLine(trans.position, hitt.collider.transform.position);
    }
  
    public void Centerpos() {
        transform.position = Center;
    }

    public void PointAssignplayer(Playergen play, KeyitemTrigger Trigg) {
        trans = GetComponent<RectTransform>();

        player = play;
       
        // ISlot.isspawned = true;
        movmag = 20;
        // play.playercanvas.sortingOrder = Trig.KI.layer;
      // Center = Trigg.Itemslide.handleRect.position;

        switch (play.direction) {
            case 0:
                xmin = Screen.width * .4f;
                xmax = Screen.width;
                break;
            case 1:
                xmin = 0;
                xmax = Screen.width * .6f;
                break;

        }
        //transform.SetParent(Trig.Itemslide.handleRect);
    }
}
