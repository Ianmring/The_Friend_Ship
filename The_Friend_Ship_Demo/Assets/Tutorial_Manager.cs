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
    public GameObject Info;
    public Animator play;
    public Image Horz;
    public Image Vert;
    public Color P1;
    public Color P2;
    bool on;

  public  bool infoon;
    #region Singelton
    public static Tutorial_Manager tootinstance;

    private void Awake() {
        tootinstance = this;
    }
    #endregion

    public void Start() {
        mov = movement.MovInstance;
       // MoveTutorial();
    }

    public void Fin() {

       
        Tutorial(new Vector3(0, 150, 0) , "Use the Right Sticks to move the cursor along your player’s axis or IKJL if you're on a Keyboard \n \n Press A to go to that location or Space if you're on a keyboard \n \n Press Y to swap axes or G if you're on a keyboard");
        if (mov.Solo) {
            mov.SwapPlayers();
        }
        on = true;
        MoveTutorial();
    }
    private void OnEnable() {
        if (on) {
            switch (mov.steer) {
                case movement.PlayerSteering.P1:

                    play.SetTrigger("Turnp1");

                    break;
                case movement.PlayerSteering.P2:

                    play.SetTrigger("Turnp2");

                    break;

            }
        }
      
    }

   
    public void MoveTutorial() {

        if (on) {


            Parent.SetTrigger("on");
            switch (mov.steer) {
                case movement.PlayerSteering.P1:

                    if (mov.P1G.iskeyboard) {
                        P1Steer.SetTrigger("LeftRightKey");
                    } else {
                        P1Steer.SetTrigger("LeftRight");
                    }


                    if (mov.P2G.iskeyboard) {
                        P2Steer.SetTrigger("UpDownKey");
                    } else {
                        P2Steer.SetTrigger("UpDown");
                    }
                    play.SetTrigger("Turnp1");
                    //Horz.color = P1;
                    //Vert.color = P2;
                    break;
                case movement.PlayerSteering.P2:

                    if (mov.P1G.iskeyboard) {
                        P1Steer.SetTrigger("UpDownKey");
                    } else {
                        P1Steer.SetTrigger("UpDown");

                    }

                    if (mov.P2G.iskeyboard) {
                        P2Steer.SetTrigger("LeftRightKey");

                    } else {
                        P2Steer.SetTrigger("LeftRight");
                    }
                    play.SetTrigger("Turnp2");
                    //Horz.color = P2;
                    //Vert.color = P1;
                    break;

            }
            StartCoroutine("WaittoDown");
        }
    }
    public void Tutorial(Vector3 newpos , string text) {
        Info.SetActive(true);
        Info.gameObject.transform.localPosition = newpos;
        Info.GetComponentInChildren<TextMeshProUGUI>().text = text;
        infoon = true;
      //  Info.SetTrigger("on");

    }
    public void Tutorialoff() {

        Info.SetActive(false);
        infoon = false;

    }


    IEnumerator WaittoDown() {
        yield return new WaitForSeconds(3);
        Parent.SetTrigger("off");
        yield return new WaitForSeconds(1f);
        P1Steer.SetTrigger("Done");
        P2Steer.SetTrigger("Done");
        //    General.SetTrigger("Done");
        mov.canswitch = true;
    }


  

}
