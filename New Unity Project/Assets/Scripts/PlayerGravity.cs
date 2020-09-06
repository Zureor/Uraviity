using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    //gravity
    private Rigidbody2D rb;
    public float GravityTimer = 3;
    public float DefaultGravity;
    public float GravityAcceleration;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = DefaultGravity;
        StartCoroutine("GravityReset");
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.gravityScale >= 0)
        {
            rb.gravityScale += Time.deltaTime * GravityAcceleration;
        }
        if(rb.gravityScale <= 0)
        {
            rb.gravityScale -= Time.deltaTime * GravityAcceleration;
        }
    }
    
    IEnumerator GravityReset()
    {
        yield return new WaitForSeconds(GravityTimer);
        rb.gravityScale = DefaultGravity * -1;
        yield return new WaitForSeconds(GravityTimer);
        rb.gravityScale = DefaultGravity;
        StartCoroutine("GravityReset");
    }
}
