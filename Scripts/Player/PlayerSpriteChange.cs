using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChange : MonoBehaviour
{
    public Sprite originalSprite;
    public Sprite portalSprite;

    private SpriteRenderer spriteRenderer;
    private bool isPortalSprite = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Sritrenderer wird darauf zugewiesen denn vorhandenen Spriterenderer zu nutzen???
        spriteRenderer.sprite = originalSprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isPortalSprite) //wenn F gedrückt wird wird der Sprite geändert
        {
            spriteRenderer.sprite = portalSprite;
            isPortalSprite = true;
        }
        else if (Input.GetKeyDown(KeyCode.G) && isPortalSprite) //wenn G gedrückt wird wird der Sprite geändert
        {
            spriteRenderer.sprite = originalSprite;
            isPortalSprite = false;
        }
    }
}