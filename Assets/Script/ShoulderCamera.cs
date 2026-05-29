using UnityEngine;

public class ShoulderCamera : MonoBehaviour
{
    [Header("追従対象")]
    [SerializeField] private Transform target;

    [Header("通常時オフセット")]
    [SerializeField]
    private Vector3 normalOffset =
        new Vector3(1.5f, 2f, -4f);

    [Header("エイム時オフセット")]
    [SerializeField]
    private Vector3 aimOffset =
        new Vector3(0.7f, 1.8f, -2f);

    [Header("回転感度")]
    [SerializeField] private float sensitivity = 2f;

    [Header("上下制限")]
    [SerializeField] private float minPitch = -30f;

    [SerializeField] private float maxPitch = 60f;

    [Header("補間速度")]
    [SerializeField] private float smoothSpeed = 10f;

    private float yaw;
    private float pitch;

    private Vector3 currentOffset;

    private bool isAim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentOffset = normalOffset;
    }

    void LateUpdate()
    {
        CameraRotate();
        CameraMove();
    }

    /// <summary>
    /// カメラ回転
    /// </summary>
    private void CameraRotate()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // 右クリックでエイム
        isAim = Input.GetMouseButton(1);

        // オフセット切り替え
        Vector3 targetOffset = isAim ? aimOffset : normalOffset;

        currentOffset = Vector3.Lerp(
            currentOffset,
            targetOffset,
            Time.deltaTime * smoothSpeed
        );
    }

    /// <summary>
    /// カメラ位置更新
    /// </summary>
    private void CameraMove()
    {
        Quaternion rotation =
            Quaternion.Euler(pitch, yaw, 0);

        Vector3 targetPosition =
            target.position + rotation * currentOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * smoothSpeed
        );

        // プレイヤーを見る
        Vector3 lookTarget =
            target.position + Vector3.up * 1.5f;

        transform.LookAt(lookTarget);

        // プレイヤー向き同期
        Vector3 forward = transform.forward;

        forward.y = 0f;

        if (forward != Vector3.zero)
        {
            target.forward = forward;
        }
    }
}