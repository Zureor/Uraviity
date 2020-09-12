using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    private Rigidbody2D rb;
    //private SpriteRenderer playerSprite;
    PlayerGravity playerGravity;


    //Player Movement
    private float defaultRunSpeed;
    public float playerSpeed;
    public float dragSpeed;

    //jump
    private bool canJump;
    public float jumpForce;
    //hangtime
    public float hangtime = .2f;
    private float hangcounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerSprite = GetComponentInChildren<SpriteRenderer>();
        playerGravity = FindObjectOfType<PlayerGravity>();
        defaultRunSpeed = playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Jump();
    }
    void Movement()
    {
        rb.velocity = new Vector2(defaultRunSpeed, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.D))
        {
            defaultRunSpeed = dragSpeed;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            defaultRunSpeed = playerSpeed;
        }
    }

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
                rb.velocity = Vector2.up * jumpForce;
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
