 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Basic Movement
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    // Pick Up
    private PickUp pickUp;

    private void Start()
    {
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, 1);
    }


    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.sqrMagnitude > .1f)
        {
            pickUp.Direction = movement.normalized;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

    }
}
