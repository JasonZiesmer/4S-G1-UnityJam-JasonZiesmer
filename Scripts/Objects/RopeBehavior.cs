using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject player;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange)
        {
            // Use the old Unity input system to get vertical input
            float verticalInput = Input.GetAxis("Vertical");

            // Move the player object up or down based on the input
            Vector2 moveDirection = new Vector2(0f, verticalInput);
            player.GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            // Disable gravity when on the rope
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Enable gravity when leaving the rope
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
