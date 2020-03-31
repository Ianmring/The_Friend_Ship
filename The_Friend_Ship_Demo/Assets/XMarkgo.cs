﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class XMarkgo : MonoBehaviour {

    public SpriteRenderer Button1;
    public SpriteRenderer Button2;

    public GameObject And;
    public GameObject Or;

    public bool cantrigger;
   
    bool minordeciss;
    public bool there;
    public bool going;

    bool p1;
    bool p2;
    public PlayersSelector select;

    public DiolaugeTrigger trigger;

    NavMeshObstacle navobstical;

    public SphereCollider ParentTrigger;

    public void Start() {
        if (GetComponentInParent<DiolaugeTrigger>()) {
            trigger = GetComponentInParent<DiolaugeTrigger>();
            ParentTrigger = trigger.GetComponent<SphereCollider>();
        }
        navobstical = GetComponent<NavMeshObstacle>();
    }
    private void OnTriggerEnter(Collider other) {


        if (other.GetComponent<movement>()) {
            there = true;
            going = false;
            select.goingS = false;
            cantrigger = false;
           // StartCoroutine("Delaynavon");
        }



    }
    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<movement>()) {


            there = false;
            StartCoroutine("Delaynavon");
        }
    }
    public void LateUpdate() {

        if (cantrigger) {

            Button1.gameObject.SetActive(true);
            Button2.gameObject.SetActive(true);

            if (trigger == null) {
                Or.SetActive(true);
            } else {
                if (trigger.minordeciss) {
                    Or.SetActive(true);
                    And.SetActive(false);

                } else {
                    Or.SetActive(false);
                    And.SetActive(true);
                }
            }

            if (Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p1I.ToString())) {
                if (trigger==null) {
                    navobstical.enabled = false;

                    movement.MovInstance.age.destination = transform.position;
                    going = true;
                    select.goingS = true;
                    cantrigger = true;
                } else {

                    p1 = true;
                    trigger.p1 = p1;
                    minordeciss = trigger.minordeciss;

                }
                Button1.color = Color.green;
                
            }
            if (Input.GetButtonDown("Submit" + DiolaugeManager.DioInstance.p2I.ToString())) {
                if (trigger == null) {
                    navobstical.enabled = false;

                    movement.MovInstance.age.destination = transform.position;
                    going = true;
                    select.goingS = true;
                    cantrigger = true;
                } else {
                    p2 = true;
                    trigger.p2 = p2;
                    minordeciss = trigger.minordeciss;

                }
                Button2.color = Color.green;
                

            }

          
            if (trigger != null) {

               if(!minordeciss && p1 && p2) {
                    navobstical.enabled = false;
                    ParentTrigger.radius = 0.1f;

                    movement.MovInstance.age.destination = transform.position;
                    trigger.select = select;
                    going = true;
                    select.goingS = true;
                    cantrigger = true;
                } else if (minordeciss && (p1 || p2)) {
                    navobstical.enabled = false;
                    ParentTrigger.radius = 0.1f;

                    movement.MovInstance.age.destination = transform.position;
                    trigger.select = select;
                    going = true;
                    select.goingS = true;
                    cantrigger = true;
                } 
            }

            




        } else {
            
            Button1.gameObject.SetActive(false);
            Button2.gameObject.SetActive(false);
          
            Or.SetActive(false);
            And.SetActive(false);

            p1 = false;
            p2 = false;
            Button1.color = uimanager.UIinstance.P1C;
            Button2.color = uimanager.UIinstance.P2C;


        }

    }
    IEnumerator Delaynavon() {
        yield return new WaitForSeconds(1);
        navobstical.enabled = true;
        if (ParentTrigger != null) {
            ParentTrigger.radius = 1;

        }
    }
}
