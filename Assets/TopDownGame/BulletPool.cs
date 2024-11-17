using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Mermi prefab
    [SerializeField] private int poolSize; // Havuzdaki maksimum mermi say�s�
    private Queue<GameObject> bulletPool = new Queue<GameObject>();//Mermiler i�in bir s�ra olu�turur.Ayn�s�n� list �eklinde de yapabiliriz fakat metodlar� de�i�ir.

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);//Prefabden bir kopya olu�turup bir GameObject referans� olu�turmak i�in yeni bir obje tan�ml�yoruz.
            obj.SetActive(false);//O nesneyi �ncelikle kapat�yoruz.
            obj.GetComponent<Bullet>().SetPool(this); // Olu�turulan mermilere bu havuzun bir par�as� olduklar� referans� veriliyor.
            bulletPool.Enqueue(obj);//BulletPool havuzuna obj yi ekle.S�raya Sok.
        }
    }

    public GameObject GetFromPool()//bulletPool kuyru�u GameObject t�r�nden nesneleri saklad��� i�in, biz de bir GameObject t�r� nesne al�yoruz ve onu d�nd�r�yoruz.
    {
        if (bulletPool.Count > 0)
        {
            GameObject obj = bulletPool.Dequeue();
            obj.SetActive(true); // Mermiyi aktif et
            return obj;//return anahtar kelimesi, fonksiyonu sonland�r�r ve belirtilen de�eri (bu durumda GameObject obj) d��ar�ya iletir.
            //Fonksiyonun �a�r�ld��� yerde bu de�eri alabilir ve i�lem yapabilirsiniz.
        }

        // Havuzda mermi yoksa (opsiyonel olarak yeni bir tane olu�turabilirsiniz)
        Debug.LogWarning("Mermi havuzu dolu! Daha fazla mermi olu�turulamaz.");
        return null;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false); // Mermiyi devre d��� b�rak
        bulletPool.Enqueue(obj); // Havuza geri ekle
    }
}
