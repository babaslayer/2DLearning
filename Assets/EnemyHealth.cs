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

        if (enemyHp <= 0) 
        {
           Destroy(enemyBody);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) // Çarpan nesne "Bullet" tagine sahip mi?
        {
            Bullet bullet = collision.GetComponent<Bullet>(); // Bullet bileþenini al
            if (bullet != null)
            {
                TakeDamage(bullet.damage); // Hasar ver
                bullet.ReturnToPool(); // Mermiyi havuza geri gönder
            }
        }
    }
}
