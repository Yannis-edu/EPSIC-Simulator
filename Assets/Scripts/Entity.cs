using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float speed;
    public float runRatio;
    public float jumpPower;

    public bool grounded;
    public float vertical;
    public Animator animator;

    protected Rigidbody2D rb;
    protected SpriteRenderer sprite;
    protected DateTime jumpMaxTime;
    protected bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    protected void Move(float horizontal, bool jump, bool run)
    {
        if (jump)
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

        horizontal *= speed;

        sprite.flipX = horizontal < 0 ? true : horizontal > 0 ? false : sprite.flipX;

        if (run)
        {
            horizontal *= runRatio;
        }

        rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime, rb.velocity.y);

        animator.SetFloat("speedH", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("speedV", rb.velocity.y);
        animator.SetBool("isJumping", !grounded);
    }
}
