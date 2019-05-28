using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "New Item", menuName = "Diolauge/Diolauge")]
public class Diolauge : ScriptableObject
{
    // Start is called before the first frame update

    //public string convoname;
    public enum Expression { happy, sad, talking, confused, angry, laughing, surprised, silly };



    public string name;

    [TextArea(3, 4)]
    public string[] Sentences;
    public Character[] Character_in_Conversation;
    public Expression[] currentexpressions;


 //   public Sentence[] convo;
}
