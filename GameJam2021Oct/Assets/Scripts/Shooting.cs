using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float shootCoolDown = 2f;
    float nextShootTime = 0f;
    float shootTime;
    public float startShootTime;
    public Transform firePoint;
    public GameObject bulletPrefab;
    void Start()
    {
        shootTime = startShootTime;
    }
    void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        if (Time.time > nextShootTime)
        {
          
                if (shootTime <= 0)
                {
                    shootTime = startShootTime;
                   
                }
                else
                {
                    shootTime -= Time.deltaTime;
                    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                }
                nextShootTime = Time.time + shootCoolDown;
            }
        
    }

}
