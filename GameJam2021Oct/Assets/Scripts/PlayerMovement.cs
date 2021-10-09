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

    public Transform holdSpot;
    public LayerMask pickUpMask;
    private Transform transform;
    public Vector3 Direction { get; set; }

    private GameObject itemHolding;
    private float minThrowDistance = 2f;
    public float throwDistance = 2f;
    public float throwCap = 8f;

    private void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        Direction = new Vector2(0, 1);
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.sqrMagnitude > .1f)
        {
            Direction = movement.normalized;
        }

        if (itemHolding)
        {
            moveSpeed = 5;
        }
        else
        {
            moveSpeed = 0;
        }

        // Get Lantern
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, float.PositiveInfinity, pickUpMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }
        if (itemHolding)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                minThrowDistance += Time.deltaTime * 2;
                throwDistance = minThrowDistance;
                if (minThrowDistance >= throwCap)
                {
                    throwDistance = minThrowDistance;
                    Debug.Log("ThrowDistance: " + throwDistance);
                    Debug.Log("ItemHolding: " + itemHolding);

                    StartCoroutine(ThrowItem(itemHolding));
                    itemHolding = null;
                }
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                Debug.Log("ThrowDistance: " + throwDistance);
                Debug.Log("ItemHolding: " + itemHolding);
                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * throwDistance;
        item.transform.parent = null;
        for (int i = 0; i < 25; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i * 4f);
            yield return null;
        }
        if (item.GetComponent<Rigidbody2D>())
            item.GetComponent<Rigidbody2D>().simulated = true;
        minThrowDistance = 2f;
    }

}

