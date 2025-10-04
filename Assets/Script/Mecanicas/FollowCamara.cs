using UnityEngine;

public class FollowCamara : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset;
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(player.position + Vector3.up * 1.5f); 
    }
}
