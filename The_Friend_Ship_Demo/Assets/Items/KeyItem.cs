using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Key Item")]

public class KeyItem : Item
{

    public enum KeyitemType { NA, ParaScope, Map, Compass, ClipBoard }
    public KeyitemType KeyItemType;
    // Start is called before the first frame update

}
