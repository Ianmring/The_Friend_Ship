using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionOrgonizer : MonoBehaviour
{
 public   Misson_Manager currentQuest;

  public  List<Misson_Manager> ActiveMissions;
    public List<Misson_Manager> CompletedMissions;

    public lookat Look;
    // Start is called before the first frame update
    void Start()
    {
        Look = FindObjectOfType<lookat>();
    }
    public void UpdateMissionComp()
    {

            Look.updatecompass();
        
    }
    // Update is called once per frame
 
}
