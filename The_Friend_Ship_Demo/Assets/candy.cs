using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class candy : MonoBehaviour
{
    public Sprite[] Candycolors;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-300, 150), Random.Range(-70, 70));
     //   transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        int mixtype = Random.Range(0, 3);
        GetComponent<Image>().sprite = Candycolors[mixtype];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
