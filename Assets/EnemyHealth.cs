using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxEnemyHp=10f;
    [SerializeField] float enemyHp;
    [SerializeField] Rigidbody2D enemyBody;

    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        enemyHp = maxEnemyHp;
    }

    
    void Update()
    {
        
    }

    void TakeDamage(float damage)
    {
        enemyHp -= damage;

        if (enemyHp < 0) 
        {
            Die();
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
                bullet.ReturnToPool();


            }
        
        }
    }

    void Die()
    {
        Destroy(enemyBody);
        

    }

}
