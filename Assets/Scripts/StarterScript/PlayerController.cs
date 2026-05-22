using UnityEngine;

/*public class Player : MonoBehaviour
{
    // 移動設定
    [Header("Move")]

    /// <summary>
    /// プレイヤーの移動速度
    /// </summary>
    [SerializeField] float moveSpeed = 6f;

    // ショット設定
    [Header("Shoot")]

    /// <summary>
    /// 発射する弾のプレハブ
    /// </summary>
    [SerializeField] GameObject bulletPrefab;

    /// <summary>
    /// 弾の発射位置
    /// </summary>
    [SerializeField] Transform firePoint;

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    void Update()
    {
        Move();
        Shoot();
    }

    /// <summary>
    /// プレイヤーを移動させる
    /// </summary>
    void Move()
    {
        // 入力値を取得
        Vector2 input = Input.Move;

        // 入力値を3Dベクトルへ変換
        Vector3 velocity = new Vector3(input.x, 0f, input.y);

        // ワールド座標基準で移動
        transform.Translate(velocity * moveSpeed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// 弾を発射する
    /// </summary>
    void Shoot()
    {
        // 発射入力が無い場合は終了
        if (!Input.FirePressed)
        {
            return;
        }

        // 必要な参照が設定されているか確認
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("BulletPrefab または FirePoint が設定されていない");
            return;
        }

        // 弾を生成
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}*/
