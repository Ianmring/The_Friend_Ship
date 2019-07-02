using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Playergen : MonoBehaviour
{

    playerselect playa;
    movement Mov;

    // public int PLAYER;

    public int direction;
    public int playernum;

    public Material[] Mats;

    public Renderer playerrend;

    int newplayernum;

    public bool isdemo;

   public uimanager UIMana;

    inventorygeneral invent;
    // Start is called before the first frame update
    void Start()
    {

        invent = GetComponent<inventorygeneral>();
        UIMana = FindObjectOfType<uimanager>();
        playa = FindObjectOfType<playerselect>();
        Mov = GetComponentInParent<movement>();
        // playerrend = GetComponent<Renderer>();
        switch (direction)
        {
            case 0:
                playerrend.material = Mats[direction];
                UIMana.P1 = this.gameObject;
                break;

            case 1:
                playerrend.material = Mats[direction];
                UIMana.P2 = this.gameObject;
                break;


            default:
                break;
        }

    }

    
    // Update is called once per frame
    void Update()
    {

      
            Mov.directions[direction] = Input.GetAxis("Vertical_P" + playernum.ToString());

        



        if (Input.GetButton("Exit" + playernum.ToString()))
        {
            Debug.Log("Quit");
            Application.Quit();


        }

        #region UIControl

        if (!isdemo)
        {
            if (!UIMana.isopen)
            {
                if (Input.GetButtonUp("Restart" + playernum.ToString()))
                {

                    switch (direction)
                    {
                        case 0:
                            
                            UIMana.playernums = uimanager.Players.player1;
                            UIMana.isopen = true;
                            UIMana.menuisopen = true;
                            UIMana.storeisopen = false;
                            UIMana.Triggerupdate();
                        //    EventSystem.current.SetSelectedGameObject(UIMana.buttons[UIMana.currentselected]);
                            
                            break;
                        case 1:
                            UIMana.playernums = uimanager.Players.player2;
                            UIMana.isopen = true;
                            UIMana.menuisopen = true;
                            UIMana.storeisopen = false;
                            UIMana.Triggerupdate();


                            break;

                        default:
                            break;
                    }

                    UIMana.Menus[2].SetActive(!UIMana.Menus[2].activeSelf);

                 
                    UIMana.UpdateMenuCont(playernum);
                    //UIMana.Updateinvmenu();
                    UIMana.StartCoroutine("DelayHighlight");

                    //  UIMana.currentselected = 0;

                }
                switch (direction)
                {
                    case 0:
                        if (Input.GetButtonUp("MenuUP" + playernum.ToString()))
                        {
                            invent.currentitem++;
                            invent.Update_Slots();

                        }
                        if (Input.GetButtonUp("MenuDOWN" + playernum.ToString()))
                        {
                            invent.currentitem--;
                            invent.Update_Slots();
                        }
                        break;
                    case 1:
                        if (Input.GetButtonUp("MenuUP" + playernum.ToString()))
                        {
                            invent.currentitem--;
                            invent.Update_Slots();

                        }
                        if (Input.GetButtonUp("MenuDOWN" + playernum.ToString()))
                        {
                            invent.currentitem++;
                            invent.Update_Slots();
                        }
                        break;
                   
                }
              

            }
            else
            {
                if (Input.GetButtonUp("Handoff" + playernum.ToString()))
                {
                    switch (direction)
                    {
                        case 0:
                            UIMana.playernums = uimanager.Players.player2;
                            UIMana.Triggerupdate();


                            break;
                        case 1:
                            UIMana.playernums = uimanager.Players.player1;
                            UIMana.Triggerupdate();

                            break;

                        default:
                            break;
                    }


                    switch (playernum)
                    {
                        case 1:
                            newplayernum = 2;
                            break;
                        case 2:
                            newplayernum = 1;
                            break;


                        default:
                            break;
                    }

                    UIMana.UpdateMenuCont(newplayernum);

                   
                }
                if ((Input.GetButtonUp("MenuUP" + playernum.ToString()) && direction == (int)UIMana.playernums) || (Input.GetButtonUp("MenuUP" + playernum.ToString()) && UIMana.storeisopen))
                {
                    UIMana.currentselected++;
                    UIMana.Updateinvmenu();

                }
                if (Input.GetButtonUp("MenuDOWN" + playernum.ToString()) && direction == (int)UIMana.playernums || (Input.GetButtonUp("MenuDOWN" + playernum.ToString()) && UIMana.storeisopen))
                {
                    UIMana.currentselected--;
                    UIMana.Updateinvmenu();
                }


                if (Input.GetButtonUp("Restart" + playernum.ToString()))
                {
                    UIMana.playersready[direction] = !UIMana.playersready[direction];
                }



            }
            #endregion
       
        }
        
    
      
    }
}
