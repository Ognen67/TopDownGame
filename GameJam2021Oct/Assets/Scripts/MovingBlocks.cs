using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
    public float speed = 5f;
    public float position1= 5f;
    public float position2= 5f;
    bool switc = true;
    public bool leftRight = false;
    public bool upDown = false;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if (upDown == true) {
            if (switc)
            {
                moveBlockDown();
                
            }
            if (!switc)
            {
                moveBlockUp();
            }
            if (transform.position.y <= position1 )
            {
                switc = false;
                spriteRenderer.flipY = true;
            }
            if (transform.position.y >= position2  )
            {
                switc = true;
                spriteRenderer.flipY = false;
            }
        }
        if (leftRight == true) {
            if (switc)
            {
                moveBlockRight();
            }
            if (!switc)
            {
                moveBlockLeft();
            }
            if (transform.position.x >= position1)
            {
                switc = false;
                spriteRenderer.flipX = true;
            }
            if (transform.position.x <= position2)
            {
                switc = true;
                spriteRenderer.flipX = false;
            }
        }
        
    }


    void moveBlockUp()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        
    }
    void moveBlockDown()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        
    }

    void moveBlockRight()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    void moveBlockLeft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}