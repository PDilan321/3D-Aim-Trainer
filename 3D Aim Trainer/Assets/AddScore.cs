using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int Score;
    public Text TextScore;

    public float scoreAmount;

    public int ShotRegistered;
    public int TargetHit;
    public int AccurateTargetHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScoreForTrackingGame()
    {
        TextScore.text = ("Score: " + (int)(scoreAmount)); // Converting the float variable to an integer whilst also setting the score to that variable
        scoreAmount += Time.deltaTime; // Increasing every second the project is running for
        PlayerPrefs.SetInt("ScoreForTracking", (int)scoreAmount);


    }
    public void AddScoreForTileGame()
    {
        Score++;
        TextScore.text = ("Score: " + Score);
        TargetHit += 1;
        PlayerPrefs.SetInt("Score", Score); // Storing score using player prefs
    }

}
