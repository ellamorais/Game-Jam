using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    // Camera Boundaries
    [SerializeField] private float leftBoundary;
    [SerializeField] private float rightBoundary;

    private void Update()
    {
        float targetX = player.position.x + lookAhead;

        targetX = Mathf.Clamp(targetX, leftBoundary, rightBoundary);
        // Follow player
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
