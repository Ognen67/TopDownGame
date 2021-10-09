using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Vector3 Direction { get; set; }
    public PlayerMovement playerMovement;
    public float throwDistance = 2f;
    public float throwCap = 8f;

    private GameObject itemHolding;
    private float minThrowDistance = 2f;

    void Update()
    {
        if (itemHolding)
        {
            playerMovement.moveSpeed = 5;
        }
        else
        {
            playerMovement.moveSpeed = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
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
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                    Debug.Log("Lantern Picked Up");
                }
            }
        }
        if (itemHolding)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                minThrowDistance += Time.deltaTime * 2;
                if (minThrowDistance >= throwCap)
                {
                    throwDistance = minThrowDistance;
                    Debug.Log("ThrowDistance: " + throwDistance);

                    StartCoroutine(ThrowItem(itemHolding));
                    itemHolding = null;
                }
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                throwDistance = minThrowDistance;
                Debug.Log("ThrowDistance: " + throwDistance);

                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
            }
        }
    }

    public void equipLantern()
    {
        Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
        if (pickUpItem)
        {
            itemHolding = pickUpItem.gameObject;
            Debug.Log("Lantern Picked Up");
        }
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
