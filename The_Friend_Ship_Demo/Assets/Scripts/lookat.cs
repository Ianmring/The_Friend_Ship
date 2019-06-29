using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update
    MissionOrgonizer missO;

    // Update is called once per frame

    private void Start()
    {
        missO = FindObjectOfType<MissionOrgonizer>();
    }
    void Update()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            transform.LookAt(target);
        }
    }
    public void updatecompass()
    {
        if (missO.currentQuest == null)
        {
            return;
        }
        else
        {
            target = missO.currentQuest.Beat[missO.currentQuest.currentbeat].GetComponent<Transform>();
        }
    }
}
