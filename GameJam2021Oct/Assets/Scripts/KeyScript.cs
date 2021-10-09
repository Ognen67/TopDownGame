using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int keys = 0;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            keys++;
        }

        if(other.gameObject.tag == "KeyDoor")
        {
            if (keys > 0)
            {
                if (Input.GetKeyDown("X"))
                {
                    keys--;
                }
            }
        }
    }
    
}
