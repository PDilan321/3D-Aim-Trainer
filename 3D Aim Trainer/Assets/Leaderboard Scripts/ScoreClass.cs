using System;

[Serializable]
public class ScoreClass
{
    public string Name; // Creatin two public variables 
    public float score;
    public ScoreClass(string name, int score) // Function that takes in two parameters
    {
        this.Name = name; // 'this.name' represents the instance variable whilst the 'name' variable is the parameter passed into this
        this.score = score;
    }
}
// This will be the data class that represents what score means
