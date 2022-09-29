using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TextMeshProUGUI SensitivityValueText;
    public TextMeshProUGUI MovementSensitivityValueText;
    public TextMeshProUGUI SoundValueText;


    public float sensitivity;
    public float movementSensitvity;
    public float Sound;

    public void OnValueChangedSensitivty(float value)
    {
        SensitivityValueText.text = value.ToString();
        sensitivity = value;
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
    }
    public void OnValueChangedMovementSens(float value)
    {
        MovementSensitivityValueText.text = value.ToString();
        movementSensitvity = value;
        PlayerPrefs.SetFloat("MoveSens", movementSensitvity);
    }
    public void SetVolume (float value)
    {
        SoundValueText.text = value.ToString();
        Sound = value;
        PlayerPrefs.SetFloat("Sound", Sound);

    }
}
