using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Prevent the object from falling through the obstacle
            Vector3 newPosition = transform.position;
            newPosition.y = other.bounds.max.y + GetComponent<Collider>().bounds.extents.y;
            transform.position = newPosition;
        }
    }
}
