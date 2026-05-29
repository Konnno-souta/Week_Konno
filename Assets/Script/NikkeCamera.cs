using UnityEngine;

public class NikkeCamera : MonoBehaviour
{
    [Header("追従対象")]
    [SerializeField] private Transform target;

    [Header("位置オフセット")]
    [SerializeField]
    private Vector3 offset =
        new Vector3(0.7f, 2f, -4f);

    [Header("追従速度")]
    [SerializeField] private float smoothSpeed = 10f;

    void LateUpdate()
    {
        // 目標位置
        Vector3 targetPosition =
            target.position + target.TransformDirection(offset);

        // なめらか移動
        transform.position =
            Vector3.Lerp(
                transform.position,
                targetPosition,
                smoothSpeed * Time.deltaTime);

        // プレイヤーを見る
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}