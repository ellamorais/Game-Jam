using UnityEngine;

public class PlayerSync : MonoBehaviour
{
    public Transform originalPlayer; // Reference to the original player

    void Update()
    {
        if (originalPlayer != null)
        {
            transform.position = originalPlayer.position;
            transform.rotation = originalPlayer.rotation;
        }
    }
}
