using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ProjectileMechanic : MonoBehaviour
{
    public float damage;
    public float range = 10f;
    public float cooldown;
    public float freezeTime;
    public float speed;
    private Animator animator;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Player" && other.tag != "DeepMap")
        {
            rb.velocity = Vector2.zero;
            if(other.GetComponent<EnemyController>() != null)
            {
                other.GetComponent<EnemyController>().DealDamage(damage);
            }
            animator.SetBool("Explode", true);
        }
    }
    private void FixedUpdate()
    {
        range -= Time.deltaTime;
        if (range <= 0)
        {
            Destroy(gameObject);
        }
    }
}
