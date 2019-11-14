
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public enum type { Disposeable, Oare, Hat , Keyitem};
    public type Type;
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isdefault = false;
    public GameObject OBJ = null;
    public GameObject UIOBJ = null;
    public string discription = null;
    
 


    public virtual void Use()
    {
      
       
       
      //  Debug.Log("using" + name);
    }

    public void ItemDo()
    {

    }
   
}
