using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is no longer needed
public class MoveRandomly : MonoBehaviour
{
    public int MovementSpeed = 7;

    Vector3 dir = new Vector3(1, 1, 1);
    Vector3 ChangeDir;
    public float min = 0f;
    public float max = 0.5f;

    private Vector3 initialVelocity;
    private Vector3 lastframeVelocity;
    private Rigidbody rb;

    void Start()
    {
        Invoke("Moving", 0.5f);

        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }
    void Update()
    {
        //transform.position = transform.position + (ChangeDir * MovementSpeed * Time.deltaTime);
        lastframeVelocity = rb.velocity;

        rb.AddForce((Moving()) * MovementSpeed);

    }

    public Vector3 Moving()
    {
        float NextTime = Random.Range(min, max);
        //Invoke("Moving", NextTime);
        ChangeDir = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        return ChangeDir;
    }
    private void OnCollisionEnter(Collision coll)
    {
        var speed = lastframeVelocity.magnitude;
        var direction = Vector3.Reflect(lastframeVelocity.normalized, coll.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
