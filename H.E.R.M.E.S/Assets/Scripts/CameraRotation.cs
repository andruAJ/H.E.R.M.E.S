using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private float rotationSpeed = 50f;
    void Start()
    {
        InspectorEvents.OnRotatingLeft += RotateCamera;
        InspectorEvents.OnRotatingRight += RotateCamera;
    }
    void OnDestroy()
    {
        InspectorEvents.OnRotatingLeft -= RotateCamera;
        InspectorEvents.OnRotatingRight -= RotateCamera;
    }
    private void RotateCamera(int direction)
    {
        transform.RotateAround(
            targetObject.position,
            Vector3.up,
            direction * rotationSpeed * Time.deltaTime
        );
        Debug.Log("Rotating");
    }
}
