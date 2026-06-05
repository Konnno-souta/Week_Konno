using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("制限時間")]
    public float time = 60f;

    [Header("UI")]
    public TMP_Text timerText;

    [Header("ゲームオーバーパネル")]
    public GameObject gameOverPanel;

    private bool isGameOver = false;

    public TMP_Text finalScoreText;
    public GameManager gameManager;

    private void Update()
    {
        if (isGameOver)
            return;

        time -= Time.deltaTime;

        timerText.text =
            "Time : " + Mathf.CeilToInt(time);

        if (time <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;

        gameOverPanel.SetActive(true);

        finalScoreText.text =
            "Final Score : " + gameManager.score;

        // カーソル解放
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}