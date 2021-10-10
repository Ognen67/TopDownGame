using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingBlocks : MonoBehaviour
{
    public float speedSmash = 10f;
    public float speedBack = 5f;
    
    public float position1 = 10f;
    public float position2 = 5f;
    bool switc = true;
    public bool left = false;
    public bool right = false;
    public bool up = false;
    public bool down = false;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (up == true)
        {
            if (switc)
            {
                moveBlockUpSmash();
            }
            if (!switc)
            {
                moveBlockDownBack();
            }
            if (transform.position.y >= position1)
            {
                switc = false;
                spriteRenderer.flipY = true;
            }
            if (transform.position.y <= position2)
            {
                switc = true;
                spriteRenderer.flipY = false;
            }
        }
        if (down == true)
        {
            if (switc)
            {
                moveBlockDownSmash();

            }
            if (!switc)
            {
                moveBlockUpBack();
            }
            if (transform.position.y <= position1)
            {
                switc = false;
                spriteRenderer.flipY = true;
            }
            if (transform.position.y >= position2)
            {
                switc = true;
                spriteRenderer.flipY = false;
            }
        }
        if (left == true)
        {
            if (switc)
            {
                moveBlockLeftSmash();
            }
            if (!switc)
            {
                moveBlockRightBack();
            }
            if (transform.position.x <= position1)
            {
                switc = false;
                spriteRenderer.flipX = true;
            }
            if (transform.position.x >= position2)
            {
                switc = true;
                spriteRenderer.flipX = false;
            }
        }
        if (right == true)
        {
            if (switc)
            {
                moveBlockRightSmash();
            }
            if (!switc)
            {
                moveBlockLeftBack();
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


    void moveBlockUpSmash()
    {
        transform.Translate(0, speedSmash * Time.deltaTime, 0);
    }
    void moveBlockDownSmash()
    {
        transform.Translate(0, -speedSmash * Time.deltaTime, 0);
    }
    void moveBlockRightSmash()
    {
        transform.Translate(speedSmash * Time.deltaTime, 0, 0);
    }
    void moveBlockLeftSmash()
    {
        transform.Translate(-speedSmash * Time.deltaTime, 0, 0);
    }



    void moveBlockUpBack()
    {
        transform.Translate(0, speedBack * Time.deltaTime, 0);
    }
    void moveBlockDownBack()
    {
        transform.Translate(0, -speedBack * Time.deltaTime, 0);
    }
    void moveBlockRightBack()
    {
        transform.Translate(speedBack * Time.deltaTime, 0, 0);
    }
    void moveBlockLeftBack()
    {
        transform.Translate(-speedBack * Time.deltaTime, 0, 0);
    }
}