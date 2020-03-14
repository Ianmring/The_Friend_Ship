using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using TMPro; 
    public class Tutorial_Manager : MonoBehaviour
{
    public movement mov;
    public Animator P1Steer;
    public Animator P2Steer;
  //  public Animator General;
    public Animator Parent;
    public Animator Info;
    public Image Horz;
    public Image Vert;
    public Color P1;
    public Color P2;
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
                 //   General.SetTrigger("Round");
                    Horz.color = P1;
                    Vert.color = P2;
                    break;
                case movement.PlayerSteering.P2:
                    P1Steer.SetTrigger("UpDown");
                    P2Steer.SetTrigger("LeftRight");
                //    General.SetTrigger("Round");
                    Horz.color = P2;
                    Vert.color = P1;
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
        //    General.SetTrigger("Done");
        mov.canswitch = true;
    }
    IEnumerator infoflash() {
        Info.SetTrigger("on");
        yield return new WaitForSeconds(3);
        Info.SetTrigger("off");
    }
}
