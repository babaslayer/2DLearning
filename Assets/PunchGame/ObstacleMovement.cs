using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D obstacle_body;
    public float speed=3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obstacle_body.velocity = Vector2.left * speed;
    }
}
