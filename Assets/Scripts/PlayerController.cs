using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    public Vector2 moveInput;
    private Animator anim;
    public float dodgeTimer;
    public bool isDashing;
    public bool isFreeze;
    public float freezeTime;
    private PlayerAttack Attack;
    private Transform PlayerPosition;
    private PlayerMovement Movement;
    public SortedList<string, float> spellTimers = new SortedList<string, float>();
    public int totalHealth;
    public int maxHealth = 300;

    private void Start()
    {
        dodgeTimer = 0;
        anim = GetComponent<Animator>();
        Attack = GetComponent<PlayerAttack>();
        PlayerPosition = GetComponent<Transform>();
        Movement = GetComponent<PlayerMovement>();
        totalHealth = maxHealth;
        isFreeze = false;
        freezeTime = 0.5f;

        GameObject.Find("API").GetComponent<CharacterUpdater>().ApiRequest("getCharacterData");
    }

    private void Update()
    {
        if (totalHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        updateCooldowns();

        Console.WriteLine(isFreeze);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        if (moveInput.x != 0 && moveInput.y != 0 || moveInput.x != 0 || moveInput.y != 0)
        {
            SwitchIdle(true);
            bool flipped = moveInput.x < 0;
            this.transform.rotation = Quaternion.Euler(0, flipped ? 180 : 0, 0);
        }
        else
        {
            SwitchIdle(false);
        }

        anim.SetFloat("AxisX", moveInput.x);
        anim.SetFloat("AxisY", moveInput.y);

        if (Input.GetMouseButtonDown(0))
        {
            if (spellTimers.ContainsKey("ShockArrow"))
            {
                if (spellTimers["ShockArrow"] <= 0)
                {
                    List<float> temp = Attack.Attack(PlayerPosition.position, "ShockArrow");
                    freezeTime = temp[0];
                    spellTimers["ShockArrow"] = temp[1];
                    Debug.Log(spellTimers["ShockArrow"]);
                }
                else
                {
                    Debug.Log(spellTimers["ShockArrow"]);
                }
            }
            else
            {
                List<float> temp = Attack.Attack(PlayerPosition.position, "ShockArrow");
                freezeTime = temp[0];
                spellTimers.Add("ShockArrow", temp[1]);

                Debug.Log(spellTimers["ShockArrow"]);
            }

            isFreeze = true;
            rb2d.velocity = Vector2.zero;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (spellTimers.ContainsKey("ShockRoller"))
            {
                if (spellTimers["ShockRoller"] <= 0)
                {
                    List<float> temp = Attack.Attack(PlayerPosition.position, "ShockRoller");
                    freezeTime = temp[0];
                    spellTimers["ShockRoller"] = temp[1];
                    Debug.Log(spellTimers["ShockRoller"]);
                }
                else
                {
                    Debug.Log(spellTimers["ShockRoller"]);
                }
            }
            else
            {
                List<float> temp = Attack.Attack(PlayerPosition.position, "ShockRoller");
                freezeTime = temp[0];
                spellTimers.Add("ShockRoller", temp[1]);

                Debug.Log(spellTimers["ShockRoller"]);
            }

            isFreeze = true;
            rb2d.velocity = Vector2.zero;
        }



        if (Input.GetKeyDown(KeyCode.Space) && dodgeTimer <= 0)
        {
            isDashing = true;
            dodgeTimer = 2f;
            Debug.Log("Dash");
        }
        if (dodgeTimer > 0)
        {
            dodgeTimer -= Time.deltaTime;
        }
    }
    void SwitchIdle(bool isRun)
    {
        anim.SetBool("isRunning", isRun);
        anim.SetLayerWeight(1, Convert.ToInt32(isRun));
        anim.SetLayerWeight(0, Convert.ToInt32(!isRun));

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ExitArea")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void FixedUpdate()
    {
        if (!isFreeze)
        {
            if (Input.GetKey(KeyCode.LeftShift)) //Sprint
            {
                Movement.Sprint(moveInput);
            }
            else if (Input.GetKey(KeyCode.LeftAlt)) //Walk
            {
                Movement.Walk(moveInput);
            }
            else //Run
            {
                Movement.Run(moveInput);
            }
            if (isDashing)
            {
                //CreateDashEffect.CreateEffect(transform.position, moveInput, 7);

                Movement.Dash(moveInput);
                isDashing = false;
            }
        }
        else
        {
            if (freezeTime <= 0 && isFreeze == true)
            {
                isFreeze = false;
            }
            else
            {
                freezeTime -= Time.deltaTime;
            }
        }
    }
    private void updateCooldowns()
    {
        if (spellTimers.Count == 0)
        {
            return;
        }
        List<string> keys = new List<string>(spellTimers.Keys);
        foreach (string key in keys)
        {
            if (spellTimers[key] <= 0)
            {
                spellTimers.Remove(key);
            }
            else
            {
                spellTimers[key] -= Time.deltaTime;
            }
        }
    }
    public void DealDamage(float damage)
    {
        totalHealth -= (int)damage;
        anim.SetLayerWeight(2, 1);
        anim.SetBool("isHurt", true);
        Debug.Log("Player took " + damage + " damage");
    }
}
