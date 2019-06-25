using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckList : MonoBehaviour
{
    PersonalItemSlot slot;

    Slider slide;

    launcher launch;

    LaunchArchRenderer launchrend;

    DiolaugeManager dio;

    movement mov;

    public Sprite image;

    Image ima;

    uiMap map;
  public  uiChecklist check;

  //  Misson_Manager MissMana;
    private void Start()
    {
       // MissMana = FindObjectOfType<Misson_Manager>();
        slot = GetComponent<PersonalItemSlot>();
        dio = DiolaugeManager.DioInstance;
        mov = movement.MovInstance;
        if (slot.Playernum == 0)
        {
            check = mov.Handels[0].GetComponentInChildren<uiChecklist>();
            check.gameObject.SetActive(true);

            map = mov.Handels[0].GetComponentInChildren<uiMap>();
            map.gameObject.SetActive(false);

            launch = uimanager.UIinstance.P1.GetComponent<launcher>();
            slide = GameObject.Find("P1Equip").GetComponentInChildren<Slider>();

        }
        if (slot.Playernum == 1)
        {
            check = mov.Handels[1].GetComponentInChildren<uiChecklist>();
            check.gameObject.SetActive(true);

            map = mov.Handels[1].GetComponentInChildren<uiMap>();
            map.gameObject.SetActive(false);

            launch = uimanager.UIinstance.P2.GetComponent<launcher>();
            slide = GameObject.Find("P2Equip").GetComponentInChildren<Slider>();

        }
        GetComponentInParent<KeyitemTrigger>().isactive = true;

    }
    public void Dothething()
    {
        //  launchrend.overide = true;

        slide.value = launch.IReady;

       // check.Co.text = MissMana.Beat[MissMana.currentbeat].Task;



    }
    public void DoDo()
    {
        //  launchrend.overide = true;
        //   ima.sprite = image;

        slide.value = launch.IReady;


     //   check.Co.text = MissMana.Beat[MissMana.currentbeat].Task;

    }
    private void Update()
    {
      //  check.Co.text = MissMana.Beat[MissMana.currentbeat].Task;

        if ( dio.indio)
        {


            slide.value = 0f;

        }
    }
    private void OnDestroy()
    {
        {
            check.gameObject.SetActive(true);

            map.gameObject.SetActive(true);

        }
    }
}
