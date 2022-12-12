using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour

{
    private ScoreManager scoreManager;
    public int scoreToGive;
    public ParticleSystem explosionParticle;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
   
    void OnTriggerEnter(Collider other)
    {
        Explosion();
        scoreManager.IncreaseScore(scoreToGive); // Increase Score 
        Destroy(other.gameObject); //Destroy the other game object it hits
        Destroy(gameObject); // Destroy this game object
        
    }
    void Explosion()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
    }
    
}
