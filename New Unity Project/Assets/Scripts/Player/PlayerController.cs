using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    PlayerGravity playerGravity;
    

    //Player Movement
    public float PlayerSpeed;
    private float horizontalInput;

    //jump
    private bool canJump;
    public float jumpForce;
            //hangtime
    public float hangtime = .2f;
    private float hangcounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        playerGravity = FindObjectOfType<PlayerGravity>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
        Jump();
    }
    void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * PlayerSpeed, rb.velocity.y);
        Rotaion();
    }
#region ROTATION
    void Rotaion()
    {
        if (rb.gravityScale >= 0)
        {
            if (horizontalInput > 0)
            {
                playerSprite.flipX = false;
            }
            if (horizontalInput < 0)
            {
                playerSprite.flipX = true;
            }

            transform.eulerAngles = Vector3.zero;
        }
        if (rb.gravityScale < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
            if (horizontalInput > 0)
            {
                playerSprite.flipX = true;
            }
            if (horizontalInput < 0)
            {
                playerSprite.flipX = false;
            }
        }
    }
    #endregion
#region Jump
    void Jump()
    {
        //manage HangTime
        if (canJump == true)
        {
            hangcounter = hangtime;
        }
        else
        {
            hangcounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && hangcounter >= 0)
        {

            if (rb.gravityScale > 0)
            {
                rb.velocity = Vector2.up *  jumpForce;
            }
            if (rb.gravityScale < 0)
            {
                rb.velocity = Vector2.down * jumpForce;
            }

        }
    }
    #endregion
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            canJump = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            canJump = false;

        }
    }
    

}
