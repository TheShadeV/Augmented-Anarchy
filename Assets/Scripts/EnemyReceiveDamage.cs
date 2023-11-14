using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiveDamage : MonoBehaviour
{
    public float totalHealth;
    public float health;

    void Start()
    {
        totalHealth = 50;
        health = totalHealth;
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DealDamage(float damage)
    {
        this.health -= damage;
    }
}
