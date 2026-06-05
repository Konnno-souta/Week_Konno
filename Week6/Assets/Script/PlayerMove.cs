using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed = 5f;

    [Header("カメラ")]
    public Transform cameraTransform;

    private Rigidbody rb;
    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // WASD入力
        moveInput = Keyboard.current == null
            ? Vector2.zero
            : new Vector2(
                (Keyboard.current.dKey.isPressed ? 1 : 0) -
                (Keyboard.current.aKey.isPressed ? 1 : 0),

                (Keyboard.current.wKey.isPressed ? 1 : 0) -
                (Keyboard.current.sKey.isPressed ? 1 : 0)
            );
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // カメラ基準の方向
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // Y消す（重要）
        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        // 入力 → 移動方向
        Vector3 moveDir = camForward * moveInput.y + camRight * moveInput.x;

        // Rigidbody移動
        rb.linearVelocity = new Vector3(
            moveDir.x * moveSpeed,
            rb.linearVelocity.y,
            moveDir.z * moveSpeed
        );

        // 向きを移動方向に
        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }
}