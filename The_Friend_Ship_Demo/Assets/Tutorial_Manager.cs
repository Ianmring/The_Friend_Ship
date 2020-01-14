using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class Tutorial_Manager : MonoBehaviour
{
    public movement mov;
    public Animator P1Steer;
    public Animator P2Steer;
    public Animator Parent;

    bool on;
    public void Start() {
        mov = movement.MovInstance;
       // MoveTutorial();
    }

    public void Fin() {
        on = true;

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
    public void MenuTutorial() {

    }

    IEnumerator WaittoDown() {
        yield return new WaitForSeconds(3);
        Parent.SetTrigger("off");
        yield return new WaitForSeconds(1.5f);
        P1Steer.SetTrigger("Done");
        P2Steer.SetTrigger("Done");
        mov.canswitch = true;
    }
}
