using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    public GameObject toot;

    public camscript cameraref;

    public Image p1chk;
    public Image p2chk;

    public enum player1 { Cont1, Cont2, notselected }

    player1 play;

    bool countdown;

    float timer;

    public TextMeshProUGUI ctdwntext;

    public Diolauge dio;

    public bool menuoff;

    public Item[] Itemstoadd;

    public Item Trilmix;
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

                // gameman.instance.controllercount++;
            } else {
                Debug.Log("L");
            }
            if (names[x].Length == 33) {
                iscontorller = true;
                // Debug.Log("Controller Mode");
            }

        }

        for (int i = 1; i < 6; i++) {
            uimanager.UIinstance.Menus[i].SetActive(false);
        }

        p1chk.color = Color.yellow;
        p2chk.color = Color.yellow;
    }
    public void canselect() {
        StartCoroutine("Waittoselect");

        uimanager.UIinstance.Menus[7].SetActive(true);
        uimanager.UIinstance.Menus[9].SetActive(false);


    }
    // Update is called once per frame
    void Update() {
        //if (!contchosen && iscontorller)
        //{
        if (menuoff) {


            if (Input.GetButtonDown("Cancel1") || Input.GetButtonDown("Cancel2")) {
                StopAllCoroutines();
                play = player1.notselected;

                p1chk.color = Color.yellow;
                p2chk.color = Color.yellow;
                countdown = false;
                ctdwntext.text = "Player 1 Press A";

            }

            if (Input.GetButtonDown("Submit1") && play == player1.notselected) {
                play = player1.Cont1;
                ctdwntext.text = "Player 2 Press A";

                p1chk.color = Color.green;
            } else if (Input.GetButtonDown("Submit1") && play == player1.Cont2) {


                p2chk.color = Color.green;
                countdown = true;


                StartCoroutine("Waittogoaway");


            }
            if (Input.GetButtonDown("Submit2") && play == player1.notselected) {
                play = player1.Cont2;
                ctdwntext.text = "Player 2 Press A";

                p1chk.color = Color.green;

            } else if (Input.GetButtonDown("Submit2") && play == player1.Cont1) {
                p2chk.color = Color.green;
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

    }
    IEnumerator Waittoselect() {
        yield return new WaitForSeconds(.1f);
        menuoff = true;

    }
    IEnumerator Waittogoaway() {
        yield return new WaitForSeconds(4);
        Hold.SetActive(false);
        for (int i = 1; i < 6; i++) {
            uimanager.UIinstance.Menus[i].SetActive(true);
        }
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
        cameraref.Normal();
        uimanager.UIinstance.p1.gameObject.SetActive(true);
        uimanager.UIinstance.p2.gameObject.SetActive(true);
        for (int i = 0; i < Itemstoadd.Length; i++) {
            Inventory.instance.AddKey(Itemstoadd[i], 1);
        }

        Inventory.instance.AddKey(Trilmix, 1);
        Inventory.instance.AddKey(Trilmix, 1);

        FindObjectOfType<DiolaugeManager>().Startdio(dio, toot, false);
        Destroy(GetComponent<playerselect>());
    }
}
