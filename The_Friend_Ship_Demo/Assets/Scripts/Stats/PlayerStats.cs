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

        Equipmana.instance.onEqupmentchange += onequipmentchanged;
        basehealth = 3;
        basespeed = 110;
        updatehealthandArmor();

    }

    // Update is called once per frame
    void onequipmentchanged(Equipment newitem , Equipment olditem)
    {
        healthmod = 0;
        movemod = 0;

        if (newitem != null)
        {
            Damage.AddModifier(newitem.OareDamModifyer);
            Speed.AddModifier(newitem.SpeedMod);
           Health.AddModifier(newitem.HealthMod);

            if (uimanager.UIinstance.playernums == uimanager.Players.player1)
            {
                P1Swing.AddModifier(newitem.SwingMod);
                P1Throw.AddModifier(newitem.ThrowMod);
            }
            else if (uimanager.UIinstance.playernums == uimanager.Players.player2)
            {
                P2Swing.AddModifier(newitem.SwingMod);
                P2Throw.AddModifier(newitem.ThrowMod);
            }


        }
        if (olditem != null)
        {
            Damage.RemoveModifier(olditem.OareDamModifyer);
            Speed.RemoveModifier(olditem.SpeedMod);
            Health.RemoveModifier(olditem.HealthMod);

            if (uimanager.UIinstance.playernums == uimanager.Players.player1)
            {
                P1Swing.RemoveModifier(olditem.SwingMod);
                P1Throw.RemoveModifier(olditem.ThrowMod);
            }
            else if (uimanager.UIinstance.playernums == uimanager.Players.player2)
            {
                P2Swing.RemoveModifier(olditem.SwingMod);
                P2Throw.RemoveModifier(olditem.ThrowMod);
            }


        }

        foreach (var healthboost in Health.modifiers)
            {
                healthmod += healthboost;

            }     
        foreach (var SpeedBoost in Speed.modifiers)
            {
                movemod += SpeedBoost;

            }
        foreach (var p1throwboost in P1Throw.modifiers)
        {
            P1_Launchmod += p1throwboost;
        }
        foreach (var p2throwboost in P2Throw.modifiers)
        {
            P2_Launchmod += p2throwboost;
        }
        foreach (var p1swingboost in P1Swing.modifiers)
        {
            P1_Swingmod += p1swingboost;
        }
        foreach (var p2swingboost in P2Swing.modifiers)
        {
            P2_Swintmod += p2swingboost;
        }



        updatehealthandArmor();
    }

    void updatehealthandArmor()
    {
        maxhealth = basehealth + healthmod;
        mov.speed = (basespeed + movemod)  / 10;

    }

}
