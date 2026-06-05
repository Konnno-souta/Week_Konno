using UnityEngine;
using UnityEngine.InputSystem;

public class MouseOrbitCamera : MonoBehaviour
{
    public Transform target;

    public float distance = 5.0f;
    public float sensitivity = 0.2f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    float currentX = 0f;
    float currentY = 20f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // マウス入力（新Input System）
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            currentX += mouseDelta.x * sensitivity;
            currentY -= mouseDelta.y * sensitivity;
        }

        // 上下制限
        currentY = Mathf.Clamp(currentY, yMinLimit, yMaxLimit);

        // 回転
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // 位置
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        transform.rotation = rotation;
        transform.position = position;
    }
}