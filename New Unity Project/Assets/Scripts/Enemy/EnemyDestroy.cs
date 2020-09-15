using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private Enemy enemy;
    
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {

            enemy.Kill();
        }
    }
}
