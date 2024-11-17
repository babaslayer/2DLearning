using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform Muzzle_Pos; // Merminin ��k�� noktas�
    [SerializeField] private BulletPool bulletPool; // Mermi havuzu referans�

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
        GameObject _bullet = bulletPool.GetFromPool(); // Yeni bir mermi nesnesi referans� al�yoruz ve onu havuzdan ��kar�yoruz.
        if (_bullet != null)
        {
            Bullet bulletScript = _bullet.GetComponent<Bullet>();//Buradaki ama�, _bullet GameObject'inin �zerinde bulunan Bullet bile�enine (scriptine) referans almak.
            Vector2 velocity = Muzzle_Pos.right * bulletScript.bulletSpeed; // Mermi h�z�
            bulletScript.ResetBullet(Muzzle_Pos.position, Muzzle_Pos.rotation, velocity);
        }
        else
        {
            Debug.LogWarning("Mermi havuzu dolu! Havuz boyutunu art�rmay� d���nebilirsiniz.");
        }
    }
}
