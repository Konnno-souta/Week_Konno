using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;   // 追従対象（プレイヤー）
    public Vector3 offset;     // カメラの位置のズレ
    public float smoothSpeed = 5f; // なめらかさ

    void LateUpdate()
    {
        // 目的位置（プレイヤー位置 + オフセット）
        Vector3 desiredPosition = target.position + offset;

        // なめらかに移動
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // プレイヤーの方を見る
        transform.LookAt(target);
    }
}