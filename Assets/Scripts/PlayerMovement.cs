using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isDashing;
    public float dashTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(0, 4, false);
        }
    }
    public void Walk(Vector2 movement)
    {
        float moveSpeed = 1.5f;
        rb.velocity = movement * moveSpeed;
    }
    public void Run(Vector2 movement)
    {
        float moveSpeed = 3f;
        rb.velocity = movement * moveSpeed;
    }
    public void Sprint(Vector2 movement)
    {
        float moveSpeed = 5f;
        rb.velocity = movement * moveSpeed;
    }
    public void Dash(Vector2 movement)
    {
        float dashAmount = 3.5f;
        dashTimer = 0.1f;
        Physics2D.IgnoreLayerCollision(0, 4, true);
        rb.MovePosition(rb.position + movement * dashAmount);
    }


}