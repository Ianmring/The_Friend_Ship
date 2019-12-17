using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    public RectTransform trans;
   public KeyitemTrigger Trig;
   public Playergen player;
    float movmag;
    float xmax;
    float xmin;

    public enum playerholding { p1,p2};
    public playerholding hold;

  public  GameObject targetobj;

    Vector3 finalpo;
    // Start is called before the first frame update
    void Start()
    {
        startingfunt();
    }
    void LateUpdate() 
    {

        Lateupfunt();

    }
    public virtual void startingfunt() {
        trans = GetComponent<RectTransform>();
        player = Trig.PL;
        movmag = 20;
        player.playercanvas.sortingOrder = Trig.KI.layer;
        switch (player.direction) {
            case 0:
                xmin = Screen.width * .4f;
                xmax = Screen.width;
                hold = playerholding.p1;
                break;
            case 1:
                xmin = 0;
                xmax = Screen.width * .6f;
                hold = playerholding.p2;
                break;

        }
    }
    public virtual void Lateupfunt() {
        if (!Trig.isaway) {       

           // transform.position = new Vector3(trans.position.x + (player.DirH * movmag), trans.position.y + (player.DirV * movmag));
           
            transform.position = Vector3.Lerp(trans.position, finalpo , .25f);
            finalpo = new Vector3(trans.position.x + (player.DirH * movmag), trans.position.y + (player.DirV * movmag));
            transform.position = new Vector3(Mathf.Clamp(trans.position.x, xmin, xmax), Mathf.Clamp(trans.position.y, 0, Screen.height));
        } else {
            transform.localPosition = new Vector3(0f, 0f);

        }

        if (Input.GetButtonDown("Submit" + player.playernum)) {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(trans.position);
            if (Physics.Raycast(ray, out hit)) {
             //   Debug.Log(hit.collider.gameObject);
                targetobj = hit.collider.gameObject;
                Interactui();
            }

            //Vector3 point;
            //point = Camera.main.ScreenToWorldPoint(new Vector3(trans.position.x, trans.position.y));

            //Debug.Log(point);
        } else {
            targetobj = null;
        }
    }

    public virtual void Interactui() {

    }
    // Update is called once per frame
   


}
