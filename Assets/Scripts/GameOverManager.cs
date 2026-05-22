using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("ゲームオーバーパネル")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("落下判定の高さ")]
    [SerializeField] private float gameOverY = -10f;

    [Header("プレイヤー")]
    [SerializeField] private Transform player;

    private bool isGameOver = false;

    void Update()
    {
        // すでにゲームオーバーなら処理しない
        if (isGameOver) return;

        // 一定の高さより下に落ちたら
        if (player.position.y <= gameOverY)
        {
            GameOver();
        }
    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    private void GameOver()
    {
        isGameOver = true;

        // パネル表示
        gameOverPanel.SetActive(true);

        // 時間停止
        Time.timeScale = 0f;
    }

    /// <summary>
    /// リスタート
    /// </summary>
    public void RestartGame()
    {
        // 時間を戻す
        Time.timeScale = 1f;

        // 現在シーンを再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}