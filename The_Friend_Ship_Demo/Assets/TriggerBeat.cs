using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBeat : MonoBehaviour
{
    // Start is called before the first frame update

    bool isready;
    bool p1;
    bool p2;

    public SpriteRenderer p1I;
    public SpriteRenderer p2I;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<movement>() && GetComponent<MissionBeat>().mana.currentbeat !=0)
        {
            isready = true;

        }
    }
    private void Update()
    {
        if (isready)
        {
            p1I.gameObject.SetActive(true);
            p2I.gameObject.SetActive(true);
            if ((Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p1I.ToString())))
            {
                p1 = true;
                p1I.color = Color.green;
            }
            if ((Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p2I.ToString())))
            {
                p2 = true;
                p2I.color = Color.green;

            }
            if (p1 && p2)
            {
                if (!GetComponent<MissionBeat>().isdone && !GetComponent<MissionBeat>().mana.collectprize)
                {
                    this.gameObject.GetComponent<MissionBeat>().Beat();
                    StartCoroutine("Timecolor");

                 
                }

            }
        }
        else
        {
            p1I.gameObject.SetActive(false);
            p2I.gameObject.SetActive(false);
        }
       
        
    }
    IEnumerator Timecolor()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponentInChildren<Renderer>().material.color = Color.green;
        Destroy(p1I);
        Destroy(p2I);

        Destroy(this.GetComponentInChildren<Renderer>().gameObject);
    }
    private void OnTriggerExit(Collider other)
    {

        isready = false;

        
    }
}
