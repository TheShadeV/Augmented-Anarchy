using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        dodgeTimer = 0;
        anim = GetComponent<Animator>();
        Attack = GetComponent<PlayerAttack>();
        PlayerPosition = GetComponent<Transform>();
        isFreeze = false;
        freezeTime = 0.5f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
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
            Debug.Log("ka");
            freezeTime = Attack.Attack(PlayerPosition.position);
            if (freezeTime > 0)
            {
                isFreeze = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && dodgeTimer <= 0)
        {
            isDashing = true;
            dodgeTimer = 2f;
            Debug.Log("Dodge");
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
    private void FixedUpdate()
    {
        if (!isFreeze)
        {
            if (Input.GetKey(KeyCode.LeftShift)) //Sprint
            {
                rb2d.velocity = moveInput * 10;
            }
            else if (Input.GetKey(KeyCode.LeftAlt)) //Walk
            {
                rb2d.velocity = moveInput * 3;
            }
            else //Run
            {
                rb2d.velocity = moveInput * moveSpeed;
            }
            if (isDashing)
            {
                float dashAmount = 5f;
                rb2d.MovePosition(rb2d.position + moveInput * dashAmount);
                isDashing = false;
            }
        }
        else
        {
            rb2d.velocity = moveInput *0;
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
}
