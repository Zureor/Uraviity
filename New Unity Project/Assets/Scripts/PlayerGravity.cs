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
    private bool canGravityIncrease = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = DefaultGravity;
        StartCoroutine("GravityReset");
    }

    // Update is called once per frame
    void Update()
    {
        if (canGravityIncrease == true)
        {
            if (rb.gravityScale >= 0)
            {
                rb.gravityScale += Time.deltaTime * GravityAcceleration;
            }
            if (rb.gravityScale < 0)
            {
                rb.gravityScale -= Time.deltaTime * GravityAcceleration;
            }
        }
        if (canGravityIncrease == false)
        {
            if (rb.gravityScale >= 0)
            {
                rb.gravityScale = DefaultGravity;
            }
            if (rb.gravityScale <= 0)
            {
                rb.gravityScale = DefaultGravity * -1;
            }
        }
    }
    
    IEnumerator GravityReset()
    {
        yield return new WaitForSeconds(GravityTimer);
        canGravityIncrease = true;
        rb.gravityScale = DefaultGravity * -1;
        StartCoroutine("GravityFix");

        yield return new WaitForSeconds(GravityTimer);
        canGravityIncrease = true;
        rb.gravityScale = DefaultGravity;
        StartCoroutine("GravityFix");

        StartCoroutine("GravityReset");
    }

    IEnumerator GravityFix()
    {
            yield return new WaitForSeconds(.5f);
            canGravityIncrease = false;
    }
}
