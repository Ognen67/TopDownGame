using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    PickUp pickUpScript;

    public Text throwDistanceIndicator;

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
            retrieveLantern();
        }
    }

    private void retrieveLantern()
    {
        lantern.transform.position = new Vector2(pickUp.holdSpot.transform.position.x, pickUp.holdSpot.transform.position.y);
             
        pickUp.equipLantern();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}

