
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float moveSpeed = 1f;
    public Object laser;
    private Animator anim;



    private float timer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        laser = Resources.Load("Laser");
    }

    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0 || movement.y == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= timer)
        {
            Attack();
            timer += Time.time + 0.005f;
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

