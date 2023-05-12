using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyGame_playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float movementSpeed = 2f;
    private bool moveLeft;
    private bool dontMove;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dontMove = true;
    }

    void Update()
    {
        HandleMoving();
    }

    void HandleMoving()
    {
        if (dontMove) 
        { StopMoving(); }
        else
        { 
            if (moveLeft) { MoveLeft(); }
            else if (!moveLeft) { MoveRight(); }
        }
    }

    public void AllowMovement (bool movement)
    {
        dontMove = false;
        moveLeft = movement;
    }

    public void DontAllowMovement()
    {
        dontMove = true;
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    public void StopMoving()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
}
