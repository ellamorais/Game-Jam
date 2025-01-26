using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    // Detection Point
    public Transform detectionPoint;

    // Detection Radius
    private const float detectionRadius = 0.2f;

    // Detection Layer
    public LayerMask detectionLayer;

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                Debug.Log("INTERACT");
            }
        }
    }

    bool InteractInput()
    {
        // Check if the 'E' key is pressed
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        // Check if there is an object within the detection radius on the detection layer
        Collider2D detectedObject = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        
        // Debug log to show if any object is detected
        if (detectedObject != null)
        {
            Debug.Log("Object Detected: " + detectedObject.gameObject.name);
        } else {
            Debug.Log("NO Object Detected");
        }

        return detectedObject != null;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the detection radius in the Scene view with a specified radius
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
