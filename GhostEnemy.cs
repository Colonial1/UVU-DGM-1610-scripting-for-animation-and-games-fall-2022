using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
       TakeDamage(20); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            Death();
        }
        void Death()
        {
            Destroy(gameObject);
        }
    }
}
