using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Needed if the user is using a joystick to navigate through the game over menus

public class GameOver : MonoBehaviour
{
    public AddScore _AddScore;
    public TrackingGameScript _TrackingGameScript;

    public Text ShotsRegistered;
    public Text TargetHits;
    public Text AccurateTargetHits;
    public Text scoreProduced;
    public Text ShootingAccuracy;
    public Text TargetAccuracy;
    public float ShootingPercentage;
    public float TargetPercentage;

    public GameObject FirstButtonInGameOver;
    public bool FirstButtonDisplayed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Referencing the texts from the game over canvas and displaying the data from other scripts in the texts. 
    public void Setup (float ShotRegistered, float TargetHit, float AccurateTargetHit)
    {
        gameObject.SetActive(true);
        MakingFirstButton();
        Cursor.lockState = CursorLockMode.Confined;
        ShotsRegistered.text = "Shots Registered: " + ShotRegistered.ToString();
        TargetHits.text = "Targets Hit: " + TargetHit.ToString();
        scoreProduced.text = _AddScore.TextScore.text;
        AccurateTargetHits.text = "Accurate Target Hits: " + AccurateTargetHit.ToString();
        TargetPercentage = Mathf.Round(AccurateTargetHit / TargetHit * 100);
        ShootingPercentage = Mathf.Round(TargetHit / ShotRegistered * 100);
        ShootingAccuracy.text = "Shooting Accuracy: " + ShootingPercentage.ToString() + "%";
        TargetAccuracy.text = "Target Accuracy: " + TargetPercentage.ToString() + "%";
    }
    public void SetupForTracking()
    {
        gameObject.SetActive(true);
        MakingFirstButton();
        Cursor.lockState = CursorLockMode.Confined;
        ShotsRegistered.text = "Time Tracked: " + _AddScore.scoreAmount; // This is the same text as the one from Tile game but I changed the text to suit this game mode
        TargetHits.text = "Best Run: " + _TrackingGameScript.LongestTimeTracked + " seconds";
        AccurateTargetHits.text = "Speed of Sphere: " + _TrackingGameScript.SpeedOfBall;
        scoreProduced.text = _AddScore.TextScore.text;
    }

    public void MakingFirstButton()
    {
        FirstButtonDisplayed = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButtonInGameOver);
   
    }
}



