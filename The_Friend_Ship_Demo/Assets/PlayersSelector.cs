using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Image Select;
    Vector3 Center;

    public Animator anim;
    [SerializeField]
    //  public DiolaugeTrigger diotrigg;
    public XMarkgo marktrigg;

    public bool onmark;

    public bool goingS;
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
       


            if (mov != null && mov.move) {

                transform.position = new Vector3(Mathf.Clamp(trans.position.x, 0, Screen.width), Mathf.Clamp(trans.position.y, 0, Screen.height));
                finalpo = new Vector3(trans.position.x + (mov.DirxM[mov.steerint] * 20), trans.position.y + (mov.DiryM[mov.dirint] * 20));
                transform.position = Vector3.Lerp(trans.position, finalpo, .25f);

                // Debug.DrawLine(trans.position, hitt.collider.transform.position);
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(trans.position);
            if (Physics.Raycast(ray, out hit)) {
               

                if (hit.transform.GetComponent<XMarkgo>()) {

                    marktrigg = hit.transform.GetComponent<XMarkgo>();
                    marktrigg.select = this;


                    marktrigg.cantrigger = true;
                    onmark = true;


                } else if (marktrigg != null && !marktrigg.going) {
                    marktrigg.cantrigger = false;
                    onmark = false;

                }




                if (Input.GetButtonDown("Submit") && !onmark && !goingS && mov.move) {

                    mov.age.destination = hit.point;
                    anim.SetTrigger("Pointt");
                    goingS = false;


                }

            }

        }
    
}
