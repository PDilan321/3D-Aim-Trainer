using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour

{
    //public GameManager _GameManager;
    public int CountDownTime;
    public Text CountDownDisplay; // Referencing the Countdown Text
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownToStart()); // Coroutine is called as soon as the script is loaded
    }

    IEnumerator CountDownToStart()
    {
        while (CountDownTime > 0)
        {
            CountDownDisplay.text = CountDownTime.ToString(); // Displaying the variable
            yield return new WaitForSeconds(1f); // Stopping for 1 second
            CountDownTime = CountDownTime-1; // Decrementing
        }
        CountDownDisplay.text = "GO!"; // Displaying 'GO!'
        yield return new WaitForSeconds(1f); // Stopping for 1 second
        CountDownDisplay.gameObject.SetActive(false); // Setting the whole game object to false so its no longer visible to the user when the game starts

    }
}
