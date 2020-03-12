using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Parameters
    public float speed;
    public float runRatio;
    public float jumpPower;
    public Animator animator;

    // Others public variables for others scripts
    public bool grounded;
    public bool pause;

    // Internal variables
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private DateTime jumpMaxTime;
    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!StaticClass.disableInput && SimpleInput.GetButton("Jump"))
        {
            if (grounded)
            {
                jumpMaxTime = DateTime.Now.AddSeconds(0.2);
                isJumping = true;
            }
            else if (DateTime.Now > jumpMaxTime)
            {
                isJumping = false;
            }
        }
        else
        {
            isJumping = false;
        }

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower * Time.fixedDeltaTime);
        }

        float directionH = StaticClass.disableInput ? 0 : SimpleInput.GetAxis("Horizontal");
        float moveSpeed = directionH * speed;

        sprite.flipX = directionH < 0 ? true : directionH > 0 ? false : sprite.flipX;

        if (!StaticClass.disableInput && SimpleInput.GetButton("Run"))
        {
            moveSpeed *= runRatio;
        }

        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rb.velocity.y);

        animator.SetFloat("speedH", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("speedV", rb.velocity.y);
        animator.SetBool("isJumping", !grounded);
    }
}
