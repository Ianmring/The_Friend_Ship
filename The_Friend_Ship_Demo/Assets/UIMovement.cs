using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    RectTransform trans;
   public KeyitemTrigger Trig;
    launcher lanch;
   public Playergen player;
    float movmag;
    
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<RectTransform>();
        lanch = Trig.PL;
    }

    // Update is called once per frame
    void Update()
    {

        movmag = lanch.IReady * 20;
        if (!Trig.isaway) {
            transform.position = new Vector3(trans.position.x + (lanch.DirH * movmag), trans.position.y + (lanch.DirV * movmag));

        } else {
            transform.localPosition = new Vector3(0f, 0f);

        }
    }

    protected virtual void Dothing() {

    }
}
