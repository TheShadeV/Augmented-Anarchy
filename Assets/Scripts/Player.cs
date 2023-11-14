using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player Stats
    public float maxHealth;
    public float Health;
    public float maxMana;
    public float Mana;
    public float maxStamina;
    public float Stamina;
    public float CritChance;
    public float CritDamage;
    public float Defense;
    public float Damage;

    //Player State
    public bool isFreeze = false;
    public float freezeTime;

    //Player Pos
    private Transform PlayerPosition;

    //Player Configs
    public Dictionary<string, string> AttackBindings = new Dictionary<string, string>();

    PlayerAttack Attack;
    Animator anim;
    Rigidbody2D rb;
    private Vector2 movement;
    PlayerMovement Movement;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Attack = GetComponent<PlayerAttack>();
        Movement = new PlayerMovement(rb);
        PlayerPosition = GetComponent<Transform>();



    }

    void Update()
    {
        Console.WriteLine(isFreeze);

        if (!isFreeze)
        {
            
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x != 0 && movement.y != 0 || movement.x != 0 || movement.y != 0)
            {
                SwitchIdle(true);
                bool flipped = movement.x < 0;
                this.transform.rotation = Quaternion.Euler(0, flipped ? 180 : 0, 0);
                Movement.Move(movement);
            }
            else
            {
                SwitchIdle(false);
            }

            anim.SetFloat("AxisX", movement.x);
            anim.SetFloat("AxisY", movement.y);

            if (Input.GetMouseButtonDown(0))
            {                
                freezeTime = Attack.Attack(PlayerPosition.position);
                if(freezeTime > 0)
                {
                    isFreeze = true;
                }
            }

        }
        else
        {
            if (freezeTime <= 0)
            {
                if(freezeTime < 0)
                {
                    freezeTime = 0;
                }
                isFreeze = false;
            }
            else
            {
                freezeTime -= Time.deltaTime;
            }
        }
    }


    void SwitchIdle(bool isRun)
    {
            anim.SetBool("isRunning", isRun);
            anim.SetLayerWeight(1, Convert.ToInt32(isRun));
            anim.SetLayerWeight(0, Convert.ToInt32(!isRun));
        
    }

}
