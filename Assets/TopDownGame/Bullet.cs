using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletBody;
    public float bulletSpeed; // Mermi h�z�
    [SerializeField] private float bulletLifeTime = 5f; // Merminin ya�am s�resi
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

    private void OnEnable()//Nesne set active true oldu�unda �al���r.
    {
        bulletBody.velocity = Vector2.zero; // H�z s�f�rlan�yor
        Invoke(nameof(ReturnToPool), bulletLifeTime); // Ya�am s�resi tamamlan�nca havuza d�n
    }

    private void OnDisable()//Nesne Set Active false oldu�unda �al���r.
    {
        CancelInvoke(nameof(ReturnToPool)); // �nceki Invoke'u iptal et
        bulletBody.velocity = Vector2.zero; // H�z s�f�rlan�yor
    }

    public void ReturnToPool()
    {
        pooling.ReturnToPool(gameObject); // Havuza geri d�n
    }

    public void ResetBullet(Vector3 position, Quaternion rotation, Vector2 velocity)
    {
        transform.position = position; // Yeni pozisyon
        transform.rotation = rotation; // Yeni rotasyon
        bulletBody.velocity = velocity; // Yeni h�z ayar�
        gameObject.SetActive(true); // Mermiyi aktif et
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.CompareTag("Enemy")) // �arpan nesne "Bullet" tagine sahip mi?
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                
                enemy.TakeDamage(damage);// Hasar ver
                ReturnToPool(); // Mermiyi havuza geri g�nder
            }
        }
    }
}
