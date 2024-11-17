using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Mermi prefab
    [SerializeField] private int poolSize; // Havuzdaki maksimum mermi sayýsý
    private Queue<GameObject> bulletPool = new Queue<GameObject>();//Mermiler için bir sýra oluþturur.Aynýsýný list þeklinde de yapabiliriz fakat metodlarý deðiþir.

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);//Prefabden bir kopya oluþturup bir GameObject referansý oluþturmak için yeni bir obje tanýmlýyoruz.
            obj.SetActive(false);//O nesneyi öncelikle kapatýyoruz.
            obj.GetComponent<Bullet>().SetPool(this); // Oluþturulan mermilere bu havuzun bir parçasý olduklarý referansý veriliyor.
            bulletPool.Enqueue(obj);//BulletPool havuzuna obj yi ekle.Sýraya Sok.
        }
    }

    public GameObject GetFromPool()//bulletPool kuyruðu GameObject türünden nesneleri sakladýðý için, biz de bir GameObject türü nesne alýyoruz ve onu döndürüyoruz.
    {
        if (bulletPool.Count > 0)
        {
            GameObject obj = bulletPool.Dequeue();
            obj.SetActive(true); // Mermiyi aktif et
            return obj;//return anahtar kelimesi, fonksiyonu sonlandýrýr ve belirtilen deðeri (bu durumda GameObject obj) dýþarýya iletir.
            //Fonksiyonun çaðrýldýðý yerde bu deðeri alabilir ve iþlem yapabilirsiniz.
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
