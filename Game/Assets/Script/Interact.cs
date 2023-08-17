using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Interact : MonoBehaviour
{
    //Detection Point
    public Transform detectionPoint;
    //Detection Radius
    private const float detectionRadius = 0.2f;
    //Detection Layer
    public LayerMask detectionLayer;

    public string sceneName;
    void Update()
    {
        if (DetectObject())
        {
            Collider2D detectedCollider = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
            if (detectedCollider != null)
            {
                if (detectedCollider.CompareTag("Door"))
                {
                    if (InteractionInput())
                    {
                        Debug.Log("OpenDoor");
                        SceneManager.LoadScene(sceneName);
                    }
                }
                else if(detectedCollider.CompareTag("Chest"))
                {
                    if (InteractionInput())
                    {
                        Debug.Log("OpenChest");
                    }
                }
            }

        }
    }

    bool InteractionInput()
    {
        return Input.GetKeyDown(KeyCode.F);
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    }
}
