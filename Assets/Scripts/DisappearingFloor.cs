using System.Collections;
using UnityEngine;

public class DisappearingFloor : MonoBehaviour
{
    [Header("消える時間")]
    [SerializeField]
    private float destroyTime = 6f;

    /// <summary>
    /// 一度踏まれたか
    /// </summary>
    private bool stepped = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Player判定
        if (collision.gameObject.CompareTag("Player"))
        {
            // 二重防止
            if (stepped) return;

            stepped = true;

            // スコア追加
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1);
            }

            // 指定秒後に削除
            Invoke(nameof(DestroyFloor), destroyTime);
        }
    }

    /// <summary>
    /// 床削除
    /// </summary>
    private void DestroyFloor()
    {
        Destroy(gameObject);
    }
}