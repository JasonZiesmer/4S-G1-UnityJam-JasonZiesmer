using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPortalBehavior : MonoBehaviour
{
    public Transform[] movementPink;
    public float movementSpeed;
    public int Destination;

    
    // Update is called once per frame
    void Update()
    {
        if (Destination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, movementPink[0].position, movementSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, movementPink[0].position) < .2f)
            {
                Destination = 1;
            }
        }
        // moves to patrolpoint B
        else if (Destination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, movementPink[1].position, movementSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, movementPink[1].position) < .2f)
            {
                Destination = 0;
            }
        }
    }
}
