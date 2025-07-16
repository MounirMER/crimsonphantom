using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);
    
    void LateUpdate()
    {
        if (target != null)
        {
            // Only update position, not rotation
            transform.position = target.position + offset;
        }
    }
}