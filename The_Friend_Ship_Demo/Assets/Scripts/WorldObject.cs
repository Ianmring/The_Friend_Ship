using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : hit
{
    // Start is called before the first frame update
    public override void interact()
    {
        base.interact();
        Debug.Log(gameObject + " hit");
    }
}
