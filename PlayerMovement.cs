
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movement;
    private float moveSpeed = 2f;
    public Object laser;
    



    private float timer;

    private void Start()
    {
        laser = Resources.Load("Laser");
    }

    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0) && Time.time >= timer)
        {
            Attack();
            timer += Time.time + 0.02f;
        }
    }

    private void FixedUpdate()
    {

        Vector2 direction = movement.normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Someone")  {
            print("Hit!");
        }
    }

    private void Attack()
    {
        GameObject LaserBeam = (GameObject)Instantiate(laser);
        LaserBeam.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y  - 0.1f, -1);
        print("Attack!");
        timer = 0.5f;
    }

}

