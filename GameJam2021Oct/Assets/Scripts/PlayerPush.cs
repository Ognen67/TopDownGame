using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 3f;
    public LayerMask boxMask;

    GameObject box;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Box" && Input.GetKeyDown(KeyCode.LeftShift))
        {
            box = hit.collider.gameObject;
            Debug.Log(box);
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
        }

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}