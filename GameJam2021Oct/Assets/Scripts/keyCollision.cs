using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollision : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            Debug.Log("touch");
            Destroy(door.gameObject);
            Destroy(this.gameObject);
        }
    }

}
