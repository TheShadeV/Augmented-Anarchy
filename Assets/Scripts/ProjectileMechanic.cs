using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileMechanic : MonoBehaviour
{
    public float damage;
    private float range = .5f;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("szar");
        if (other.name != "Player" && other.tag != "DeepMap")
        {
            if(other.GetComponent<EnemyReceiveDamage>() != null)
            {
                other.GetComponent<EnemyReceiveDamage>().DealDamage(damage);
            }
            DestroyObject();
        }
    }
    private void FixedUpdate()
    {
        range -= Time.deltaTime;
        if (range <= 0)
        {
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        GameObject effect = Instantiate(Resources.Load("Prefabs/ShockArrow_Explode"), transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 0.2f);
        Destroy(gameObject);
    }
}
