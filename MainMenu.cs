using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour

{
    
    public int sceneToLoad;

    
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad); //Indexed Scene to load
        Debug.Log("New Scene Loaded"); 
    }

   
    public void QuitGame()
    {
      Application.Quit(); // Quit Game
       Debug.Log("You have quit the game, goodbye.");
    }

}
