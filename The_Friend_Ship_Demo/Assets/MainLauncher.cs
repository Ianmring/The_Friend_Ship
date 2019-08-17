using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLauncher : MonoBehaviour
{
    // Start is called before the first frame update
     float Dir1H;

     float Dir1V;

     float Dir2H;

     float Dir2V;

   public  float Yvect1;
     public float Yvect2;

    public float delta;

    movement dirData;

    public bool sett;
    bool update;
//    public bool isempty { get; set; }
   // public Transform Player;

   // public PersonalItemSlot Slot;
    float DirVTotal;
     float DirHTotal;
     float DirVTotal2;
     float DirHTotal2;
    public float dirTotal;


    public float Ready1;
    public float Ready2;

    public float launchMulti;
    public float uplaunchMulti;
   // public inventorygeneral invt;

    public Vector3 Dir;
    public float Yvect;

    public launcher P1 { get; set; }
    public launcher P2 { get; set; }

    public inventorygeneral p1I;
    public inventorygeneral p2I;

    public bool isready { get; set; }

    public float dirtotal;

    public float totaldir;
    bool p1set;
     bool p2set;
    bool p1done;
    bool p2done;

  public  List<hit> inrage;
    // Start is called before the first frame update
    void Start()
    {
        dirData = GameObject.FindObjectOfType<movement>();

        dirData.ML = this;

        p1set = false;
        p1done = true;
        p2set = false;
        p2done = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (movement.MovInstance.PlayersSet)
        {
      
        Ready1 = P1.Ready;
        Ready2 = P2.Ready;

       
            if (p1set && p2set && !p1done && !p2done)
            {
                Debug.Log("Hit");
                foreach (var obj in inrage)
                {
                    obj.interact();
                }
                p1done = true;
                p2done = true;
            }
            if (Ready1 == 1 && !p1done)
            {

                StartCoroutine("P1swing");
            }
            else if (Ready1 <= .6)
            {
                p1done = false;
            }

            if (Ready2 == 1 && !p2done)
            {
                StartCoroutine("P2swing");
            }
            else if (Ready2 <= .6)
            {
                p2done = false;
            }

          
        }
        }

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<hit>())
        {
            if (inrage.Contains(other.GetComponent<hit>()))
            {
                return;

            }
            else
            {
                inrage.Add(other.gameObject.GetComponent<hit>());

            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<hit>())
        {
            inrage.Remove(other.gameObject.GetComponent<hit>());
        }
    }

    //IEnumerator Range()
    //{
    //    sett = true;
    //    yield return new WaitForSeconds(1);
    //    sett = false;
    //}
    IEnumerator P1swing()
    {
        //p1set = true;
        p1set = true;
        p1done = false;
        yield return new WaitForSeconds(.1f);
        p1set = false;
        p1done = true;

    }
    IEnumerator P2swing()
    {
        p2set = true;
        p2done = false;
        yield return new WaitForSeconds(.1f);
        //    p2set = true;
        p2set = false;
        p2done = true;
    }

}



