using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(0, 5f);
        }
    }
}
