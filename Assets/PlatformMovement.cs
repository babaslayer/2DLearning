using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float inputx;
    [SerializeField] float inputy;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] Rigidbody2D body;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;


    [Header("Ground Check Settings")]
    [SerializeField] private float rayLenght = 0.5f;
    [SerializeField] private Vector2 rayOffset = Vector2.zero;



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
        Movement();
        Jump();


    }


    void Movement()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(inputx * runSpeed, body.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }

    }
    private void ChackeGround()
    {
        Vector2 origin = (Vector2)transform.position + rayOffset;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayLenght, groundLayer);
        isGrounded = hit.collider != null;

        Debug.DrawRay(origin, Vector2.down * rayLenght, isGrounded ? Color.green : Color.red);

    }


}
