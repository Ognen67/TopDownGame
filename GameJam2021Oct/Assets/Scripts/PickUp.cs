using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Vector3 Direction { get; set; }
    public PlayerMovement playerMovement;
    private bool immobilized = true;

    private GameObject itemHolding;
    

    void Update()
    {
        /*if (immobilized)
        {
            playerMovement.moveSpeed = 0;
        }
        else
        {
            playerMovement.moveSpeed = 5;
        }*/
        if(itemHolding)
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
                immobilized = true;
            }
            else
            {
                immobilized = false;
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (itemHolding)
            {
                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
                immobilized = true;
            }
            else
            {
                immobilized = false;
            }
        }
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * 2;
        item.transform.parent = null;
        for (int i = 0; i < 25; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i * .04f);
            yield return null;
        }
        if (item.GetComponent<Rigidbody2D>())
            item.GetComponent<Rigidbody2D>().simulated = true;
    }

}
