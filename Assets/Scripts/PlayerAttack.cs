using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Dictionary<string, GameObject> projectileList = new Dictionary<string, GameObject>();

    private Vector2 menuPos;
    private Vector2 direction;
    private Vector2 projPos;
    private float angle;
    private GameObject proj;

    private void Update()
    {
        
    }

    private void Start()
    {
        projectileList.Add("ShockArrow", Resources.Load<GameObject>("Prefabs/ShockArrow"));
        projectileList.Add("ShockRoller", Resources.Load<GameObject>("Prefabs/ShockRoller"));
    }

    public List<float> Attack(Vector3 playerPosition, string prefabName)
    {
        System.Console.WriteLine(prefabName);
        GameObject tempProjectile = projectileList[prefabName];
        ProjectileMechanic tempProjectileMechanic = tempProjectile.GetComponent<ProjectileMechanic>();

        tempProjectileMechanic.type = "Player";
        menuPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (menuPos - (Vector2)playerPosition).normalized;
        projPos = playerPosition + (Vector3)direction * 0.5f;
        proj = Instantiate(tempProjectile, projPos, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().velocity = direction * tempProjectileMechanic.speed;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        proj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        proj.GetComponent<ProjectileMechanic>().damage = tempProjectileMechanic.damage;

        return new List<float> { tempProjectileMechanic.freezeTime, tempProjectileMechanic.cooldown } ;
    }
}
