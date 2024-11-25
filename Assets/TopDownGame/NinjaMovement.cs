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

            canDash = false;//�ncelikle dashi atabilme becerimizi kapat�yoruz.(Tekrar atamayal�m diye)
            isDashing = true;//Dashi atarkenki s�recin aktif oldu�unu yaz�yoruz.
            body.velocity = moveDirection * dashSpeed;//Dashi hangi y�nde hangi h�zda ataca��m�z� yaz�yoruz.
            yield return new WaitForSeconds(dashDuration);//Ne kadar s�re dash att���m�z
            isDashing = false;//Dash atmay� durdur.
            yield return new WaitForSeconds(dashCooldown);//Tekrar ne zaman dash atabilece�imizi yaz�yoruz.
            canDash = true;//Tekrar dash atabilicez.

        }

        void GetInput()
        {
            float inputx = Input.GetAxisRaw("Horizontal");//GetAxisRaw dedi�imizde kesin 0 veya 1,-1 de�erini d�nd�r�rken, getaxiste 0 dan 1 e giderken belli bir zaman ge�er.
            float inputy = Input.GetAxisRaw("Vertical");
            moveDirection = new Vector2(inputx, inputy).normalized;//.normalized y�n vekt�r�n�n 1 de�erini a�mamas�n�, �emberin i�inde kalmas�n� sa�lar.   

        }
        void Movement()
        {
            body.velocity = moveDirection * movementSpeed;//Rigidbody referans�an h�z atan�r.

        }


    }
}
