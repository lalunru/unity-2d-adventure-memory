using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;           // 따라갈 플레이어
    public float smoothSpeed = 0.1f;   // 부드러운 이동 속도
    public Vector3 offset = new Vector3(0, 0, -10); // Z는 반드시 -10 등 고정

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
