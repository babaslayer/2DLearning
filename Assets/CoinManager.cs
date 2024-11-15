using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] float coin_speed;
    [SerializeField] GameObject coin;
    
    

    // Start is called before the first frame update
    private void Awake()
    {
      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * coin_speed * Time.deltaTime);
    }

    /*public void GettingCoin()
    {

        Destroy(gameObject);Bunu bu þekilde kullanýnca çalýþmadý.


    }*/
}
