using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Function to handle the Play button click
    public void OnPlayButtonClick()
    {
        // Load the 'CutScene' when the Play button is clicked
        SceneManager.LoadScene("GameScene");
    }

    // Function to handle the Quit button click
    public void OnQuitButtonClick()
    {
        // Quit the game when the Quit button is clicked
        Application.Quit();
    }

    // Function to handle the Options button click
    public void OnOptionsButtonClick()
    {
        // Load the 'OptionScene' when the Options button is clicked
        SceneManager.LoadScene("OptionScene");
    }
}