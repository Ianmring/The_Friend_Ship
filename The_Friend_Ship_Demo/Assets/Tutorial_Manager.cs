using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro; 
    public class Tutorial_Manager : MonoBehaviour
{
    public movement mov;
    public Animator P1Steer;
    public Animator P2Steer;
    public Animator Parent;
    public Animator Info;
    bool on;
    public void Start() {
        mov = movement.MovInstance;
       // MoveTutorial();
    }

    public void Fin() {
        on = true;
        Tutorial(new Vector3(0, 150, 0) , "Use the Right Sticks to move the cursor along your player’s axis and Y to swap axes");
        MoveTutorial();
    }
    public void MoveTutorial() {

        if (on) {


            Parent.SetTrigger("on");
            switch (mov.steer) {
                case movement.PlayerSteering.P1:
                    P1Steer.SetTrigger("LeftRight");
                    P2Steer.SetTrigger("UpDown");
                    break;
                case movement.PlayerSteering.P2:
                    P1Steer.SetTrigger("UpDown");
                    P2Steer.SetTrigger("LeftRight");
                    break;

            }
            StartCoroutine("WaittoDown");
        }
    }
    public void Tutorial(Vector3 newpos , string text) {
        Info.gameObject.transform.localPosition = newpos;
        Info.GetComponentInChildren<TextMeshProUGUI>().text = text;
        StartCoroutine("infoflash");

    }

    IEnumerator WaittoDown() {
        yield return new WaitForSeconds(3);
        Parent.SetTrigger("off");
        yield return new WaitForSeconds(1.5f);
        P1Steer.SetTrigger("Done");
        P2Steer.SetTrigger("Done");
        mov.canswitch = true;
    }
    IEnumerator infoflash() {
        Info.SetTrigger("on");
        yield return new WaitForSeconds(3);
        Info.SetTrigger("off");
    }
}
