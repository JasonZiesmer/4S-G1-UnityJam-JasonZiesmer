using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TextBehavior : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component in Unity Inspector
    public TextMeshProUGUI displayText;

    // Reference to the Image component in Unity Inspector
    public Image displayImage;

    // List to store all trigger zones the player is inside
    private List<Collider2D> triggerZones = new List<Collider2D>();

    private bool isInitialized = false;

    private void Start()
    {
        InitializeVisibility();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Add the trigger zone to the list
            triggerZones.Add(other);

            Debug.Log("Enter Trigger Zone: " + gameObject.name);
            Debug.Log("Trigger Zones Count: " + triggerZones.Count);

            // Initialize visibility on the first trigger enter
            if (!isInitialized)
            {
                InitializeVisibility();
                isInitialized = true;
            }

            // Make the text and image visible when the player is inside any trigger zone
            if (displayText != null && triggerZones.Count > 0)
            {
                displayText.enabled = true;
            }

            if (displayImage != null && triggerZones.Count > 0)
            {
                displayImage.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Remove the trigger zone from the list
            triggerZones.Remove(other);

            Debug.Log("Exit Trigger Zone: " + gameObject.name);
            Debug.Log("Trigger Zones Count: " + triggerZones.Count);

            // Make the text and image invisible when the player is not inside any trigger zone
            if (displayText != null && triggerZones.Count == 0)
            {
                displayText.enabled = false;
            }

            if (displayImage != null && triggerZones.Count == 0)
            {
                displayImage.enabled = false;
            }
        }
    }

    private void InitializeVisibility()
    {
        // Set the initial visibility state of text and image
        if (displayText != null)
        {
            displayText.enabled = false;
        }

        if (displayImage != null)
        {
            displayImage.enabled = false;
        }
    }
}

