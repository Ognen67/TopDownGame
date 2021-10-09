using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Basic Movement
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    private Transform transform;
    private PickUp pickUp;
    private GameObject lantern;
    public Rigidbody2D rbBlock;

   


    public bool isPushPull = false;
    public float pushpullMultiplier;

    public bool canPushRight = false;
    public bool canPushUp = false;
    public bool canPushDown = false;
    public bool canPushLeft = false;

    // Pick Up


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
        lantern.transform.position = new Vector2(transform.position.x, transform.position.y);
        Debug.Log(transform.position);
        Debug.Log(lantern.transform.position);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && canPushLeft == true)
        {
            isPushPull = true;
            rbBlock.constraints.FreezePositionY;
        }
        if (Input.GetKey(KeyCode.LeftShift) && canPushRight == true)
        {
            isPushPull = true;
            rbBlock.constraints.FreezePositionY;
        }
        if (Input.GetKey(KeyCode.LeftShift) && canPushDown == true)
        {
            isPushPull = true;
            rbBlock.constraints.FreezePositionX;
        }
        if (Input.GetKey(KeyCode.LeftShift) && canPushUp == true)
        {
            isPushPull = true;
            rbBlock.constraints.FreezePositionX;
        }
        else
        {
            isPushPull = false;
        }
        if (isPushPull == true)
        {
            moveSpeed = 1.5f;
        }
        if (isPushPull == false)
        {
            moveSpeed = 5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pushableLeft")
        {
            canPushLeft = true;
        }
        else
        {
            canPushLeft = false;
        }
        if (other.gameObject.tag == "pushableRight")
        {
            canPushRight = true;
        }
        else
        {
            canPushRight = false;
        }
        if (other.gameObject.tag == "pushableDown")
        {
            canPushDown = true;
        }
        else
        {
            canPushDown = false;
        }
        if (other.gameObject.tag == "pushableUp")
        {
            canPushUp = true;
        }
        else
        {
            canPushUp = false;
        }



    }
    


}