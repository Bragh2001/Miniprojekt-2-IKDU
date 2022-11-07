using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public float speed = 0;
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;
    public bool flipX;
    private SpriteRenderer flip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate()
    {
        Vector2 movementx = new Vector2(movementX,0);
        Vector2 movementy = new Vector2(0,movementY);

        rb.AddForce(movementx * speed);
        rb.AddForce(movementy * speed);

        if(movementX<0)
        {
            flip.flipX=true;
        }

        if(movementX>0)
        {
            flip.flipX=false;
        }

    }

    void Update()
    {
        
    }

}
