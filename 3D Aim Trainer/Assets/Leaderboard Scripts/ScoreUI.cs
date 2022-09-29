using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI RowUi; // Making a reference to the RowUI
    public ScoreManager _ScoreManager; // Making a reference to the ScoreManager
    void Start()
    {
        //_ScoreManager.AddScore(new ScoreClass("Dilan", 12));

        var scores = _ScoreManager.GettingHighScores().ToArray(); // Converting to array
        for (int i = 0; i < scores.Length; i++) // Iterating
        {
            var row = Instantiate(RowUi, transform).GetComponent<RowUI>(); // Instantiating 
            row.rank.text = (i + 1).ToString(); // Changing the rank text
            row.playername.text = scores[i].Name; // Changing the playername text
            row.score.text = scores[i].score.ToString(); // Changing the score text
        }
    }
}
