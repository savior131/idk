using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private bool isJumping = false;
    private bool isGrounded = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Horizontal movement
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        // Check if grounded
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        isGrounded = hit.collider != null;

        // Reset jumping flag
        if (isJumping && isGrounded)
        {
            isJumping = false;
        }
    }
}
