using UnityEngine;

/// <summary>
/// 弾の移動と衝突処理を管理するクラス
/// </summary>
public class Starter_Bullet : MonoBehaviour
{
    /// <summary>
    /// 弾の移動速度
    /// </summary>
    [SerializeField] float speed = 12f;

    /// <summary>
    /// 弾が自動削除されるまでの時間
    /// </summary>
    [SerializeField] float lifeTime = 3f;

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        // 一定時間後に弾を削除
        Destroy(gameObject, lifeTime);
    }

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    void Update()
    {
        // 前方向へ移動
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    /// <summary>
    /// 当たり判定発生時に呼ばれる
    /// </summary>
    /// <param name="other">衝突相手のコライダー</param>
    void OnTriggerEnter(Collider other)
    {
        // 相手がEnemyタグを持っている場合
        if (other.CompareTag("Enemy"))
        {
            // 敵を削除
            Destroy(other.gameObject);

            // 弾を削除
            Destroy(gameObject);
        }
    }
}
