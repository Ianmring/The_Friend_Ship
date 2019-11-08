using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CurrentStats
{
    // Start is called before the first frame update

    int healthmod;
    float movemod;

    float P1_Launchmod;
    float P2_Launchmod;
    float P1_Swingmod;
    float P2_Swintmod;
    movement mov;

    public float basesP1Throw { get; set; }
    public float basesP2Throw { get; set; }

    public float basesP1Swing { get; set; }
    public float basesP2Swing { get; set; }


    public Stat P1Throw;
    public Stat P2Throw;
    public Stat P1Swing;
    public Stat P2Swing;

    private void Awake()
    {
        mov = GetComponent<movement>();
    }
    void Start()
    {

        basehealth = 3;
        basespeed = 110;
        updatehealthandArmor();

    }

    // Update is called once per frame
    

    void updatehealthandArmor()
    {
        maxhealth = basehealth + healthmod;
        mov.speed = (basespeed + movemod)  / 10;

    }

}
