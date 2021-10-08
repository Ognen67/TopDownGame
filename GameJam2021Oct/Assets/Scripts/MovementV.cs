using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementV : MonoBehaviour
{
    public float speed = 5f;
    bool switc = true;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switc)
        {
            moveSawVup();
        }
        if (!switc)
        {
            moveSawVdown();
        }
        if (transform.position.y >= 7f)
        {
            switc = true;
            spriteRenderer.flipY = false;
        }
        if (transform.position.y >= 15f)
        {
            switc = false;
            spriteRenderer.flipY = true;
        }
    }


    void moveSawVup()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
    void moveSawVdown()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }
}