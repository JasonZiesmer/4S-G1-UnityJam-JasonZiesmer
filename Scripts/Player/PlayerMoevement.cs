using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoevement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 5;
    public float jumpForce = 5f;
    
    float inputHorizontal;
    bool facingRight = true;

    // Removed PlayerMoveActions and InputAction references

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Replaced moveDirection with inputHorizontal
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}