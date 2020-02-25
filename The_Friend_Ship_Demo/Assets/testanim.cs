using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testanim : MonoBehaviour
{

    public List<Animator> anima;
    public List<GameObject> AnimButtons;
    public bool Special;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (var item in this.gameObject.GetComponentsInChildren<Animator>()) {
            anima.Add(item);
            AnimButtons.Add(item.gameObject);
        }
        //anima[0].SetTrigger("Start");
        //anima[1].SetTrigger("Start");
        //anima[2].SetTrigger("Start");
        //anima[3].SetTrigger("Start");

        if (!Special) {
            foreach (var item in AnimButtons) {
                item.SetActive(false);
            }
        }

    }
    

  
}
