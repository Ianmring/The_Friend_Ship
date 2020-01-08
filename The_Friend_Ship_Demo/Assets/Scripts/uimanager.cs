﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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
   

    public Button first;

    public bool[] playersready;

   public StandaloneInputModule Input { get; set; }
    EventSystem events;

    public bool isopen;
    public bool menuisopen;


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


   
  
    public void toggleinvet() {

        if (manadio.indio) {
            playersready[0] = false;
            playersready[1] = false;
        }

        
    

        if ((playersready[0] || playersready[1])) {
            Menus[0].SetActive(true);

            isopen = true;
            menuisopen = true;

            //   
        } else {
            Menus[0].SetActive(false);
            InventoryMenu.invmeninstance.Resetitemselected();
            movement.MovInstance.p1I.AddKey(null, false);
            movement.MovInstance.p2I.AddKey(null, false);


            isopen = false;
            menuisopen = false;
           
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

        if (isopen || DiolaugeManager.DioInstance.indio) {
            movement.MovInstance.altoveride = true;
        } else {
            movement.MovInstance.altoveride = false;

        }
    }
   
    public void PauseMenu()
    {
        events.SetSelectedGameObject(null);

        Debug.Log("pause");
        if (menuisopen) {
            Menus[0].SetActive(!Menus[0].activeSelf);
            oneplayer.isselectingitem = !oneplayer.isselectingitem;
            oneplayer.curssor.SetActive(!oneplayer.curssor.activeSelf);
            twoplayer.isselectingitem = !twoplayer.isselectingitem;
            twoplayer.curssor.SetActive(!twoplayer.curssor.activeSelf);
        }
      
        for (int i = 1; i < 7; i++) {
            Menus[i].SetActive(!Menus[i].activeSelf);
        }

        
        
        isopen = !isopen;
        movement.MovInstance.move = !movement.MovInstance.move;
        events.SetSelectedGameObject(first.gameObject);
    }
    public void Quit() {
        Application.Quit();
    }
   public void Test() {
        Debug.Log("test");
    }




}






   
