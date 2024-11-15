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
            //Bu þekilde kullanýca çalýþtý fakat ilk yaratýlan coin yok olunca bazý þeyler bozuldu.Bunu düzeltmek için nesneyi (Coin) Prefab yapýp koddaki referansa atadýk.

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

    
    public void Jumping(float jumpMultiplier)/*Baþka bir scripten buraya deðiþken getirirken türünü ve bir ad olarak buraya verip diðer scripten 
     buraya ulaþýrken scriptindeðiþkeni.Method(Deðiþken adý) */
    {

        //body.velocity=Vector2.up*jumpPower*speedMult;
        body.AddForce(Vector2.up * jumpPower * jumpMultiplier, ForceMode2D.Impulse);
    }
   
}