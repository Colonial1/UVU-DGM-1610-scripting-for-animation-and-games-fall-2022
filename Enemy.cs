using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour{
    // Enemy stats
    public int curHp, maxHp, scoreToGive;
    // Movement
    public float moveSpeed, attackRange, yPathOffset;
    // Coodinates for a path
    private List<Vector3> path;
    // Enemy Weapon
   // private Weapon weapon;
    // Target to follow
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Get the components
        //weapon = GetComponent<Weapon>();
        player = FindObjectOfType<PlayerController>().gameObject; GameObject.Find("Player");
        
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
     
        curHp = maxHp;
    }

    void UpdatePath()
    {
        //Calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
        Debug.Log(path.Count);
    }

    void ChasePlayer()
    {
        if (path.Count == 0)
            return;
        Debug.Log("Path Found");
        // Move towards closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0,yPathOffset, 0), moveSpeed * Time.deltaTime);

        if (transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if (curHp <= 0)
            Die();
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.collider.gameObject == player)
        {
            player.GetComponent<PlayerController>().TakeDamage(1);
        }
    }

    void Die()
    {
        //GameManager.instance.AddScore(scoreToGive);
        Destroy(gameObject);
    }
 
    // Update is called once per frame
    void Update()
    {
        //Look at the Target
        Vector3 dir = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;

        // Calculate the distance between this enemy and the player
        float dist = Vector3.Distance(transform.position, player.transform.position);
        // If within attack range, shoot player
        if(dist <= attackRange)
        {
            /*if (weapon.CanShoot())
                weapon.Shoot();*/
        }
        //If enemy is too far away, move towards player
        else
        {
            ChasePlayer();
           
        }
    }
}
