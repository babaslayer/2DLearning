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
        float inputx = Input.GetAxisRaw("Horizontal");//GetAxisRaw dedi�imizde kesin 0 veya 1,-1 de�erini d�nd�r�rken, getaxiste 0 dan 1 e giderken belli bir zaman ge�er.
        float inputy = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(inputx, inputy).normalized;//.normalized y�n vekt�r�n�n 1 de�erini a�mamas�n�, �emberin i�inde kalmas�n� sa�lar.   

    }
    void Movement()
    {
        body.velocity = moveDirection * movementSpeed;//Rigidbody referans�an h�z atan�r.

    }


}
