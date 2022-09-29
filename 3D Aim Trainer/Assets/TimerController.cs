using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text textDisplay; // Creating reference to the Timer Text
    public int secondsLeft = 60; // Creating a public variable that stores an integer
    public bool takingAway = false; // Boolean variable set to false
    public CountDown _CountDown;
    public GameOver _GameOver;
    public AddScore _AddScore;
    public ScoreManager scoreManager;
    public bool AddedScore = false;
    public bool TheGameIsFrozen = false;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = "Timer: " + secondsLeft; // secondsLeft can be changed in the Inspector
        // Can use a slider in the Options menu and set it to the 'secondsLeft' variable so the user can choose their preferred time
        // May have to include an additional coloumn for the leaderboard to say how long each game mode was

    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false & secondsLeft > 0)
        {
            if (_CountDown.CountDownDisplay.text == "GO!") 
            {
                StartCoroutine(TimeTake()); // Starting the coroutine as soon as the text says 'GO!'
            }
        }
        if ((secondsLeft == 0) && (AddedScore == false))
        {
            FinallyAddedScore(); // This is used so the AddScore fnction is only called once
            Time.timeScale = 0f;
            TheGameIsFrozen = true;
            if (SceneManager.GetActiveScene().name == "Tracking Game")
            {
                _GameOver.SetupForTracking();//, _AddScore.TargetHit, _AddScore.AccurateTargetHit);
                scoreManager.AddScore(new ScoreClass(PlayerPrefs.GetString("name"), PlayerPrefs.GetInt("ScoreForTracking"))); // Adding their name and score in the form of 
                // score class and then adding this type using the AddScore function.
            }
            else
            {
                _GameOver.Setup(_AddScore.ShotRegistered, _AddScore.TargetHit, _AddScore.AccurateTargetHit); // This is called if the current scene is the Tile game mode
                
            }
        }
    }

    IEnumerator TimeTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1f); // Wating 1 second everytime the function is called
        secondsLeft -= 1; // Decrementing the variable after the IEnumerator has paused for 1 secondd.
        textDisplay.text = "Timer: " + secondsLeft;
        takingAway = false;
    }
    public void FinallyAddedScore()
    {
        scoreManager.AddScore(new ScoreClass(PlayerPrefs.GetString("name"), PlayerPrefs.GetInt("Score")));
        AddedScore = true;
    }

}
