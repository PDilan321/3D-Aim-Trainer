using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RandomMovement : MonoBehaviour
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

    public bool DidFunction = false;
    public float NextTime;

    void Start()
    {
        TimeSinceLastChange = 0;
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
        NextTime = Random.Range(min, max);
        while (true)
        {
            InvokeRepeating("PleaseMove", 2, 5);
        }
    }
    void Update()
    {
        //transform.position = transform.position + (dir * MovementSpeed * Time.deltaTime);




    }
    
    public void PleaseMove()
    {
        rb.velocity = Moving() * MovementSpeed;
        lastframeVelocity = rb.velocity;
    }

    
    public Vector3 Moving()
    {
        
        ChangeDir = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
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
        GetComponent<Renderer>().material.SetColor("_Color", MouseOverColour);
        DidFunction = true;

    }
    public void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColour);
        DidFunction = false;

    }

}
