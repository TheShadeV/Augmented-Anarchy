using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float totalHealth;
    public float health;
    public float detectDist = 8f, rangedAttackDistance = 4f;
    private Transform player;
    private Rigidbody2D rb2d;
    void Start()
    {
        totalHealth = 50;
        health = totalHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        float Distance = Vector2.Distance(transform.position, player.position);
        if(Distance <= rangedAttackDistance)
        {
            rb2d.velocity = Vector2.zero;
            Debug.Log("Shoot this Nigga");
        }
        else if (Distance <= detectDist)
        {
            rb2d.velocity = (player.position - transform.position )* .7f;
        }
    }
    public void DealDamage(float damage)
    {
        this.health -= damage;
    }
}
