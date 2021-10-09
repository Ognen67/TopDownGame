using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public int keys = 0;
    public float breakFloor = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Key
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            keys++;
        }

        if (other.gameObject.tag == "KeyDoor")
        {
            if (keys > 0)
            {
                if (Input.GetKeyDown("X"))
                {
                    keys--;
                }
            }
        }

        // Bullet
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }

        // BreakingFloor
        if (other.gameObject.tag == "BreakableFloor")
        {
            Destroy(other.gameObject, breakFloor);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Enemy
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Box")
        {
            // get the direction of the collision
            Vector3 direction = transform.position - other.gameObject.transform.position;
            // see if the obect is futher left/right or up down
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0) 
                {
                    Debug.Log("collision is to the right"); 
                    
                }
                else {
                    Debug.Log("collision is to the left");
                }
            }
            else
            {
                if (direction.y > 0) 
                {
                    Debug.Log("collision is up");
                }
                else
                {
                    Debug.Log("collision is down");
                }
            }
        }
    }





}
