using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private Enemy enemy;
    public bool enemyisDead = false;
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            enemyisDead = true;
            enemy.Kill();
        }
    }
}
