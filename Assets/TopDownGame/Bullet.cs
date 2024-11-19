using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletBody;
    public float bulletSpeed; // Mermi hýzý
    [SerializeField] private float bulletLifeTime = 5f; // Merminin yaþam süresi
    private BulletPool pooling;
    [SerializeField] public float damage;
    

    public void SetPool(BulletPool pool)
    {
       pooling=pool;
    }

    private void Awake()
    {
        bulletBody = GetComponent<Rigidbody2D>();
        

    }

    private void OnEnable()//Nesne set active true olduðunda çalýþýr.
    {
        bulletBody.velocity = Vector2.zero; // Hýz sýfýrlanýyor
        Invoke(nameof(ReturnToPool), bulletLifeTime); // Yaþam süresi tamamlanýnca havuza dön
    }

    private void OnDisable()//Nesne Set Active false olduðunda çalýþýr.
    {
        CancelInvoke(nameof(ReturnToPool)); // Önceki Invoke'u iptal et
        bulletBody.velocity = Vector2.zero; // Hýz sýfýrlanýyor
    }

    public void ReturnToPool()
    {
        pooling.ReturnToPool(gameObject); // Havuza geri dön
    }

    public void ResetBullet(Vector3 position, Quaternion rotation, Vector2 velocity)
    {
        transform.position = position; // Yeni pozisyon
        transform.rotation = rotation; // Yeni rotasyon
        bulletBody.velocity = velocity; // Yeni hýz ayarý
        gameObject.SetActive(true); // Mermiyi aktif et
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.CompareTag("Enemy")) // Çarpan nesne "Bullet" tagine sahip mi?
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                
                enemy.TakeDamage(damage);// Hasar ver
                ReturnToPool(); // Mermiyi havuza geri gönder
            }
        }
    }
}
