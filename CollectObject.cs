using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{

    private ScoreManager scoreManager; // A variable to hold the reference to the scoremanager
    public int scoreToGive;
   

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Coins Collected UI").GetComponent<ScoreManager>(); // Referance scoremanager
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "PlayerCollider")
        {
            Destroy(gameObject);
            scoreManager.IncreaseScore(scoreToGive);
        }
    }
}
