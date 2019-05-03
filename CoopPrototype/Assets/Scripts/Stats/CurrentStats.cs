
using UnityEngine;

public class CurrentStats : MonoBehaviour
{
    public int maxhealth;

    public int basehealth { get; set; }
    public float basespeed { get; set; }

   




    public int currenthealth { get; private set; }

    public Stat Damage;
    public Stat Speed;
    public Stat Health;
 



    private void Awake()
    {
        currenthealth = maxhealth;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    TakeDamage(1);
        //}
    }
    public void TakeDamage(int damage)
    {
       
      
            currenthealth -= damage;

       
        

        if (currenthealth <= 0)
        {
            Die();
        }
        
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " Died");
    }
}
