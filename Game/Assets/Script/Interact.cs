using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    //Detection Point
    public Transform detectionPoint;
    //Detection Radius
    private const float detectionRadius = 0.2f;
    //Detection Layer
    public LayerMask detectionLayer;
    void Update()
    {
        if(DetectObject())
        {
            if(InteractionInput())
            {
                Debug.Log("OpenDoor");
            }
        }
    }

    bool InteractionInput () 
    {
        return Input.GetKeyDown(KeyCode.F);
    }

    bool DetectObject ()
    {
        return Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
    }
}
