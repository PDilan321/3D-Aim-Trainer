using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly2 : MonoBehaviour
{
    public float xMinRange = -40.0f;
    public float xMaxRange = 40.0f;
    public float yMinRange = 6.0f;
    public float yMaxRange = 55.0f;
    public float zMinRange = -8.8f;
    public float zMaxRange = 40.0f;
    Vector3 RandomPosition;

    void Update()
    {
        
        // get a random position between the specified ranges
        RandomPosition.x = Random.Range(xMinRange, xMaxRange);
        RandomPosition.y = Random.Range(yMinRange, yMaxRange);
        RandomPosition.z = Random.Range(zMinRange, zMaxRange);

        transform.position = Vector3.MoveTowards(transform.position, RandomPosition, 50f * Time.deltaTime);
    
    }







    



}
