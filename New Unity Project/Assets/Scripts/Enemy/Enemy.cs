using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyScript
{
    private Vector3 currentTarget;
    public bool enemyisDead = false;

    void Start()
    {
        currentTarget = transform.position;
        pointA = currentTarget.x;
        pointB = currentTarget.x + range;
    }
    void Update()
    {
        if (transform.position.x == pointA)
        {
            currentTarget.x = pointB;
        }
        if (transform.position.x == pointB)
        {
            currentTarget.x = pointA;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
    public void Kill()
    {
        enemyisDead = true;
        Destroy(this.gameObject);
    }
    
}
