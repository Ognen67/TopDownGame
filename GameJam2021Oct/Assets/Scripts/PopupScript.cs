using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScript : MonoBehaviour
{

    public GameObject message;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           message.gameObject.SetActive(true);
           return;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            message.gameObject.SetActive(false);
            return;
        }
    }
}
