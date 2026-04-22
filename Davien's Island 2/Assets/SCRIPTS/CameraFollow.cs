using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float distance = 6f;
    public float mouseSensitivity = 2f;
    public float yOffset = 2f;

    float xRotation = 20f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouseDelta = Vector2.zero;

        if (Mouse.current != null)
        {
            mouseDelta = Mouse.current.delta.ReadValue();
        }

        yRotation += mouseDelta.x * mouseSensitivity;
        xRotation -= mouseDelta.y * mouseSensitivity;

        xRotation = Mathf.Clamp(xRotation, -30f, 60f);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        Vector3 targetPosition = target.position + Vector3.up * yOffset;

        transform.position = targetPosition + offset;
        transform.LookAt(targetPosition);
    }
}