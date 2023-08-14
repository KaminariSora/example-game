using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Detection Point
    public Transform detectionPoint1;
    public Transform detectionPoint2;
    public Transform detectionPoint3;
    public Transform detectionPoint4;
    //Detection Radius
    private const float detectionRadius = 0.2f;
    //Detection Layer
    public LayerMask detectionLayer;
    void Update()
    {
        if(DetectObject(detectionPoint1) || DetectObject(detectionPoint2) || DetectObject(detectionPoint3) || DetectObject(detectionPoint4))
        {
            Debug.Log("Deal Damage");
        }
    }

    bool DetectObject (Transform detectionPoint)
    {
        return Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
    }
}
