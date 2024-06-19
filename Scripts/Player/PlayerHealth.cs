using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    [SerializeField] private int currentHealth; // Expose currentHealth to the Inspector

    public GameObject gm;
    [SerializeField] private string gameOverSceneName; // Name of the game over scene to load

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            TakeDamage();
        }
        else if (other.CompareTag("Enemy")) // Check for the "Enemy" tag
        {
            Die();
        }
    }

    public void TakeDamage()
    {
        currentHealth--;

        gameObject.transform.position = gm.GetComponent<GameManager>().lastCheckPoint;

        // Check if health is zero after taking damage
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform actions when the player dies, e.g., respawn logic, game over screen, etc.
        Debug.Log("Player has died!");

        // Load the appropriate game over scene
        SceneManager.LoadScene(gameOverSceneName);
    }
}
