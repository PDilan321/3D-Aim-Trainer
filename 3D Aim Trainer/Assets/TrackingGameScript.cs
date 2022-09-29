using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingGameScript : MonoBehaviour
{

    public Color startColour;
    public Color MouseOverColour;
    public AddScore _AddScore;

    public bool AimingAtObject = false;

    public Vector3 RandomPoint;


    Vector3 ChangeDir;

    private Vector3 initialVelocity;
    private Vector3 lastframeVelocity;
    private Rigidbody rb;

    public int SpeedOfBall = 5;

    public float min = 0f;
    public float max = 0.5f;

    public TimerController _TimeController;

    public float CurrentTimeTracked;
    public float LongestTimeTracked = 0;

    public bool CheckingIfOnObject = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Moving", 0.5f);

        rb = GetComponent<Rigidbody>(); // Getting the Rigidbody component from the object
        rb.velocity = initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (AimingAtObject == true)
        {
            _AddScore.AddScoreForTrackingGame();
            if (CheckingIfOnObject == false)
            {
                StartCoroutine(TimeTake());
            }
            if (CurrentTimeTracked > LongestTimeTracked) // Checking if their current attempt has beaten their longesttime (set to 0).
            {
                LongestTimeTracked = CurrentTimeTracked; // Setting the new longest time tracked for each attempt
            }

        }
        if (_TimeController.secondsLeft > 0) // This if statement is ran until the games timer is not at 0
        {

            rb.AddForce((Moving()) * SpeedOfBall);
        }
        else
        {
            //Debug.Log("Nice the longest time was " + LongestTimeTracked);
        }

        //transform.position = transform.position + (RandomPoint * SpeedOfBall * Time.deltaTime);
        lastframeVelocity = rb.velocity;
    }
    public void OnMouseEnter()
    {
        //CurrentlyOnObject = true;
        GetComponent<Renderer>().material.SetColor("_Color", MouseOverColour); // Setting the colour of the sphere to red indicating that the user is hovering over the object
        AimingAtObject = true;
        
    }
    public void OnMouseExit()
    {
        AimingAtObject = false;
        //if (CurrentTimeTracked > LongestTimeTracked)
        //{
        //    LongestTimeTracked = CurrentTimeTracked;
        //    CurrentTimeTracked = 0;
        //}
        CurrentTimeTracked = 0;
        
        GetComponent<Renderer>().material.SetColor("_Color", startColour); // startColour is the normal colour of the sphere when the project is ran
        
    }

    public Vector3 Moving()
    {
        float NextTime = Random.Range(min, max);
        ChangeDir = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        return ChangeDir;
    }
    private void OnCollisionEnter(Collision coll) // Detecting if the sphere has hit/interacted with another object in the scene (e.g walls)
    {
        var speed = lastframeVelocity.magnitude; // Setting the speed to the latest velocity before this function was called. Magnitude was called becuase speed must be scalar
        var direction = Vector3.Reflect(lastframeVelocity.normalized, coll.contacts[0].normal); // This produces a direction that is perpendicular to its current direction
        rb.velocity = direction * Mathf.Max(speed, 0f); // Applying a velocity in that direction
    }
    IEnumerator TimeTake()
    {
        CheckingIfOnObject = true;
        yield return new WaitForSeconds(1f); // Wating 1 second everytime the function is called
        CurrentTimeTracked += 1; // Their current time tracked is incremented for every second they are pointing at the sphere
        //Debug.Log(CurrentTimeTracked);
        CheckingIfOnObject = false;
    }
}
