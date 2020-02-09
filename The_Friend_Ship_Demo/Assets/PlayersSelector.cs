using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSelector : MonoBehaviour {
    float movmag;
    float xmax;
    float xmin;
    Vector3 finalpo;
    public RectTransform trans;
    //public Playergen player;
    InventoryMenu Inventmen;
    public movement mov;

    public Sprite Grab;
    public Sprite Select;
    Vector3 Center;

    Animator anim;
    [SerializeField]
   public DiolaugeTrigger diotrigg;
    //  RaycastHit hitt;
    // Start is called before the first frame update
    void Start() {
        Inventmen = FindObjectOfType<InventoryMenu>();
        trans = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        mov = FindObjectOfType<movement>();
        Center = trans.position;
        //  gameObject.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate() {
        if (mov != null && mov.move ) {

            transform.position = new Vector3(Mathf.Clamp(trans.position.x, 0, Screen.width), Mathf.Clamp(trans.position.y, 0, Screen.height));
            finalpo = new Vector3(trans.position.x + (mov.DirxM[mov.steerint] * 20), trans.position.y + (mov.DiryM[mov.dirint] * 20));
            transform.position = Vector3.Lerp(trans.position, finalpo, .25f);


                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(trans.position);
                if (Physics.Raycast(ray, out hit)) 
                {
                //   hitt = hit;

                
                if (hit.transform.GetComponent<DiolaugeTrigger>() != null) {
                    diotrigg = hit.transform.GetComponent<DiolaugeTrigger>();
                    if (!diotrigg.cantrigger) {
                        diotrigg.cantrigger = true;
                       
                    }
                  

                } else {
                    if (diotrigg != null && !diotrigg.going) {
                        diotrigg.cantrigger = false;
                        diotrigg = null;

                    }

                    if (Input.GetButtonDown("Submit")) {

                        mov.age.destination = hit.point;
                        anim.SetTrigger("Pointt");


                    }
                }

                }




            // Debug.DrawLine(trans.position, hitt.collider.transform.position);
        } 


    } }
