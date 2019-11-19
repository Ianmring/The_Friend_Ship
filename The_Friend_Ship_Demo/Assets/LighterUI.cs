using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LighterUI : MonoBehaviour
{
    UIMovement uimain;
    Playergen player;
    KeyitemTrigger trigg;
   public Sprite[] lightstates;
    Image lighter;
    public bool islight;
    int numberofstrikes;
    int strikes;

    void Start() {
        uimain = gameObject.GetComponent<UIMovement>();
        player = uimain.player;
        trigg = uimain.Trig;
        lighter = GetComponent<Image>();
        numberofstrikes = Random.Range(5, 8);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonUp("Submit" + player.playernum.ToString()) && trigg.isusing && !islight && strikes < numberofstrikes) {
            strikes++;
        } else if (strikes >= numberofstrikes && trigg.isusing) {
            islight = true;
        } else if (!trigg.isusing) {
            islight = false;
            strikes = 0;
        }

        if (islight) {
            lighter.sprite = lightstates[1];
        } else {
            lighter.sprite = lightstates[0];
        }


    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "OBJ") {
            Debug.Log("collide");
        }
    }
}
