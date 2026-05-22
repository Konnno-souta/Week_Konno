using UnityEngine;

/// <summary>
/// 敵の生成を管理するクラス
/// </summary>
public class Starter_EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// 生成する敵プレハブ
    /// </summary>
    [SerializeField] GameObject enemyPrefab;

    /// <summary>
    /// 敵を生成する間隔
    /// </summary>
    [SerializeField] float spawnInterval = 1.5f;

    /// <summary>
    /// 敵が出現するX方向の範囲
    /// </summary>
    [SerializeField] float spawnRangeX = 8f;

    /// <summary>
    /// 敵を生成するZ座標
    /// </summary>
    [SerializeField] float spawnZ = 10f;

    /// <summary>
    /// 経過時間を管理するタイマー
    /// </summary>
    float timer;

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    void Update()
    {
        // 経過時間を加算
        timer += Time.deltaTime;

        // 一定時間ごとに敵を生成
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    /// <summary>
    /// 敵を生成する
    /// </summary>
    void SpawnEnemy()
    {
        // プレハブ未設定チェック
        if (enemyPrefab == null)
        {
            Debug.LogWarning("EnemyPrefab が設定されていません");
            return;
        }

        // ランダムなX座標を決定
        float x = Random.Range(-spawnRangeX, spawnRangeX);

        // 出現位置を作成
        Vector3 position = new Vector3(x, 1f, spawnZ);

        // 敵を生成
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
