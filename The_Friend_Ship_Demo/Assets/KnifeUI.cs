using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeUI : UIMovement
{
    public int multi;
    float vek;
    // Start is called before the first frame update
    public Transform dir;

    Vector3 dirrect;
    // Update is called once per frame
    public override void Lateupfunt() {
        base.Lateupfunt();

       vek = Mathf.Atan2( -player.DirH, player.DirV) *Mathf.Rad2Deg ;
        dir.eulerAngles = new Vector3(0,0 ,vek );

        //transform.rotation = Quaternion.LookRotation()
    }

    
}
