using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPathBehavior : MonoBehaviour
{
    public Transform[] movementPink;
    public float movementSpeed;
    private EnemyFollow enemyFollowScript; 

    private Transform player;
    private bool followingPlayer = false;
    private int currentDestination;

    void Start()
    {
        currentDestination = 0;

        // Find and store the EnemyFollow script attached to the same GameObject
        enemyFollowScript = GetComponent<EnemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followingPlayer)
        {
            FollowPlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Vector2 patrolDirection = (movementPink[currentDestination].position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, movementPink[currentDestination].position, movementSpeed * Time.deltaTime);

        // Flip the enemy based on patrol direction
        if (patrolDirection.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (patrolDirection.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Vector2.Distance(transform.position, movementPink[currentDestination].position) < 0.2f)
        {
            currentDestination = (currentDestination + 1) % movementPink.Length;
        }

        CheckPlayerInZone();
        Debug.Log("Patrolling");
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            Vector2 playerDirection = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);

            // Flip the enemy based on player direction
            if (playerDirection.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (playerDirection.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            if (Vector2.Distance(transform.position, player.position) > enemyFollowScript.followingZoneRadius)
            {
                followingPlayer = false;
            }
        }
        Debug.Log("Following Player");
    }

    void CheckPlayerInZone()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) < enemyFollowScript.followingZoneRadius)
        {
            followingPlayer = true;
        }
        Debug.Log("Checking Player in Zone");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            followingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            followingPlayer = false;
        }
    }
}
