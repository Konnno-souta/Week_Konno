//using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
//public class Player : MonoBehaviour
//{
//    [Header("移動設定")]
//    public float moveSpeed = 5f;          // 移動速度
//    public float rotationSpeed = 10f;     // 回転のなめらかさ

//    [Header("参照")]
//    public Transform cameraTransform;    // メインカメラ（TPS用）

//    private CharacterController controller;
//    private Vector2 moveInput;           // 入力（WASD）
//    private float gravity = -9.8f;       // 重力
//    private float yVelocity;             // 落下用

//    void Awake()
//    {
//        controller = GetComponent<CharacterController>();
//    }

//    // Input System から呼ばれる（Move）
//    public void Move(InputAction.CallbackContext context)
//    {
//        moveInput = context.ReadValue<Vector2>();
//    }

//    void Update()
//    {
//        Move();
//    }

//    void Move()
//    {
//        // カメラの向きを基準にする
//        Vector3 forward = cameraTransform.forward;
//        Vector3 right = cameraTransform.right;

//        // 上下の傾きを無視（TPSでは水平移動）
//        forward.y = 0;
//        right.y = 0;

//        forward.Normalize();
//        right.Normalize();

//        // 入力方向を合成
//        Vector3 move = forward * moveInput.y + right * moveInput.x;

//        // 移動しているときだけプレイヤーを向ける
//        if (move.magnitude > 0.1f)
//        {
//            Quaternion targetRotation = Quaternion.LookRotation(move);
//            transform.rotation = Quaternion.Slerp(
//                transform.rotation,
//                targetRotation,
//                rotationSpeed * Time.deltaTime
//            );
//        }

//        // 重力処理
//        if (controller.isGrounded && yVelocity < 0)
//        {
//            yVelocity = -2f; // 地面に吸い付く
//        }

//        yVelocity += gravity * Time.deltaTime;

//        // 最終移動
//        Vector3 velocity = move * moveSpeed;
//        velocity.y = yVelocity;

//        controller.Move(velocity * Time.deltaTime);
//    }
//}