using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sData; //Calling the Scoredata() which creates a new list
    public GameObject Content; // Creating a reference to a gameobject
    private void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}"); // Getting existing data
        sData = JsonUtility.FromJson<ScoreData>(json); // Setting existing data
        Debug.Log(json);
    }

    public IEnumerable<ScoreClass> GettingHighScores() // Creating IEnumerable
    {
        return sData.scores.OrderByDescending(x => x.score); // Returning the list
    }
    public void AddScore(ScoreClass score) // Creating function that adds score
    {
        sData.scores.Add(score); // Adds the score that is passed through as a parameter to 'sData'
    }

    private void OnDestroy() // This is called when a scene or game has stopped running/ended
    {
        SaveScore(); // Calling the 'SaveScore' function
    }
    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sData); // Creating variable called json
        PlayerPrefs.SetString("scores", json); // Setting contents of the variable json in a playerpref  
    }
    public void ResetLeaderboard() // On Click function
    {
        sData.scores.Clear(); // Clearing the list
        Content.SetActive(false); // Seting this object to false so it seems that the leaderboard has been erased in the game over canvas
        
    }
}
