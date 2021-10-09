using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Basic Movement
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    private Transform transform;

    // Pick Up
    private PickUp pickUp;
    private GameObject lantern;

    private void Start()
    {
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        transform = gameObject.GetComponent<Transform>();
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, 1);
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.sqrMagnitude > .1f)
        {
            pickUp.Direction = movement.normalized;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(rb.constraints);
            retrieveLantern();
        }
    }

    private void retrieveLantern()
    {
        lantern.transform.position = new Vector2(transform.position.x, transform.position.y);
        Debug.Log(transform.position);
        Debug.Log(lantern.transform.position);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

    }
}

