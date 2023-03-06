using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sr;
    
    [SerializeField] private LayerMask jumpableGround;
    
    private float dirX = 0f;
    private float dirY = 0f;
    
    [SerializeField] private float Speed = 7f;
    [SerializeField] private float JumpForce = 14f;


    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling,
        crouching,
        climbing
    };

	[SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        
    }
    
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * Speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
			//jumpSoundEffect.Play();
            AudioManager.instance.PlaySFX("jump");
           rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        UpdateAnimationState();

        dirY = Input.GetAxis("Vertical");
        
        if (dirY < 0f && IsGrounded())
        {
            anim.SetInteger("State", (int)MovementState.crouching);
        }
    }

    private void UpdateAnimationState()
    {
        MovementState State;
        
        if (dirX > 0f)
        {
            State = MovementState.running;
            sr.flipX = false;
        }else if (dirX < 0f)
        {
            State = MovementState.running;
            sr.flipX = true;
        }
        else
        {
            State = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            State = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            State = MovementState.falling;
        }
        anim.SetInteger("State", (int)State);

    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
