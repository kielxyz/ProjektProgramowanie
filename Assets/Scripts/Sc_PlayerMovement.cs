using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private float directionX;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSFX;

    private enum MovementState { idle, running, jumping, falling }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        Movement();
        UpdateAnimationState();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Movement()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        if (directionX != 0)
        {
            rb.linearVelocity = new Vector2(directionX * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSFX.Play();
            rb.linearVelocity = new Vector2(0, jumpForce);
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.linearVelocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.linearVelocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
