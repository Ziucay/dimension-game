using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spRenderer;
    private Vector2 moveVelocity;
    private bool jumping;
    public bool has_key;
    public int speed;
    public int jump_height;
    public int additional_jumps;
    int remaining_jumps;
    bool isDiying;
    void Start()
    {
        jumping = false;
        has_key = false;
        isDiying = false;
        remaining_jumps = additional_jumps;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (!isDiying)
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") > 0 && !isDiying)
        {
            if (!jumping)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isRunning", true);
            }
             
            spRenderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && !isDiying)
        {
            if (!jumping)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isRunning", true);
            }
                
            spRenderer.flipX = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && remaining_jumps > 0 && !isDiying)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", true);
            remaining_jumps -= 1;
            rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(new Vector2(0, jump_height));
            jumping = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            StartCoroutine("Death");
            isDiying = true;
        }
        if (col.gameObject.tag == "ground")
        {
            anim.SetBool("isJumping", false);
            remaining_jumps = additional_jumps;
            jumping = false;
        }
    }

    public IEnumerator Death()
    {
        anim.SetBool("isDiying", true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
