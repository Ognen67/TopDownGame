using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int keys = 0;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Key")
        {
            Destroy(other.gameObject);
            keys++;
        }

        if(other.tag == "KeyDoor")
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
