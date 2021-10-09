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
    }





}
