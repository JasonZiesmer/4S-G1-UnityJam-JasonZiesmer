using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseManager : MonoBehaviour
{
    // Function to handle the Quit button click
    public void OnQuitButtonClick()
    {
        // Quit the game when the Quit button is clicked
        Application.Quit();
    }

    public void OnGame0ButtonClick()
    {
        
        SceneManager.LoadScene("GameScene");
    }
    
    public void OnGame1ButtonClick()
    {
        
        SceneManager.LoadScene("+GameScene");
    }
    
    public void OnGame2ButtonClick()
    {
        
        SceneManager.LoadScene("++GameScene");
    }

    // Function to handle the Back to MainMenu button click
    public void OnBackToMainMenuButtonClick()
    {
        // Save the current scene name before loading the 'MainMenu'
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MenuScene");
    }
}
