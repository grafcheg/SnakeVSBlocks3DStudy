using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.transform.position + cameraOffset;
            transform.position = targetPosition;
        }
    }
}
