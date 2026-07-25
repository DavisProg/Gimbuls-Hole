using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float fixedX = -4f;
    public float fixedZ = -10f;
    public float yOffset = -3f;

    void LateUpdate()
    {
        if (player != null)
        {
            // Only update the Y axis using the player's position plus an offset
            float targetY = player.position.y + yOffset;
            transform.position = new Vector3(fixedX, targetY, fixedZ);
        }
    }
}
