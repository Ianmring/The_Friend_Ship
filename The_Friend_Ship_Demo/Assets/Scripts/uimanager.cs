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

    StandaloneInputModule input;
    EventSystem events;

    public bool isopen;

    public GameObject P1 { get; set; }
    public GameObject P2 { get; set; }


    public int currentselected = 0;
    public GameObject[] inventorymenus;
    public GameObject[] buttons;
    void Start()
    {
        playernums = Players.noone;
        int slotnums;

        input = GetComponent<StandaloneInputModule>();
        events = GetComponent<EventSystem>();
        slotnums = Canvase.transform.childCount;

        Menus = new GameObject[slotnums];
        // playersready = new bool[gameman.instance.controllercount];
        //    EventSystem.current.GetComponent<StandaloneInputModule>().horizontalAxis = "Player_1";

        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i] = Canvase.transform.GetChild(i).gameObject;
        }
        EventSystem.current.SetSelectedGameObject(buttons[currentselected]);
        Updateinvmenu();


    }

    private void Update()
    {

        if (playersready[0] && playersready[1])
        {
           // playernums = Players.noone;
             EventSystem.current.SetSelectedGameObject(null);
            Menus[2].SetActive(!Menus[2].activeSelf);
            Menus[3].SetActive(true);
            Menus[4].SetActive(true);
            isopen = false;
            Triggerupdate();
            playersready[0] = false;
            playersready[1] = false;
            //  EventSystem.current.SetSelectedGameObject(null);
        }





    }

    public void Triggerupdate() {
        switch (playernums)
        {
            case Players.player1:
                Menus[3].SetActive(true);
                Menus[4].SetActive(false);

                P1.GetComponent<inventorygeneral>().isyourturn = true;
                P2.GetComponent<inventorygeneral>().isyourturn = false;
                P1.GetComponent<inventorygeneral>().Handoff();
                P2.GetComponent<inventorygeneral>().Handoff();

                break;
            case Players.player2:
                Menus[3].SetActive(false);
                Menus[4].SetActive(true);

                P1.GetComponent<inventorygeneral>().isyourturn = false;
                P2.GetComponent<inventorygeneral>().isyourturn = true;
                P1.GetComponent<inventorygeneral>().Handoff();
                P2.GetComponent<inventorygeneral>().Handoff();
                break;

            default:
                break;
        }


    }
    public void Updateslotsgen()
    {
        P1.GetComponent<inventorygeneral>().Update_Slots();
        P2.GetComponent<inventorygeneral>().Update_Slots();
    }
    public void setslotint(int newslot)
    {
        for (int i = 0; i < inventorymenus.Length; i++)
        {
            if (inventorymenus[i].activeInHierarchy)
            {
                inventorymenus[i].SetActive(false);
            }
        }
        inventorymenus[newslot].SetActive(true);
    }

    public void UpdateMenuCont(int playnum)
    {

        input.horizontalAxis = "Horizontal_P" + playnum.ToString() + "_Launch";
        input.verticalAxis = "Vertical_P" + playnum.ToString() + "_Launch";
        input.submitButton = "Submit" + playnum.ToString();

    }

    public void Updateinvmenu()
    {

        if (currentselected < 0)
        {
            currentselected = 0;
        }
        else if (currentselected > inventorymenus.Length - 1)
        {
            currentselected = inventorymenus.Length - 1;
        }


        for (int i = 0; i < inventorymenus.Length; i++)
        {
            if (inventorymenus[i].activeInHierarchy)
            {
                inventorymenus[i].SetActive(false);
            }
        }
        inventorymenus[currentselected].SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttons[currentselected]);

        //  EventSystem.current.SetSelectedGameObject(buttons[currentselected].GetComponentInChildren<GameObject>());

    }
    IEnumerator DelayHighlight()
    {
        yield return new WaitForSeconds(0.001f);
        Debug.Log("did");
        if (EventSystem.current.currentSelectedGameObject == buttons[currentselected])
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(buttons[currentselected]);

        }
        else
        {
            EventSystem.current.SetSelectedGameObject(buttons[currentselected]);

        }


    }


}

   
