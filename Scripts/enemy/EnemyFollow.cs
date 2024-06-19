using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player object
    public float followSpeed = 5f;  // Speed at which the enemy follows the player
    public float followingZoneRadius = 5f;  // Radius of the following zone

    private bool isFollowing = false;

    void Update()
    {
        // Check if the player is within the following zone
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= followingZoneRadius)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        // If the enemy is following, move towards the player
        if (isFollowing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 movement = direction * followSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    void OnDrawGizmos()
    {
        // Draw a wire sphere in the editor to represent the following zone
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followingZoneRadius);
    }
}
