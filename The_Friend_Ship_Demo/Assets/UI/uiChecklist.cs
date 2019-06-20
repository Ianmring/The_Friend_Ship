using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uiChecklist : MonoBehaviour
{

     Text Co;
    MissionOrgonizer missman;
    // Start is called before the first frame update
    void Awake()
    {
        missman = FindObjectOfType<MissionOrgonizer>();
        Co = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (missman.currentQuest != null)
        {
            Co.text = missman.currentQuest.Beat[missman.currentQuest.currentbeat].Task;

        }
        else
        {
            Co.text = null;
            return;
        }


    }
}


