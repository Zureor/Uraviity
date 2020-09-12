using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyScript
{
    private Vector3 currentTarget;

    void Start()
    {
        currentTarget = PointA.position;
    }
    void Update()
    {
        if (transform.position == PointA.position)
        {
            currentTarget = PointB.position;
        }
        else if (transform.position == PointB.position)
        {
            currentTarget = PointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
    public void Kill()
    {
        Destroy(this.gameObject);
    }
    
}
