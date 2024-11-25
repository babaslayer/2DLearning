using System;
using System.Collections;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float inputx;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int jumpCounter;

    private Vector2 lastMoveDirection;

    [Header("Ground Check Settings")]
    [SerializeField] private float rayLenght = 0.5f;
    [SerializeField] private Vector2 rayOffset = Vector2.zero;

    [Header("Dash")]
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashSpeed;
    [SerializeField] private bool canDash;
    [SerializeField] private bool isDashing;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    private void Start()
    {
        jumpCounter = 2;
    }

    private void Update()
    {
        Movement();
        Jump();
        CheckGround();
        JumpCounter();
        Dash();
    }

    void Movement()
    {
        inputx = Input.GetAxisRaw("Horizontal");
        if (inputx != 0)
        lastMoveDirection = new Vector2(inputx, 0).normalized; // Son hareket yönünü kaydet
        body.velocity = new Vector2(inputx * runSpeed, body.velocity.y);
        moveDirection = lastMoveDirection; // Dash için yön
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            jumpCounter--;
        }
    }

    private void CheckGround()
    {
        Vector2 origin = (Vector2)transform.position + rayOffset;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayLenght, groundLayer);
        isGrounded = hit.collider != null && body.velocity.y < 0;

        Debug.DrawRay(origin, Vector2.down * rayLenght, isGrounded ? Color.green : Color.red);
    }

    void JumpCounter()
    {
        if (isGrounded)
        {
            jumpCounter = 2;
        }
    }

    void Dash()
    {
        if (!isDashing && Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dashing());
        }
    }

    IEnumerator Dashing()
    {
        canDash = false;
        isDashing = true;

        float originalGravity = body.gravityScale;
        body.gravityScale = 0;

        body.velocity = moveDirection * dashSpeed;
        yield return new WaitForSeconds(dashDuration);

        body.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
