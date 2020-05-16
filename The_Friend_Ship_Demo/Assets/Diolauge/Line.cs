
using UnityEngine;

[System.Serializable]
public class Line 
{
    public Character character;
    public enum Expression { happy, sad, talking, confused, angry, laughing, surprised, silly };

    public Expression currentexpressions;

    [TextArea]
    public string line;
}
