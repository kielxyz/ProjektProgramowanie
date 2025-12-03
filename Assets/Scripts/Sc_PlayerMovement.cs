using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");

        if(directionX != 0)
        {
            rb.linearVelocity = new Vector2(directionX * 5f, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(0, 5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
