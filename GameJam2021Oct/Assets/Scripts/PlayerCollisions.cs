using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public int keys = 0;
    public float breakFloor = 2f;
    public bool touch = false;

    private void Update()
    {

        if (Input.GetKey(KeyCode.Space)) {
            touch = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            touch = false;
        }
    }

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

        //Moving Platform

        if (other.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = other.transform;
        }

        //BreakingFloor
        if (other.gameObject.tag == "BreakableFloor")
        {
            //Transform water = other.gameObject.transform.GetChild(0);
            //water.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Floor Collided");

            StartCoroutine(ExecuteAfterTime(other, 2f));
        }
        // Enemy
        if (other.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
            Debug.Log("Water Collided");
            Destroy(this.gameObject);
        }
    }


    IEnumerator ExecuteAfterTime(Collider2D other, float time)
    {
        Transform water = other.gameObject.transform.GetChild(0);
        Debug.Log("Water gotten");
        yield return new WaitForSeconds(time);
        other.GetComponent<SpriteRenderer>().enabled = false;
        other.GetComponent<BoxCollider2D>().enabled = false;
        water.GetComponent<BoxCollider2D>().enabled = true;
        //Destroy(other.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        // Enemy
        if (other.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Box")
        {

            Debug.Log("Collided");
            if(touch == true)
            other.transform.parent = this.transform;
        }
        else if (other.gameObject.tag == "Box" && touch == false)
        {
            other.transform.parent = null;
        }

    }

    private void OnTriggerExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Debug.Log("Not COllided");
            
            collision.transform.parent = null;
        }
    }

}
