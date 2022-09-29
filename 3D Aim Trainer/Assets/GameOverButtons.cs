using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f; // Setting the time scale back to original (1)
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Getting the current scene open and loading that, this function is called once the restart button is pressed
        Time.timeScale = 1f; 
    }

}
