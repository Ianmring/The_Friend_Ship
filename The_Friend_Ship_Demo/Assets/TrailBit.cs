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

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-65, 65), Random.Range(-65, 65));
        transform.rotation =  Quaternion.Euler(0, 0, Random.Range(0,359));
        GetComponent<RectTransform>().sizeDelta = new Vector2(100, 200);

        int mixtype = Random.Range(0, 4);
        GetComponent<TrailBit>().Mixtypes = (TrailBit.Trail)mixtype;
        GetComponent<Image>().sprite = mixtypes[mixtype];

        switch (Mixtypes) {
            case TrailBit.Trail.almond:
                GetComponent<Image>().sprite = mixtypes[0];

                break;
            case TrailBit.Trail.peanut:
                GetComponent<Image>().sprite = mixtypes[1];

                break;
            case TrailBit.Trail.rasin:
                GetComponent<Image>().sprite = mixtypes[2];

                break;

        }

    }
    

    //private void OnTriggerEnter(Collider other) {
    //    if (other.GetComponent<candy>() && other.GetComponent<TrailBit>()) {
    //        transform.localPosition = new Vector3(Random.Range(-300, 150), Random.Range(-70, 70));
    //        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
    //    }
    //}
    public void movetoBench() {
        // transform.SetParent(game.transform);
        transform.localPosition = new Vector3(Random.Range(-300, 150), Random.Range(-65, 65));
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
    }

    public void movetoBag() {
        transform.localPosition = new Vector3(Random.Range(-65, 65), Random.Range(-65, 65));
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
    }
   

  
}
