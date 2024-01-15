using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float totalHealth;
    public float health;
    public float detectDist = 9f, rangedAttackDistance = 8f;
    private Transform player;
    private Rigidbody2D rb2d;
    public float cd;
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
            if (cd <= 0)
            {
            Vector2 VectorDist = player.position - transform.position;
            VectorDist.Normalize();
            GameObject tempProjectile = Resources.Load<GameObject>("Prefabs/ShockBullet");
            ProjectileMechanic tempProjectileMechanic = tempProjectile.GetComponent<ProjectileMechanic>();
            tempProjectileMechanic.type = "Enemy";
            rb2d.velocity = Vector2.zero;
            Vector2 projPos = (Vector2)transform.position + VectorDist * .9f;
            GameObject proj = Instantiate(tempProjectile, projPos, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity = VectorDist * tempProjectileMechanic.speed;
            float angle = Mathf.Atan2(VectorDist.y, VectorDist.x) * Mathf.Rad2Deg;
            proj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            proj.GetComponent<ProjectileMechanic>().damage = tempProjectileMechanic.damage;
            cd = tempProjectileMechanic.cooldown;
            }
            else
            {
                cd -= Time.deltaTime;
                return;
            }
            
        }
        else if (Distance <= detectDist)
        {
            rb2d.velocity = (player.position - transform.position )* .25f;
        }
    }
    public void DealDamage(float damage)
    {
        this.health -= damage;
    }
}
