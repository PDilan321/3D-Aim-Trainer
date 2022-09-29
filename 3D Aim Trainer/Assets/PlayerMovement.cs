using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // Creating a reference to the character controller
    public float MovementSpeed = 12f; // Creating a public variable called speed
    void Start()
    {
        MovementSpeed = PlayerPrefs.GetFloat("MoveSens");
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //Getting input from user if they press the 'A' and/or 'D' keys
        float z = Input.GetAxis("Vertical"); //Getting input from the user if they press the 'W' and/or 'S' keys

        Vector3 move = transform.right * x + transform.forward * z; // Creating a vector3
        controller.Move(move * MovementSpeed * Time.deltaTime); // Moving the user considering the speed
    }
}
