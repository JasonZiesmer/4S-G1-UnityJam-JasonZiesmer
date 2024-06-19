using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    // Function to handle the Back button click
    public void OnBackButtonClick()
    {
        // Load the 'OptionScene' when the Options button is clicked
        SceneManager.LoadScene("MenuScene");
    }

    // Function to handle the Back button click
    public void OnLevelSelectionClick()
    {
        // Load the 'OptionScene' when the Options button is clicked
        SceneManager.LoadScene("LevelSelection");
    }
}
