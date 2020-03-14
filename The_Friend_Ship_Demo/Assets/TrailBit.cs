using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrailBit : MonoBehaviour
{

    public enum Trail { almond, peanut, rasin }
    public Trail Mixtypes;
    public Sprite[] mixtypes;
    public bool onother;
    public Transform trans;
    bool onbench;
    public float min;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-65, 65), Random.Range(-65, 65));
        GetComponentInChildren<Image>().GetComponent<Transform>().rotation =  Quaternion.Euler(0, 0, Random.Range(0,359));
       // GetComponent<RectTransform>().sizeDelta = new Vector2(100, 200);

        int mixtype = Random.Range(0, 4);
       Mixtypes = (TrailBit.Trail)mixtype;
        GetComponentInChildren<Image>().sprite = mixtypes[mixtype];

        switch (Mixtypes) {
            case TrailBit.Trail.almond:
                GetComponentInChildren<Image>().sprite = mixtypes[0];

                break;
            case TrailBit.Trail.peanut:
                GetComponentInChildren<Image>().sprite = mixtypes[1];

                break;
            case TrailBit.Trail.rasin:
                GetComponentInChildren<Image>().sprite = mixtypes[2];

                break;

        }
        onbench = false;
    }


    private void LateUpdate() {
        if (onbench) {
            transform.position = new Vector3(trans.position.x, Mathf.PingPong(Time.time * 7, max - min) + min, transform.position.z);
        }
    }

    public void movetoBench() {
        // transform.SetParent(game.transform);
        transform.localPosition = new Vector3(Random.Range(-300, 150), Random.Range(-65, 65));
        GetComponentInChildren<Image>().GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        trans = GetComponent<Transform>();
        min = trans.position.y -10 ;
        max = trans.position.y + 10;
        onbench = true;

    }

    public void movetoBag() {
        transform.localPosition = new Vector3(Random.Range(-65, 65), Random.Range(-65, 65));
        GetComponentInChildren<Image>().GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        onbench = false;

    }



}
