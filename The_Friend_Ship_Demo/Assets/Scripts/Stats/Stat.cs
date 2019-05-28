using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

  
    public class Stat
    {
    [SerializeField]
     int basevalue;

    public List<int> modifiers = new List<int>();
    public int getvalue()
    {
        int finalval = basevalue;
        modifiers.ForEach(x => finalval += x);
        return finalval;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }

    }


