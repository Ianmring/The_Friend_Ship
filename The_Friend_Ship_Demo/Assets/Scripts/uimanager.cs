﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[System.Serializable]


public class uimanager : MonoBehaviour {

    #region Singelton
    public static uimanager UIinstance;

    private void Awake() {
        UIinstance = this;
    }
    #endregion

    public GameObject Canvase;
    public GameObject[] Menus;

  ///  public GameObject inforindicator;

    public Button first;

    public bool[] playersready;

    bool[] storedplayerready;

    public StandaloneInputModule Inputt { get; set; }
  public  EventSystem events;

    public bool isopen;
    public bool menuisopen;


    public GameObject P1curss;
    public GameObject P2curss;

    public Canvas p1;
    public Canvas p2;

    public Canvas Indoors;

    public Color P1C;
    public Color P2C;

   // public Selector[] OBJSelector;

    public Playergen oneplayer;
    public Playergen twoplayer;

    public int currentselected = 0;

    DiolaugeManager manadio;

    public string controllerL;
    //public GameObject[] buttons;

    //public GameObject[] Storebuttons;
    int countt;

    public bool itemcan;

    public bool ispaused;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        int slotnums;
//        itemcan = true;
        Inputt = GetComponent<StandaloneInputModule>();
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

        storedplayerready = new bool[2];
        #endregion

    }

    private void Update() {
        if (Input.anyKeyDown) {
            Inputt.verticalAxis = "Vertical_LaunchK";
            Inputt.horizontalAxis = "Horizontal_LaunchK";
           
        } else 
            
            {
            Inputt.verticalAxis = controllerL + "Vertical_Launch";
            Inputt.horizontalAxis = controllerL + "Horizontal_Launch";
           
            //  Debug.Log("pad");
        }
        Inputt.submitButton = controllerL + "Submit";
        Inputt.cancelButton = controllerL + "Cancel";

    }


    public void toggleinvet() {

        //if (manadio.indio) {
        //    playersready[0] = false;
        //    playersready[1] = false;
        //}
       

        Tutorial_Manager.tootinstance.Tutorialoff();


        if (((playersready[0] || playersready[1]) && !manadio.indio && itemcan)) {
            Menus[0].SetActive(true);
            Menus[Menus.Length-1].SetActive(false);
            isopen = true;
            menuisopen = true;

          

            //   
        } else {
            Menus[0].SetActive(false);
            Menus[Menus.Length-1].SetActive(true);

            //OBJSelector[0].trans.position = OBJSelector[0].Center;
            //OBJSelector[1].trans.position = OBJSelector[1].Center;
            InventoryMenu.invmeninstance.Resetitemselected();

            //movement.MovInstance.p1I.AddKey(null,  false);
            //movement.MovInstance.p2I.AddKey(null,  false);


            isopen = false;
            menuisopen = false;
           
        }

        if (playersready[0]) {
            oneplayer.isselectingitem = true;
          
            oneplayer.curssor.SetActive(true);


        } else {
            oneplayer.isselectingitem = false;
          //  InventoryMenu.invmeninstance.StoptAnim(0);

            oneplayer.curssor.SetActive(false);
        

        }

        if (playersready[1]) {
            twoplayer.isselectingitem = true;
         
            twoplayer.curssor.SetActive(true);


        } else {
            twoplayer.isselectingitem = false;
           // InventoryMenu.invmeninstance.StoptAnim(1);

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
        StartCoroutine("PauseDelay");
    }
    public void Quit() {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdLyuUsZ2048V3_0vaNTDehzHPDaZwsDYVZJEqJkqpvBzCm3Q/viewform?usp=sf_link");
        Application.Quit();
    }
   public void Test() {
        Debug.Log("test");
    }

    IEnumerator PauseDelay() {
        yield return new WaitForSeconds(0.1f);
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
        Tutorial_Manager info;
        info = Tutorial_Manager.tootinstance;

        if (info.infoon && info.Info.activeSelf) {
            info.Info.SetActive(false);

        } else if(info.infoon && !info.Info.activeSelf) {
            info.Info.SetActive(true);

        }


        
        
        //for (int i = 8; i < 14; i++) {
        //    Menus[i].SetActive(!Menus[i].activeSelf);
        //}


        isopen = !isopen;
        movement.MovInstance.move = !movement.MovInstance.move;
        events.SetSelectedGameObject(first.gameObject);
        ispaused = !ispaused;
    }


}






   
