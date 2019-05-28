using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameman : MonoBehaviour {

    // Use this for initialization

    #region singelton
    public static gameman instance;

    private void Awake()
    {
        instance = this;
    }
#endregion


    public Transform Player;


    public GameObject Hold;
    public Text Gameover;
    //  public List<GameObject> MissionPlates = new List<GameObject>();


    public int controllercount;


    startmission text;
    playerselect player;
    void Start () {
        player = FindObjectOfType<playerselect>();
        Player = FindObjectOfType<movement>().GetComponent<Transform>();
        text = FindObjectOfType<startmission>();
      
    }
  
    
    // Update is called once per frame
    void Update () {


        if (Input.GetButton("Submit1") || (Input.GetButton("Submit2")) || Input.GetKey(KeyCode.Return))
        {
            Hold.SetActive(false);
        }
       


        if (text.ismissionfinish)
        {
            Hold.SetActive(true);
            Hold.GetComponentInChildren<Text>().text = "";

            Gameover.text = "Demo Done";
        }
     
        //else
        //{
        //    return;
        //}



        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

  
  

}
