using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public PlayerMovement(Rigidbody2D rb)
    {
        this.rb = rb;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Vector2 movement)
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

}
