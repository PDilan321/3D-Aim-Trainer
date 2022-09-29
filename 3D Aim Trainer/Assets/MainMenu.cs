using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI _name;

    public GameObject IsPlayMenuOpen, IsOptionsMenuOpen, IsMainMenuOpen; 

    public GameObject FirstButtonWhenInMainMenu, FirstButtonInPlayMenu, FirstButtonInOptionsMenu;

    public bool Checkdone = false;
    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(FirstButtonWhenInMainMenu); // This is done so the first button selected is the Play button
    }

    public void PlayTileGame() // Creating a function
    {
        if (_name.textInfo.characterCount != 1)
        {
            SceneManager.LoadScene("Game");
        }

        PlayerPrefs.SetString("name", _name.text);
    }
    public void PlayTrackingGame()
    {
        SceneManager.LoadScene("Tracking Game");
    }

    public void QuitGame()
    {
        Debug.Log("The application has quit");
        Application.Quit(); // Unity will not actually close down so we will print a statement replicate this
    }

    void Update()
    {

    }

    public void OpenPlayMenu()
    {
        IsPlayMenuOpen.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButtonInPlayMenu);

    }
    public void OpenOptionsMenu()
    {
        IsOptionsMenuOpen.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButtonInOptionsMenu);

    }
    public void OpenMainMenu()
    {
        IsMainMenuOpen.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButtonWhenInMainMenu);

    }

}