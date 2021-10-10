using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlate : MonoBehaviour
{
    [SerializeField] private GameObject door1GameObject;
    [SerializeField] private GameObject door2GameObject;
    private DoorTrigger door1;
    private DoorTrigger door2;
    public GameObject door;
    float timer;
    public float TimeOfTimer;

    private void Awake()
    {
        door1 = door1GameObject.GetComponent<DoorTrigger>();
        door2 = door2GameObject.GetComponent<DoorTrigger>();

    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f) {
                door1.CloseDoor();
                door2.CloseDoor();
                door.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player") {
            door1.OpenDoor();
            door2.OpenDoor();
            door.SetActive(false);

        }

        if (other.gameObject.tag == "Box") {
            door.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            timer = TimeOfTimer;
        }
        if (other.gameObject.tag == "Box")
        {
            door.SetActive(true);
        }
    }
}
