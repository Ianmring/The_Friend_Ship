using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerselect : MonoBehaviour {
    // Start is called before the first frame update
    public bool iscontorller;
    public bool contchosen;
    public int p1;
    public int p2;
    public int controllercount;
    public GameObject player;
    GameObject Boat;

    public GameObject Hold;

    GameObject Player1;
    GameObject Player2;


    public GameObject p1chk;
    public GameObject p2chk;

    public enum player1 { Cont1, Cont2, notselected }

    player1 play;

    bool countdown;

    float timer;

    public Text ctdwntext;

  //  public Text InstructionalText;
    //public int playernumbers;
    void Start() {

        ctdwntext.text = "Player 1 Press A";

        Boat = FindObjectOfType<movement>().gameObject;
        Player1 = FindObjectOfType<Player1>().gameObject;
        Player2 = FindObjectOfType<Player2>().gameObject;

        play = player1.notselected;
        string[] names = Input.GetJoystickNames();

        for (int x = 0; x < names.Length; x++) {
            // print(names[x].Length);

            if (!string.IsNullOrEmpty(names[x])) {
                Debug.Log("D");

                gameman.instance.controllercount++;
            } else {
                Debug.Log("L");
            }
            if (names[x].Length == 33) {
                iscontorller = true;
                // Debug.Log("Controller Mode");
            }

        }

    }

    // Update is called once per frame
    void Update() {
        //if (!contchosen && iscontorller)
        //{

        if (Input.GetButton("Cancel1") || Input.GetButton("Cancel2")) {
            StopAllCoroutines();
            play = player1.notselected;
    
            p1chk.SetActive(false);
            p2chk.SetActive(false);
            countdown = false;
            ctdwntext.text = "Player 1 Press A";

        }

        if (Input.GetButton("Submit1") && play == player1.notselected) {
            play = player1.Cont1;
            ctdwntext.text = "Player 2 Press A";

            p1chk.SetActive(true);
        } else if (Input.GetButton("Submit1") && play == player1.Cont2)  {
           

            p2chk.SetActive(true);
            countdown = true;

          
            StartCoroutine("Waittogoaway");


        }
        if (Input.GetButton("Submit2") && play == player1.notselected) {
            play = player1.Cont2;
            ctdwntext.text = "Player 2 Press A";

            p1chk.SetActive(true);

        } else if(Input.GetButton("Submit2") && play == player1.Cont1) {
            p2chk.SetActive(true);
            countdown = true;
           

            StartCoroutine("Waittogoaway");
          
               //  iscontorller = true;

            }
        //iscontorller = true;
        // }
        if (countdown) {

            
            

            ctdwntext.text = "Game will begin in : " + Mathf.RoundToInt(timer -= Time.deltaTime).ToString();


        } else {
          //  ctdwntext.text = "";
            timer = 5;
        }
         

    }
    IEnumerator Waittogoaway() {
        yield return new WaitForSeconds(4);
        Hold.SetActive(false);

        switch (play) {

            case player1.Cont1:
                GameObject P1A;
                P1A = Instantiate(player, Boat.transform);
                P1A.transform.position = Player1.transform.position;
                P1A.transform.SetParent(Player1.transform);



                P1A.GetComponent<Playergen>().direction = 0;
                P1A.GetComponent<Playergen>().playernum = 1;
                FindObjectOfType<DiolaugeManager>().p1I = 1;


                GameObject P2A;
                P2A = Instantiate(player, Boat.transform);
                P2A.transform.position = Player2.transform.position;
                P2A.transform.SetParent(Player2.transform);



                P2A.GetComponent<Playergen>().direction = 1;
                P2A.GetComponent<Playergen>().playernum = 2;
                FindObjectOfType<DiolaugeManager>().p2I = 2;


                //p1 = 2;
                //p2 = 1;

                contchosen = true;
                FindObjectOfType<movement>().PlayersSet = true;
                break;
            case player1.Cont2:
                GameObject P1;
                P1 = Instantiate(player, Boat.transform);

                P1.transform.position = Player1.transform.position;
                P1.transform.SetParent(Player1.transform);


                P1.GetComponent<Playergen>().direction = 0;
                P1.GetComponent<Playergen>().playernum = 2;
                FindObjectOfType<DiolaugeManager>().p1I = 2;

                GameObject P2;
                P2 = Instantiate(player, Boat.transform);
                P2.transform.position = Player2.transform.position;
                P2.transform.SetParent(Player2.transform);



                P2.GetComponent<Playergen>().direction = 1;
                P2.GetComponent<Playergen>().playernum = 1;
                FindObjectOfType<DiolaugeManager>().p2I = 1;


                //p1 = 1;
                //p2 = 2;
                contchosen = true;

                FindObjectOfType<movement>().PlayersSet = true;
                break;
            case player1.notselected:
                break;
            default:
                break;
        }
        Destroy(GetComponent<playerselect>());
    }
}
