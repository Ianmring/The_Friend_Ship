using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, Mathf.Clamp(transform.localRotation.y, 1, 180), transform.localRotation.z);
        Debug.Log("iswork");
    }
}
