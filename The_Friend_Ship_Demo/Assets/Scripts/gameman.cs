using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameman : MonoBehaviour {

    // Use this for initialization



    public Transform Player;


    public GameObject Hold;
    public Text Gameover;
    //  public List<GameObject> MissionPlates = new List<GameObject>();


    public int controllercount;


    startmission text;
    playerselect player;



    #region singelton
    public static gameman instance;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<playerselect>();
        Player = FindObjectOfType<movement>().GetComponent<Transform>();
        text = FindObjectOfType<startmission>();

    }
    #endregion
   
  
    
    // Update is called once per frame
    

  
  

}
