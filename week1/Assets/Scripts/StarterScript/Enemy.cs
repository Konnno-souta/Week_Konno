using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
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
    /// 倒したときに入るスコア
    /// </summary>
    [SerializeField] int scoreValue = 100;

    ScoreUI scoreUI;

    void Start()
    {
        // シーン内のScoreUIを取得
        scoreUI = FindObjectOfType<ScoreUI>();
    }

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



    /// <summary>
    /// 敵が破壊されたとき
    /// </summary>
    void OnDestroy()
    {
        // GameManagerが存在すればスコア加算
        if (scoreUI != null)
        {
            scoreUI.AddScore(scoreValue);
        }
    }
}
