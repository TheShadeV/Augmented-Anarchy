using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    private float projectileSpeed = 3.5f;

    private float timer = 0f;
    private float LaserDelay = .5f;

    private float delay = 0.1f;
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void Start()
    {
        this.projectile = Resources.Load<GameObject>("Prefabs/ShockArrow");
    }

    public float Attack(Vector3 playerPosition)
    {
        System.Console.WriteLine(this.projectile);
        if(timer <= 0)
        {
            Vector2 menuPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (menuPos - (Vector2)playerPosition).normalized;
            Vector2 ProjPos = playerPosition + (Vector3)direction * 0.2f;
            GameObject laser = Instantiate(projectile, ProjPos, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            laser.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            laser.GetComponent<ProjectileMechanic>().damage = Random.Range(minDamage, maxDamage);
            timer = LaserDelay;

            return delay;
        }
        return 0;
    }
}
