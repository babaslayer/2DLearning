using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMovement : MonoBehaviour
{
    [SerializeField] float inputx;
    [SerializeField] float inputy;
    [SerializeField] float movementSpeed;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCooldown;
    [SerializeField] float dashSpeed;
    [SerializeField] bool canDash;
    [SerializeField] bool isDashing;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        canDash = true;
    }


    private void Update()
    {
        GetInput();

        if (!isDashing)
        {

            Movement();

        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {

            StartCoroutine(Dash());

        }

        IEnumerator Dash()
        {

            canDash = false;//Öncelikle dashi atabilme becerimizi kapatýyoruz.(Tekrar atamayalým diye)
            isDashing = true;//Dashi atarkenki sürecin aktif olduðunu yazýyoruz.
            body.velocity = moveDirection * dashSpeed;//Dashi hangi yönde hangi hýzda atacaðýmýzý yazýyoruz.
            yield return new WaitForSeconds(dashDuration);//Ne kadar süre dash attýðýmýz
            isDashing = false;//Dash atmayý durdur.
            yield return new WaitForSeconds(dashCooldown);//Tekrar ne zaman dash atabileceðimizi yazýyoruz.
            canDash = true;//Tekrar dash atabilicez.

        }

        void GetInput()
        {
            float inputx = Input.GetAxisRaw("Horizontal");//GetAxisRaw dediðimizde kesin 0 veya 1,-1 deðerini döndürürken, getaxiste 0 dan 1 e giderken belli bir zaman geçer.
            float inputy = Input.GetAxisRaw("Vertical");
            moveDirection = new Vector2(inputx, inputy).normalized;//.normalized yön vektörünün 1 deðerini aþmamasýný, çemberin içinde kalmasýný saðlar.   

        }
        void Movement()
        {
            body.velocity = moveDirection * movementSpeed;//Rigidbody referansýan hýz atanýr.

        }


    }
}
