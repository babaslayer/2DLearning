using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float inputx;
    [SerializeField] float inputy;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] Rigidbody2D body;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] int jumpCounter;



    [Header("Ground Check Settings")]
    [SerializeField] private float rayLenght = 0.5f;
    [SerializeField] private Vector2 rayOffset = Vector2.zero;

    [Header("Dash")]
 
    [SerializeField] float dashDuration;
    [SerializeField] float dashCooldown;
    [SerializeField] float dashSpeed;
    [SerializeField] bool canDash;
    [SerializeField] bool isDashing;
    [SerializeField] private Vector2 dashDirection;
    [SerializeField] private int maxDashes = 1;
    private int dashCount;

    [Header("Gravity")]
    [SerializeField] private float originalGravity;
    [SerializeField] private float dashGravity = 0f;

    private bool facingright = true;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        originalGravity = body.gravityScale;
        canDash = true;

    }
    void Start()
    {
        jumpCounter = 2;
        dashCount = maxDashes;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        CheckGround();
        JumpCounter();
        DashInput();


    }

    void Flip()

    {
        facingright = !facingright;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
    void Movement()
    {
        if (!isDashing)
        {
            float inputx = Input.GetAxisRaw("Horizontal");
            float inputy = Input.GetAxisRaw("Vertical");
            body.velocity = new Vector2(inputx * runSpeed, body.velocity.y);
            moveDirection = new Vector2(inputx, inputy).normalized;
            Debug.Log(moveDirection);

            if(inputx>0 && !facingright)
            {
                Flip();
            }
            else if(inputx<0 && facingright)
            {
                Flip();
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            jumpCounter--;
            Debug.Log(jumpCounter);
        }

    }
    private void CheckGround()
    {
        rayOffset = new Vector2(0, 0);//Offsetin de�erini burada de�i�tirmek i�in.
        Vector2 origin = (Vector2)transform.position + rayOffset;//
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayLenght, groundLayer);
        isGrounded = hit.collider != null && body.velocity.y < 0;//Bir collide a �arp�yorsa yerde infosunu verir.(I��n�n �arpaca�� yerin collider� olmas� gerekiyor.)

        Debug.DrawRay(origin, Vector2.down * rayLenght, isGrounded ? Color.green : Color.red);
        if (isGrounded)
        {
            dashCount = maxDashes;
        }

    }
    void JumpCounter()//Sonra bak.
    {
        if (isGrounded)
        {
            jumpCounter = 2;

        }
    }
    void DashInput()
    {
        if (!isDashing)
        {
            Movement();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && dashCount > 0)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            dashDirection = input.normalized;

            // E�er oyuncu bir y�n girmemi�se varsay�lan y�n sa�
            if (dashDirection == Vector2.zero)
            {
                dashDirection = Vector2.right;
            }

            StartCoroutine(Dashing());
        }
    }
    IEnumerator Dashing()
    {

        canDash = false; // Dash yapmay� kapat
        isDashing = true; // Dash aktif
        dashCount--; // Bir dash hakk�n� t�ket

        float originalGravity = body.gravityScale; // Orijinal yer�ekimini kaydet
        body.gravityScale = dashGravity; // Dash s�ras�nda yer�ekimi s�f�rla
        body.velocity = new Vector2(dashDirection.x,dashDirection.y)*dashSpeed; // Dash y�n�n� ve h�z�n� uygula

        yield return new WaitForSeconds(dashDuration); // Dash s�resi boyunca bekle

        body.gravityScale = originalGravity; // Yer�ekimini eski haline getir
        isDashing = false; // Dash sona erdi

        yield return new WaitForSeconds(dashCooldown); // Dash bekleme s�resi
        canDash = true; // Tekrar dash yapabilir
    }
   


}