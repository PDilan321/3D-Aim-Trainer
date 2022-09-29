using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity; //Public variables allows the developer to change the numbers whilst creating the game to test different values
    float xRotation = 0f; // This is a variable that will allow x-roatation to occur and we manually set this to 0f.
    public Transform playerBody;
    bool HasInvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hides the cursor when project is running
        Invoke("Looking", 4);
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");

    }

    // Update is called once per frame
    void Update()
    {
        if (HasInvoked == true)
        {
            Looking(); // Calls the function "Looking" every frame
        }

        
    }
    public void Looking()
    {
        HasInvoked = true;
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // Multiplying the mouse sensitivity will later allow the user to change this
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamping restricts mouse movement beyond 90 degrees either side
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Quaterion are used to represent rotations within Unity
        playerBody.Rotate(Vector3.up * MouseX); // This is to rotate the gameobject 'playerBody'
    }
}


