using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManager class

public class PortalBehavior : MonoBehaviour
{
    [SerializeField] private Transform destination;
    
    // Add this method to handle the trigger enter event
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("BlackPortal"))
        {
            Debug.Log("Player entered BlackPortal trigger.");
        }
    }

    // Add this method to check for the E key press and load the next scene
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D playerCollider = GetComponent<Collider2D>();

            if (gameObject.CompareTag("BlackPortal1") && playerCollider != null && playerCollider.IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
            {
                Debug.Log("Player pressed E while in BlackPortal trigger. Loading next scene.");
                SceneManager.LoadScene("+GameScene");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D playerCollider = GetComponent<Collider2D>();

            if (gameObject.CompareTag("BlackPortal2") && playerCollider != null && playerCollider.IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
            {
                Debug.Log("Player pressed E while in BlackPortal trigger. Loading next scene.");
                SceneManager.LoadScene("EndScene");
            }
        }
        
      /*  if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D playerCollider = GetComponent<Collider2D>();

            if (gameObject.CompareTag("BlackPortal3") && playerCollider != null && playerCollider.IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
            {
                Debug.Log("Player pressed E while in BlackPortal trigger. Loading next scene.");
                SceneManager.LoadScene("EndScene");
            }
        }*/
        
    }

    // Method to load the next scene from the build settings
    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    // Method to get the destination
    public Transform GetDestination()
    {
        return destination;
    }
}