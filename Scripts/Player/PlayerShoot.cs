using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootingRate = 0.5f;
    private float shootingTimer = 0f;

    void Update()
    {
        shootingTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q) && shootingTimer >= shootingRate)
        {
            Shoot();
            shootingTimer = 0f;
        }
    }

    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        // Adjust the speed as needed
        float bulletSpeed = 10f;
        bulletRb.velocity = direction * bulletSpeed;

        // You might want to add code for shooting sound effects or other effects here
    }
}
