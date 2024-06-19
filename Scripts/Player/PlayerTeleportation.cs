using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    private GameObject currentTeleporter;
    public Sprite originalSprite;
    public Sprite portalSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleSprite();
        }

        if (Input.GetKeyDown(KeyCode.E) && currentTeleporter != null)
        {
            // Check the color-specific condition for YellowPortal and BlurPortal
            if ((currentTeleporter.CompareTag("YellowPortal") && spriteRenderer.sprite == portalSprite) ||
                (currentTeleporter.CompareTag("BlurPortal") && spriteRenderer.sprite == originalSprite))
            {
                TeleportPlayer(currentTeleporter);
            }
            // Allow teleportation for PinkPortal regardless of color
            else if (currentTeleporter.CompareTag("PinkPortal"))
            {
                TeleportPlayer(currentTeleporter);
            }
        }
    }

    private void TeleportPlayer(GameObject teleporter)
    {
        transform.position = teleporter.GetComponent<PortalBehavior>().GetDestination().position;
    }

    private void ToggleSprite()
    {
        
        if (spriteRenderer.sprite == originalSprite)
        {
            spriteRenderer.sprite = portalSprite;
        }
        else
        {
            spriteRenderer.sprite = originalSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlurPortal") || collision.CompareTag("YellowPortal") || collision.CompareTag("PinkPortal"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentTeleporter)
        {
            currentTeleporter = null;
        }
    }
}