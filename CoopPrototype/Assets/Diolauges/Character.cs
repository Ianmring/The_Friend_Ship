using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Item", menuName = "Diolauge/Characters")]

public class Character : ScriptableObject
{


    public string Name;
    public Sprite[] expressions;

  
}
