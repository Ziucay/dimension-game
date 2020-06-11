using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    public States st;

    public float speed;
    public float jumpHeight;
    public int jumps;
    public float coyoteJumpDelay;
    [SerializeField]
    private int remainingJumps;
    private bool onGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        remainingJumps = jumps;
        onGround = false;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") > 0)
            sr.flipX = false;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            sr.flipX = true;
    }
    
    void Update()
    {
       
        switch (st)
        {
            case States.IDLE:
                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }
                else if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    ChangeState(States.RUN);
                }
                break;
            case States.RUN:
                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                    break;
                }
                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    ChangeState(States.IDLE);
                }
                break;
            case States.JUMP:
                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }
                break;
        }
    }

    void Jump()
    {
        if (remainingJumps > 0)
        {
            ChangeState(States.JUMP);
            remainingJumps--;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpHeight));
        }
    }

    void ChangeState(States s)
    {
        st = s;
        switch (st)
        {
            case States.IDLE:
                anim.SetInteger("Param", 0);
                break;
            case States.RUN:
                anim.SetInteger("Param", 1);
                break;
            case States.JUMP:
                anim.SetInteger("Param", 2);
                break;
        }

    }

    public enum States
    {
        IDLE,
        RUN,
        JUMP,
        DIE
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            onGround = true;
            remainingJumps = jumps;
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                ChangeState(States.IDLE);
            }
            else
            {
                ChangeState(States.RUN);
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        StartCoroutine("CoyoteJump");
    }

    IEnumerator CoyoteJump()
    {
        onGround = false;
        yield return new WaitForSeconds(coyoteJumpDelay);
        if (remainingJumps == jumps)
            remainingJumps--;
    }
}
