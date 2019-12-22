﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]


public class uimanager : MonoBehaviour

{

    #region Singelton
    public static uimanager UIinstance;

    private void Awake()
    {
        UIinstance = this;
    }
    #endregion

    public GameObject Canvase;
    public GameObject[] Menus;
    public enum Players { player1, player2, noone }
    public Players playernums;

    public GameObject first;

    public bool[] playersready;

   public StandaloneInputModule Input { get; set; }
    EventSystem events;

    public bool isopen;
    public bool menuisopen;
    public bool storeisopen;


    public GameObject P1curss;
    public GameObject P2curss;

    public Canvas p1;
    public Canvas p2;

    public Playergen oneplayer;
    public Playergen twoplayer;

    public int currentselected = 0;

    DiolaugeManager manadio;
    //public GameObject[] buttons;

    //public GameObject[] Storebuttons;
    int countt;

    void Start()
    {
        playernums = Players.noone;
        int slotnums;

        Input = GetComponent<StandaloneInputModule>();
        events = GetComponent<EventSystem>();
        manadio = DiolaugeManager.DioInstance;
        slotnums = Canvase.transform.childCount;

        #region gettingmenus

        Menus = new GameObject[slotnums];
        // playersready = new bool[gameman.instance.controllercount];
        //    EventSystem.current.GetComponent<StandaloneInputModule>().horizontalAxis = "Player_1";

        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i] = Canvase.transform.GetChild(i).gameObject;
        }
        P1curss.SetActive(false);
        P2curss.SetActive(false);

        #endregion

    }


    private void Update()
    {
      
      

        if (isopen || DiolaugeManager.DioInstance.indio)
        {
            movement.MovInstance.altoveride = true;
        }
        else
        {
            movement.MovInstance.altoveride = false;

        }




    }

  
    public void toggleinvet() {

        if (manadio.indio) {
            playersready[0] = false;
            playersready[1] = false;
        }

        
    

        if ((playersready[0] || playersready[1])) {
            Menus[1].SetActive(true);

            isopen = true;
            menuisopen = true;
            storeisopen = false;

            //   
        } else {
            Menus[1].SetActive(false);
            InventoryMenu.invmeninstance.Resetitemselected();
            movement.MovInstance.p1I.AddKey(null, false);
            movement.MovInstance.p2I.AddKey(null, false);


            isopen = false;
            menuisopen = false;
            storeisopen = false;
           
        }

        if (playersready[0]) {
            oneplayer.isselectingitem = true;
            oneplayer.curssor.SetActive(true);
        } else {
            oneplayer.isselectingitem = false;
            oneplayer.curssor.SetActive(false);
        }

        if (playersready[1]) {
            twoplayer.isselectingitem = true;
            twoplayer.curssor.SetActive(true);
        } else {
            twoplayer.isselectingitem = false;
            twoplayer.curssor.SetActive(false);
        }
    }

    public void Shopupdate()
    {
        Menus[5].SetActive(true);
        isopen = true;
        menuisopen = false;
        storeisopen = true;
        playernums = uimanager.Players.player1;
        Menus[3].SetActive(false);
        Menus[4].SetActive(false);
       // Triggerupdate();
        UpdateMenuCont();
       // EventSystem.current.SetSelectedGameObject(Storebuttons[0]);

    }
   
   
   
   
    public void UpdateMenuCont()
    {

     
            Input.horizontalAxis = "Horizontal_M";
            Input.verticalAxis = "Vertical_M";
       

       // }


    }

  


}

   
