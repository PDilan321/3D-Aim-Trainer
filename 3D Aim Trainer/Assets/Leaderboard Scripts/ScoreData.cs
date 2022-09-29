using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ScoreData
{
    public List<ScoreClass> scores; // Declaring a list
    public ScoreData()
    {
        scores = new List<ScoreClass>(); // We add/create a new list using the ScoreClass as the type of elements to be stored
    }
}

// When declaring the list, there is a requirement for a type of objects that you will be storing in the List. The <> is used to determine what data type should be stored in
// In this case, I reference the ScoreClass so the list will store the name as a string and score as an int both together. We then call this scores so we can refer to this in
// the class
