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

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
  

    private void Update()
    {
        GetInput();
        Movement();

    }
    void GetInput()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(inputx, inputy).normalized;    

    }
    void Movement()
    {
        body.velocity = moveDirection * movementSpeed;

    }


}
