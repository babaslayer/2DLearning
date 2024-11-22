using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxEnemyHp=10f;
    [SerializeField] float enemyHp;
    [SerializeField] Rigidbody2D enemyBody;
    [SerializeField] Bullet bullet;

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

    public void TakeDamage(float damage)
    {
        enemyHp -= damage;

        if (enemyHp <= 0) 
        {
           Destroy(gameObject);
        }



    }
   
}
