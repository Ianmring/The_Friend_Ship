using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyself : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(this.gameObject, 3);
    }

}
