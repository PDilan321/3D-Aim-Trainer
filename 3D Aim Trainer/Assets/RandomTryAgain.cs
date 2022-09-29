using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class RandomTryAgain : MonoBehaviour
{
    public TimerController _TimeController;
    public AddScore _AddScore;
    
    public int MovementSpeed;
    float time = 2.0f;
    public float TimeSinceLastChange;

    Vector3 dir = new Vector3(1, 1, 1);
    Vector3 ChangeDir;
    public float min, max;
    private Rigidbody rb;
    private Vector3 initialVelocity;
    private Vector3 lastframeVelocity;
    public Color startColour;
    public Color MouseOverColour;
    public Vector3 randomPosition;

    public bool DidFunction = false;


    void Start()
    {
        TimeSinceLastChange = 0;
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;

    }
    void Update()
    {
        if((_TimeController.secondsLeft > 0) && (_TimeController.secondsLeft != 60))
        {
            //transform.position = transform.position + (dir * MovementSpeed * Time.deltaTime);
            rb.AddForce(Moving() * MovementSpeed);
            lastframeVelocity = rb.velocity;

        }
        if (DidFunction == true)
        {
            _AddScore.AddScoreForTrackingGame();
        }
            
    }
    public Vector3 Moving()
    {
        float NextTime = Random.Range(min, max);
        ChangeDir = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 0));
        return ChangeDir;
    }


    private void OnCollisionEnter(Collision coll)
    {
        var speed = lastframeVelocity.magnitude;
        var direction = Vector3.Reflect(lastframeVelocity.normalized, coll.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
    public void OnMouseEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", MouseOverColour); // Setting the colour of the sphere to red indicating that the user is hovering over the object  
        DidFunction = true;
        
    }
    public void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColour); // startColour is the normal colour of the sphere when the project is ran
        DidFunction = false;
    }


}
