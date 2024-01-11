using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMechanic : MonoBehaviour
{
    public float damage;
    private float range = 10f;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fly");
        if (other.name != "Player" && other.tag != "DeepMap")
        {
            if(other.GetComponent<EnemyReceiveDamage>() != null)
            {
                other.GetComponent<EnemyReceiveDamage>().DealDamage(damage);
            }
            Destroy(gameObject);
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
