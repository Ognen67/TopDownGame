using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public float throwDistance = 5f;

    public Vector3 Direction { get; set; }
    private GameObject itemHolding;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding)
            {

            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction*throwDistance, .4f, pickUpMask);
            }
        }
    }
}
