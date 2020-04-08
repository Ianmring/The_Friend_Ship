using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
public class hoversound : MonoBehaviour , ISelectHandler
{

  

   
    public void OnSelect(BaseEventData eventData) {
        Audiomana.Audioinstance.Play("ShakeSing");
    }

}
