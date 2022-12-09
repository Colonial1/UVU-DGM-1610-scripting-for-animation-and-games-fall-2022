using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
   
    public bool hasFlag;
    
    public bool flagPlaced;
    
    public int scoreToWin;
    
    public int curScore;
   
    public bool gamePaused;

    public static GameManager instance;
   // void Awake()
    //{
       // instance = this;
   //}

    void Start()
    {
       hasFlag = false;

       flagPlaced = false; 
       
       Time.timeScale = 1.0f;
    }

    // Update is called once per frame
     void Update()
    {
        if(flagPlaced == true)
        {
            WinGame();
        }
        if(Input.GetButtonDown("Cancel"))
       {
            //TogglePauseGame();
       }
    }

   // public void TooglePauseGame()
   // {
        //gamePaused = !gamePaused;
       // Time.timeScale = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
  //  }

   // public void AddScore(int score)
    //{
       // curScore += score;

       // GameUI.instance.UpdateScoreText(curScore);
        
       // if(curScore >= scoreToWin)
            //WinGame();
   // }
    void WinGame()
     {
        
        Debug.Log("You've Won the Game!");
        Time.timeScale = 0;
       
        //GameUI.instance.SetEndGameScreen(true, curScore);

    }
    public void LoseGame()
    {
       // GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
         gamePaused = true;
        
    }
    public void PlaceFlag()
    {
        flagPlaced = true;
    }
}
