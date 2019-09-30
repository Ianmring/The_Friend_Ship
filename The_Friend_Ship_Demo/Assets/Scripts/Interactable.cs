﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public Vector3 inteactionpoint;

    public SphereCollider thiscol;

    public enum InteactionType { obj, NPC, QuestMark };

    public InteactionType Type;

   public bool diointoer;
    public bool dio;

    public void Start()
    {


        thiscol = this.GetComponent<SphereCollider>();
        thiscol.radius = radius;
        thiscol.center = inteactionpoint;
        diointoer = false;
        dio = true;

    }
    public virtual void Interact()
    {
        Debug.Log("do");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<movement>())
        {
           // intoer = true;
            if (GetComponent<itempickup>())
            {
                Interact();

            }
            else
            {
                
                diointoer = true;
            }
        }
    }
    public void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {

        diointoer = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }

}
