using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    RectTransform trans;
   public KeyitemTrigger Trig;
   public Playergen player;
    float movmag;
    float xmax;
    float xmin;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<RectTransform>();
        player = Trig.PL;
        movmag = 20;

        switch (player.direction) {
            case 0:
                xmin= Screen.width * .4f;
                xmax = Screen.width;
                break;
            case 1:
                xmin = 0;
                xmax = Screen.width * .6f;
                break;
          
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        
        if (!Trig.isaway) {
            transform.position = new Vector3(trans.position.x + (player.DirH * movmag), trans.position.y + (player.DirV * movmag));
            transform.position = new Vector3(Mathf.Clamp(trans.position.x, xmin, xmax), Mathf.Clamp(trans.position.y, 0, Screen.height));
        } else {
            transform.localPosition = new Vector3(0f, 0f);

        }
    }

    protected virtual void Dothing() {

    }
}
