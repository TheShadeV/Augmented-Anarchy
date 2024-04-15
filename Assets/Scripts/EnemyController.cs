using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float totalHealth;
    public float health;
    public float detectDist, AttackDistance ;
    private Transform player;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float cd;
    public float speed;
    public string type;
    public string ProjectileType;
    public Transform AttackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
public int attackCD;
    void Start()
    {
        anim = GetComponent<Animator>();
        health = totalHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();

    }
    void Update()
    {

        if (health <= 0)
        {
            anim.SetBool("Explode", true);
        }
        float Distance = Vector2.Distance(transform.position, player.position);
        
        rb2d.velocity = Vector2.zero;
        if(Distance <= AttackDistance)
        {
            if (cd <= 0)
            {
                if(type == "ranged"){
                    Vector2 VectorDist = player.position - transform.position;
                    VectorDist.Normalize();
                    GameObject tempProjectile = Resources.Load<GameObject>("Prefabs/Projectiles/"+ ProjectileType);
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
                else if(type == "melee"){
                    anim.SetBool("isAttacking", true);
                    cd = attackCD;

                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

                    foreach(Collider2D enemy in hitEnemies)
                    {
                        
                        Debug.Log("Hit" + enemy.name);
                        enemy.transform.GetComponent<PlayerController>().DealDamage(40);
                        //enemy.GetComponent<PlayerController>().DealDamage(10);
                    }
                }
            }
            
            else
            {
                cd -= Time.deltaTime;
                rb2d.velocity = Vector2.zero;
                return;
            }
            
        }
        else if (Distance <= detectDist)
        {
            anim.SetBool("isRunning", true);
            rb2d.velocity = (player.position - transform.position )* speed;
            
            bool flipped = player.position.x < transform.position.x;
            this.transform.rotation = Quaternion.Euler(0, flipped ? 180 : 0, 0);

        }
        else{
            anim.SetBool("isRunning", false);
        }
    }
    public void DealDamage(float damage)
    {
        anim.SetBool("isHurt", true);
        detectDist = 12;
        this.health -= damage;
    }
    void OnDrawGizmosSelected()
    {
        if(AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
