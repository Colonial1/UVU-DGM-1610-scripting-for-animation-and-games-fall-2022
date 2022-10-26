using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed; // How fast the enemy moves
    public float rayDistance;// How far the ray extends
    private bool isMovingRight = true;// Is the enemy moving right.
    public Transform groundDetection; // Is the enemy Touching the ground.
    
   
   
    // Update is called once per frame
    void Update()
  {
    
    // Move the enemy to the right
     transform.Translate(Vector2.right * speed * Time.deltaTime);
    // Raycasting - produces a ray from an orgin point in a certain direction with a set distance
     RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);
     
     if(groundInfo.collider == false)
     {
        if(isMovingRight == true)
        {
        // flip the Enemy at the edge to move left
        transform.eulerAngles = new Vector3(0, -100, 0);
        isMovingRight = false;
        }  
        else
        {
           // flip the Enemy at the edge to move right
           transform.eulerAngles = new Vector3(0, 0, 0);
           isMovingRight = true;
        }
      }
  }
}