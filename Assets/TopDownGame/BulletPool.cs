using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Mermi prefab
    [SerializeField] private int poolSize; // Havuzdaki maksimum mermi sayýsý
    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            obj.GetComponent<Bullet>().SetPool(this); // Havuz referansý veriliyor
            bulletPool.Enqueue(obj);
        }
    }

    public GameObject GetFromPool()
    {
        if (bulletPool.Count > 0)
        {
            GameObject obj = bulletPool.Dequeue();
            obj.SetActive(true); // Mermiyi aktif et
            return obj;
        }

        // Havuzda mermi yoksa (opsiyonel olarak yeni bir tane oluþturabilirsiniz)
        Debug.LogWarning("Mermi havuzu dolu! Daha fazla mermi oluþturulamaz.");
        return null;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false); // Mermiyi devre dýþý býrak
        bulletPool.Enqueue(obj); // Havuza geri ekle
    }
}
