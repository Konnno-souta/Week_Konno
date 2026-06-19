using UnityEngine;

/// <summary>
/// 敵キャラクターの移動と削除処理を管理するクラス
/// </summary>
public class Starter_Enemy : MonoBehaviour
{
    /// <summary>
    /// 敵の移動速度
    /// </summary>
    [SerializeField] float speed = 3f;

    /// <summary>
    /// このZ座標以下になったら削除する
    /// </summary>
    [SerializeField] float destroyZ = -12f;

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    void Update()
    {
        // 後方へ移動
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // 一定位置まで移動したら削除
        if (transform.position.z <= destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
