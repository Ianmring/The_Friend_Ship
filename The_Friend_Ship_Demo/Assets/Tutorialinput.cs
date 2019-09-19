using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorialinput : MonoBehaviour
{
    public movement mov;
    public GameObject[] turorials;
    private readonly bool[] set = new bool[4];

    GameObject tutorial;

    bool sub1;
    bool sub2;
    bool end;
    private void Start()
    {
        tutorial = GameObject.Find("Tutorial");
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        if (!end) { 
        switch (mov.moving)
        {
            case movement.Moving.Forwad:
                turorials[0].GetComponent<Image>().color = Color.green;
              //  GameObject.Destroy(turorials[0]);
                set[0] = true;
                break;
            case movement.Moving.Backwards:
                turorials[1].GetComponent<Image>().color = Color.green;
              //  GameObject.Destroy(turorials[1]);
                set[1] = true;
                break;
            default:
                if (set[0])
                {
                    turorials[0].GetComponent<Image>().color = Color.yellow;

                }
                if (set[1])
                {
                    turorials[1].GetComponent<Image>().color = Color.yellow;

                }
                break;

        }
            switch (mov.turning)
            {
                case movement.Turning.Clockwise:
                    foreach (var ima in turorials[2].GetComponentsInChildren<Image>())
                    {
                        ima.color = Color.green;
                    }
                    //  GameObject.Destroy(turorials[2]);
                    set[2] = true;
                    break;
                case movement.Turning.AniClockwise:
                    foreach (var ima in turorials[3].GetComponentsInChildren<Image>())
                    {
                        ima.color = Color.green;
                    }
                    //GameObject.Destroy(turorials[3]);
                    set[3] = true;
                    break;
                default:
                    if (set[2])
                    {
                        foreach (var ima in turorials[2].GetComponentsInChildren<Image>())
                        {
                            ima.color = Color.yellow;
                        }
                    }
                    if (set[3])
                    {
                        foreach (var ima in turorials[3].GetComponentsInChildren<Image>())
                        {
                            ima.color = Color.yellow;
                        }
                    }
                    break;

            }
        }

        if (set[0] && set[1] && set[2] && set[3] && mov.moving == movement.Moving.Not && mov.turning == movement.Turning.Not)
        {
            end = true;
            tutorial.GetComponentInChildren<Text>().text = "Done!";

        }


    }
    private void Update()
    {
       
        if (end && Input.GetButton("Submit1"))
        {
            sub1 = true;
        }
        if (end && Input.GetButton("Submit2"))
        {
            sub2 = true;
        }


        if (sub1 || sub2 )
        {
            tutorial.GetComponent<Image>().color = Color.yellow;
            if (end && sub1 && sub2)
            {
                tutorial.GetComponent<Image>().color = Color.green;

                StartCoroutine("Finish");
            }
        }
        
    }
    IEnumerator Finish()
    {
        turorials[0].GetComponent<Image>().color = Color.green;
        turorials[1].GetComponent<Image>().color = Color.green;
        foreach (var ima in turorials[2].GetComponentsInChildren<Image>())
        {
            ima.color = Color.green;
        }
        foreach (var ima in turorials[3].GetComponentsInChildren<Image>())
        {
            ima.color = Color.green;
        }


        yield return new WaitForSeconds(3);
        foreach (var item in turorials)
        {
            Destroy(item);
        }
        Destroy(this);
    }
}
