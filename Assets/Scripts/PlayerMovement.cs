using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Walk(Vector2 movement)
    {
        float moveSpeed = 3f;
        rb.velocity = movement * moveSpeed;
    }
    public void Run(Vector2 movement)
    {
        float moveSpeed = 6f;
        rb.velocity = movement * moveSpeed;
    }
    public void Sprint(Vector2 movement)
    {
        float moveSpeed = 10f;
        rb.velocity = movement * moveSpeed;
    }
    public void Dash(Vector2 movement)
    {
        float dashAmount = 7f;
        rb.MovePosition(rb.position + movement * dashAmount);
    }


}
