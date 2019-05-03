using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentType equipslot;

    public int OareDamModifyer;
    public int SpeedMod;
    public int HealthMod;

    public int ThrowMod;
    public int SwingMod;

    public override void Use()
    {
        base.Use();


        Equipmana.instance.Equip(this);
    }
}

public enum EquipmentType{ Oare,Hat}
