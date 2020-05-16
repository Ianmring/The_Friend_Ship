using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "New Item", menuName = "Diolauge/Diolauge")]
public class Diolauge : ScriptableObject
{
    // Start is called before the first frame update
    public string thingtodo;
    public string situation;

    public string ThingToDoTxt;
    public enum Expression { happy, sad, talking, confused, angry, laughing, surprised, silly };
    [Space(10)]

    [Header("new")]
    public Line[] Lines;

    [Header("old")]
    [Space(10)]
    public Character[] Character_in_Conversation;
    public Character[] Radio_Characters;

    public Expression[] currentexpressions;

    public TextAsset txtsentences;

    public bool oneonone;
 //   public Sentence[] convo;
}
