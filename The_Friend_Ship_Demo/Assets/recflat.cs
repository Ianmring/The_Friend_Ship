using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recflat : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    RectTransform dis;
    private void Start()
    {
        dis = this.GetComponent<RectTransform>();
    }
    void Update()
    {
        dis.eulerAngles = new Vector3(0, 0, 0);
    }
}
