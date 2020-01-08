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


    public Character[] Character_in_Conversation;
    public Expression[] currentexpressions;

    public TextAsset txtsentences;

    
 //   public Sentence[] convo;
}
