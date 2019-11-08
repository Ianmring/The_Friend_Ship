using System.Collections;
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

    public GameObject P1 { get; set; }
    public GameObject P2 { get; set; }


    public int currentselected = 0;
    //public GameObject[] buttons;

    //public GameObject[] Storebuttons;
    int countt;

    void Start()
    {
        playernums = Players.noone;
        int slotnums;

        Input = GetComponent<StandaloneInputModule>();
        events = GetComponent<EventSystem>();
        slotnums = Canvase.transform.childCount;

        #region gettingmenus

        Menus = new GameObject[slotnums];
        // playersready = new bool[gameman.instance.controllercount];
        //    EventSystem.current.GetComponent<StandaloneInputModule>().horizontalAxis = "Player_1";

        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i] = Canvase.transform.GetChild(i).gameObject;
        }

     
        Updateinvmenu();
        #endregion

    }

    private void Update()
    {
      
        if (playersready[0] || playersready[1])
        {                  
            Menus[2].SetActive(true);        
                       
            isopen = true;
            menuisopen = true;
            storeisopen = false;
         
       //   
        } else {
            Menus[2].SetActive(false);

            isopen = false;
            menuisopen = false;
            storeisopen = false;
        }

        if (isopen || DiolaugeManager.DioInstance.indio)
        {
            movement.MovInstance.altoveride = true;
        }
        else
        {
            movement.MovInstance.altoveride = false;

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
        Updateinvmenu();
       // EventSystem.current.SetSelectedGameObject(Storebuttons[0]);

    }
   
    //public void Triggerupdate()
    //{
    //    switch (playernums)
    //    {
    //        case Players.player1:
    //            Menus[3].SetActive(true);
    //            Menus[4].SetActive(false);

    //            P1.GetComponent<inventorygeneral>().isyourturn = true;
    //            P2.GetComponent<inventorygeneral>().isyourturn = false;
    //            P1.GetComponent<inventorygeneral>().Handoff();
    //            P2.GetComponent<inventorygeneral>().Handoff();

    //            break;
    //        case Players.player2:
    //            Menus[3].SetActive(false);
    //            Menus[4].SetActive(true);

    //            P1.GetComponent<inventorygeneral>().isyourturn = false;
    //            P2.GetComponent<inventorygeneral>().isyourturn = true;
    //            P1.GetComponent<inventorygeneral>().Handoff();
    //            P2.GetComponent<inventorygeneral>().Handoff();
    //            break;


    //    }


    //}
   
   
    public void UpdateMenuCont()
    {

        //if (menuisopen && !storeisopen)
        //{
           
        //    input.horizontalAxis = "Horizontal_P"+ playnum+"_M";
        //    input.verticalAxis = "Vertical_P"+playnum+"_M";
        //        input.submitButton = "Submit" + playnum;
            
   
            
        //}
        //else if (storeisopen && !menuisopen)
        //{
            Input.horizontalAxis = "Horizontal_M";
            Input.verticalAxis = "Vertical_M";
       

       // }


    }

    public void Updateinvmenu()
    {
        

    }
    //IEnumerator DelayHighlight()
    //{
    //    yield return new WaitForSeconds(0.001f);

    //    if (EventSystem.current.currentSelectedGameObject == buttons[currentselected])
    //    {
    //        EventSystem.current.SetSelectedGameObject(null);
    //        EventSystem.current.SetSelectedGameObject(buttons[currentselected]);

    //    }
    //    else
    //    {
    //        EventSystem.current.SetSelectedGameObject(buttons[currentselected]);

    //    }


    //}


}

   
