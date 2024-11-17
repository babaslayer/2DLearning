using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform Muzzle_Pos; // Merminin çýkýþ noktasý
    [SerializeField] private BulletPool bulletPool; // Mermi havuzu referansý

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject _bullet = bulletPool.GetFromPool(); // Yeni bir mermi nesnesi referansý alýyoruz ve onu havuzdan çýkarýyoruz.
        if (_bullet != null)
        {
            Bullet bulletScript = _bullet.GetComponent<Bullet>();//Buradaki amaç, _bullet GameObject'inin üzerinde bulunan Bullet bileþenine (scriptine) referans almak.
            Vector2 velocity = Muzzle_Pos.right * bulletScript.bulletSpeed; // Mermi hýzý
            bulletScript.ResetBullet(Muzzle_Pos.position, Muzzle_Pos.rotation, velocity);
        }
        else
        {
            Debug.LogWarning("Mermi havuzu dolu! Havuz boyutunu artýrmayý düþünebilirsiniz.");
        }
    }
}
