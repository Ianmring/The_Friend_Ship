using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerselect : MonoBehaviour
{
    // Start is called before the first frame update
    public bool iscontorller;
    public bool contchosen;
    public int p1;
    public int p2;
    public int controllercount;
    public GameObject player;
   GameObject Boat;


     GameObject Player1;
     GameObject Player2;

    //public int playernumbers;
    void Start()
    {

        Boat = FindObjectOfType<movement>().gameObject;
        Player1 = FindObjectOfType<Player1>().gameObject;
        Player2 = FindObjectOfType<Player2>().gameObject;


        string[] names = Input.GetJoystickNames();

        for (int x = 0; x < names.Length; x++)
        {
            // print(names[x].Length);
            gameman.instance.controllercount++;
            if (names[x].Length == 33)
            {
                iscontorller = true;
                // Debug.Log("Controller Mode");
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (!contchosen && iscontorller)
        //{
            if (Input.GetButton("Submit1"))
            {
                Debug.Log("onego");

               // playernumbers++;
                GameObject P1;
              P1= Instantiate(player, Boat.transform);
              
                P1.transform.position = Player1.transform.position;
                P1.transform.SetParent(Player1.transform);
       

            P1.GetComponent<Playergen>().direction = 0;
                P1.GetComponent<Playergen>().playernum = 1;

                GameObject P2;
                P2 = Instantiate(player, Boat.transform);
                P2.transform.position = Player2.transform.position;
                P2.transform.SetParent(Player2.transform);

           

            P2.GetComponent<Playergen>().direction = 1;
                P2.GetComponent<Playergen>().playernum = 2;


                //p1 = 1;
                //p2 = 2;
                contchosen = true;
        
             Destroy(GetComponent<playerselect>());

            }
            else if (Input.GetButton("Submit2"))
            {
                Debug.Log("twogo");

                GameObject P1A;
                P1A = Instantiate(player, Boat.transform);
                P1A.transform.position = Player1.transform.position;
                P1A.transform.SetParent(Player1.transform);

          

            P1A.GetComponent<Playergen>().direction = 0;
                P1A.GetComponent<Playergen>().playernum = 2;


                GameObject P2A;
                P2A = Instantiate(player, Boat.transform);
                P2A.transform.position = Player2.transform.position;
                P2A.transform.SetParent(Player2.transform);

          

            P2A.GetComponent<Playergen>().direction = 1;
                P2A.GetComponent<Playergen>().playernum = 1;


                //p1 = 2;
                //p2 = 1;

                contchosen = true;

                Destroy(GetComponent<playerselect>());
               //  iscontorller = true;

            }
          //iscontorller = true;
       // }

         

    }
}
