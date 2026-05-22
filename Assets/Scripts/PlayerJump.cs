using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 6f;

    [Header("ジャンプ設定")]
    [SerializeField] private float jumpPower = 8f;
    [SerializeField] private float gravity = -20f;

    private CharacterController controller;

    /// <summary>
    /// 移動入力値
    /// </summary>
    private Vector2 moveInput;

    /// <summary>
    /// Y軸速度
    /// </summary>
    private float velocityY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        // 接地中なら少し下方向へ固定
        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = -2f;
        }

        // 入力方向
        Vector3 move =
            new Vector3(moveInput.x, 0, moveInput.y);

        // 移動
        controller.Move(move * moveSpeed * Time.deltaTime);

        // 重力
        velocityY += gravity * Time.deltaTime;

        // Y軸移動
        Vector3 gravityMove =
            new Vector3(0, velocityY, 0);

        controller.Move(gravityMove * Time.deltaTime);
    }

    /// <summary>
    /// Move入力
    /// InputSystemのSend Messages用
    /// </summary>
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    /// <summary>
    /// Jump入力
    /// </summary>
    public void OnJump(InputValue value)
    {
        // ボタン押された瞬間
        if (value.isPressed && controller.isGrounded)
        {
            velocityY = jumpPower;
        }
    }
}