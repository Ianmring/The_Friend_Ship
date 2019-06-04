
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public Vector3 inteactionpoint;

    public SphereCollider thiscol;

    public enum InteactionType { obj, NPC, QuestMark };

    public InteactionType Type;



    public void Start()
    {


        thiscol = this.GetComponent<SphereCollider>();
        thiscol.radius = radius;
        thiscol.center = inteactionpoint;


    }
    public virtual void Interact()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<movement>())
        {
            Interact();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }

}
