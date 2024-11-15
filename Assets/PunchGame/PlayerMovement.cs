using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    [SerializeField] float jumpPower = 1f;
    float gravity;
    public GameManager gameManager;
    public CoinManager coinManager;





    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
           if (Input.GetMouseButtonDown(0))
        {

            body.AddForce(new Vector2(0, 1) * jumpPower, ForceMode2D.Impulse);

        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            gameManager.CoinAdd();
            Destroy(collision.gameObject);
            //Bu �ekilde kullan�ca �al��t� fakat ilk yarat�lan coin yok olunca baz� �eyler bozuldu.Bunu d�zeltmek i�in nesneyi (Coin) Prefab yap�p koddaki referansa atad�k.

        }
    }


        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {


            gameManager.GameOver();

        }
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.AddScore();
    }*/

    
    public void Jumping(float jumpMultiplier)/*Ba�ka bir scripten buraya de�i�ken getirirken t�r�n� ve bir ad olarak buraya verip di�er scripten 
     buraya ula��rken scriptinde�i�keni.Method(De�i�ken ad�) */
    {

        //body.velocity=Vector2.up*jumpPower*speedMult;
        body.AddForce(Vector2.up * jumpPower * jumpMultiplier, ForceMode2D.Impulse);
    }
   
}