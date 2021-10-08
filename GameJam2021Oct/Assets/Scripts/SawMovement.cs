using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
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
            moveSawright();
        }
        if (!switc)
        {
            moveSawleft();
        }
        if (transform.position.x >= 7f)
        {
            switc = false;
            spriteRenderer.flipX = true;
        }
        if (transform.position.x <= -7f)
        {
            switc = true;
            spriteRenderer.flipX = false;
        }
    }


    void moveSawright()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    void moveSawleft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}