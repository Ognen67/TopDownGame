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
    public Vector2 movement;
    private Animator animator;
    public GameObject light;

    public Transform holdSpot;
    public LayerMask pickUpMask;
    private Transform transform;
    public Vector3 Direction { get; set; }

    private GameObject itemHolding;
    private float minThrowDistance = 0.2f;
    public float throwDistance = 2f;
    public float throwCap = 8f;

    // Raycast
    [SerializeField] float obstacleRayDistance;

    public GameObject obstacleRayObject;
    public LayerMask layerMask;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
            moveSpeed = 10f;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
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
                    light.SetActive(false);
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
                minThrowDistance += Time.deltaTime * (float)4;
                throwDistance = minThrowDistance;
                if (minThrowDistance >= throwCap)
                {
                    throwDistance = minThrowDistance;

                    StartCoroutine(ThrowItem(itemHolding));
                    itemHolding = null;
                }
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
            }
        }
       
        RaycastHit2D hitObstacle = Physics2D.Raycast(obstacleRayObject.transform.position, new Vector3(Direction.x, Direction.y, Direction.z), obstacleRayDistance, layerMask);

        if (hitObstacle.collider != null)
        {
            Debug.DrawRay(obstacleRayObject.transform.position, Direction * hitObstacle.distance, Color.red);
            //Debug.Log("Wall Detected");
            //Debug.Log(hitObstacle.distance);
            throwCap = hitObstacle.distance;
        }
        else
        {
            Debug.DrawRay(obstacleRayObject.transform.position, Direction * obstacleRayDistance, Color.green);
            throwCap = 8f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    public void asd()
    {
        //Debug.Log("asd");
    }


    IEnumerator ThrowItem(GameObject item)
    {
        light.SetActive(true);
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
        minThrowDistance = 0.2f;
    }

}

