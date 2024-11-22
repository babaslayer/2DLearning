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

            canDash = false;
            isDashing = true;
            body.velocity = moveDirection * dashSpeed;
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;
            yield return new WaitForSeconds(dashCooldown);
            canDash = true;

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
