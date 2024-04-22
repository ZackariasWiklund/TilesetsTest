using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    [SerializeField]
    float speed = 1;


    void Update()
    {
        //Make a vector where the enemy can go left and right with a certain speed
        Vector2 movementX = new(speed, 0);

        //Make the enemy go on the vector and so that the speed is the same regardless of fps
        transform.Translate(movementX * Time.deltaTime);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            
        }

    }
}
