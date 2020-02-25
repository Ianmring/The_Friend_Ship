
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public enum type { Disposeable, Oare, Hat , Keyitem};
    public type Type;
    new public string name = "New Item";
    public Vector2 layer;
    public Sprite icon = null;
    public bool isdefault = false;
    public GameObject OBJ = null;
    public GameObject UIOBJ = null;
    public string discription = null;
    public Vector2 spritedimension;
    public Vector2 spritelocation;
    public bool keeplayer;

    public virtual void Use()
    {
      
       
       
      //  Debug.Log("using" + name);
    }

    public void ItemDo()
    {

    }
   
}
